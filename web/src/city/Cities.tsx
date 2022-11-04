import React, { useEffect, useState } from "react";
import {
  Box,
  Button,
  Container,
  Flex,
  Heading,
  Input,
  Link,
  Spacer,
  Stack,
  Table,
  TableContainer,
  Tbody,
  Td,
  Text,
  Tfoot,
  Th,
  Thead,
  Tr,
} from "@chakra-ui/react";
import {
  Link as RouteLink,
  Navigate,
  useNavigate,
  useParams,
} from "react-router-dom";
import UpdateIconButton from "../components/UpdateIconButton";
import DeleteIconButton from "../components/DeleteIconButton";
import PagedRes from "../dtos/PagedResponse";
import CountrySearchBox from "../searchboxes/CountrySearchBox";
import { StateRes } from "../dtos/State";
import { StateApi } from "../api/stateApi";
import { CityReqSearch, CityResWithAreasCount } from "../dtos/City";
import { CityApi } from "../api/cityApi";
import StateSearchBox from "../searchboxes/StateSearchBox";

const Cities = () => {
  const params = useParams();
  const stateId = Number.parseInt(params.stateId || "0");
  const [pagedRes, setPagedRes] = useState<PagedRes<CityResWithAreasCount>>();
  const [selectedState, setSelectedState] = useState<StateRes>({});
  const [searchText, setSearchText] = useState<string>("");
  const navigate = useNavigate();

  // console.log("selected country: " + (selectedCountry?.countryId || "0"));
  useEffect(() => {
    // console.log("URL: " + process.env.REACT_APP_API_BASE_URL)
    searchCities(new CityReqSearch({}, stateId));
  }, [stateId]);

  useEffect(() => {
    loadState();
  }, [stateId]);

  const loadState = () => {
    StateApi.get(stateId).then((res) => {
      setSelectedState(res);
    });
  };

  const searchCities = (searchParams: CityReqSearch) => {
    CityApi.searchCitiesWithAreasCount(searchParams).then((res) => {
      setPagedRes(res);
      // console.log(res);
    });
  };

  const previousPage = () => {
    if (pagedRes?.metaData) {
      let previousPageNumber = (pagedRes?.metaData?.currentPage || 2) - 1;
      let searchParams = new CityReqSearch(
        {
          pageNumber: previousPageNumber,
        },
        selectedState?.stateId
      );

      searchCities(searchParams);
    }
  };

  const nextPage = () => {
    if (pagedRes?.metaData) {
      let nextPageNumber = (pagedRes?.metaData?.currentPage || 0) + 1;
      let searchParams = new CityReqSearch(
        { pageNumber: nextPageNumber },
        selectedState?.stateId
      );

      searchCities(searchParams);
    }
  };

  const showHeading = () => (
    <Flex>
      <Box>
        <Heading fontSize={"xl"}>Cities</Heading>
      </Box>
      <Spacer />
      <Box>
        <Link
          ml={2}
          as={RouteLink}
          to={"/cities/edit/" + (selectedState?.stateId || "")}
        >
          <Button colorScheme={"blue"}>Add City</Button>
        </Link>
      </Box>
    </Flex>
  );

  const showCities = () => (
    <TableContainer>
      <Table variant="simple">
        <Thead>
          <Tr>
            <Th>Name</Th>
            <Th>Areas</Th>
            <Th></Th>
          </Tr>
        </Thead>
        <Tbody>
          {pagedRes?.pagedList?.map((item) => (
            <Tr key={item.stateId}>
              <Td>{item.name}</Td>
              <Td>{item.areasCount}</Td>
              <Td>
                <Link
                  mr={2}
                  as={RouteLink}
                  to={
                    "/cities/edit/" +
                    selectedState?.stateId +
                    "/" +
                    item.cityId
                  }
                >
                  <UpdateIconButton />
                </Link>
                <Link as={RouteLink} to={"/cities/delete/"  +
                    selectedState?.stateId +
                    "/" +
                    item.cityId}>
                  <DeleteIconButton />
                </Link>
              </Td>
            </Tr>
          ))}
        </Tbody>
        <Tfoot>
          <Tr>
            <Th colSpan={2} textAlign="center">
              <Button
                isDisabled={!pagedRes?.metaData?.hasPrevious}
                variant="link"
                mr={5}
                onClick={previousPage}
              >
                Previous
              </Button>
              Page {pagedRes?.metaData?.currentPage} of{" "}
              {pagedRes?.metaData?.totalPages}
              <Button
                isDisabled={!pagedRes?.metaData?.hasNext}
                variant="link"
                ml={5}
                onClick={nextPage}
              >
                Next
              </Button>
            </Th>
          </Tr>
        </Tfoot>
      </Table>
    </TableContainer>
  );

  const displaySearchBar = () => (
    <Flex>
      <Box flex={1}>
        <StateSearchBox
          selectedState={selectedState}
          handleChange={(newValue?: StateRes) => {
            navigate("/cities/" + newValue?.stateId);
            // console.log("/states/" + newValue?.countryId);
          }}
        />
      </Box>

      <Box ml={4}>
        <Input
          placeholder="Search..."
          value={searchText}
          onChange={(e) => setSearchText(e.currentTarget.value)}
          onKeyDown={(e) => {
            if (e.key === "Enter") {
              searchCities(
                new CityReqSearch(
                  { searchText: searchText },
                  selectedState?.stateId
                )
              );
            }
          }}
        />
      </Box>
      <Box ml={0}>
        <Button
          colorScheme={"blue"}
          onClick={() => {
            searchCities(
              new CityReqSearch(
                { searchText: searchText },
                selectedState?.stateId
              )
            );
          }}
        >
          Search
        </Button>
      </Box>
    </Flex>
  );

  return (
    <Box width={"100%"} p={4}>
      <Stack spacing={4} as={Container} maxW={"3xl"}>
        {showHeading()}
        {displaySearchBar()}
        {showCities()}
      </Stack>
    </Box>
  );
}

export default Cities