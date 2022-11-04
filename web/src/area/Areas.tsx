import React, { useEffect, useState } from "react";
import {
  Box,
  Button,
  Center,
  Container,
  Flex,
  FormControl,
  FormLabel,
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
import { CityApi } from "../api/cityApi";
import StateSearchBox from "../searchboxes/StateSearchBox";
import { AreaReqSearch, AreaRes } from "../dtos/Area";
import { CityRes } from "../dtos/City";
import { AreaApi } from "../api/areaApi";
import CitySearchBox from "../searchboxes/CitySearchBox";

const Areas = () => {
  const params = useParams();
  const cityId = Number.parseInt(params.cityId || "0");
  const stateId = Number.parseInt(params.stateId || "0");
  const [pagedRes, setPagedRes] = useState<PagedRes<AreaRes>>();
  const [selectedCity, setSelectedCity] = useState<CityRes>({});
  const [searchText, setSearchText] = useState<string>("");
  const navigate = useNavigate();

  // console.log("selected country: " + (selectedCountry?.countryId || "0"));
  useEffect(() => {
    // console.log("URL: " + process.env.REACT_APP_API_BASE_URL)
    searchAreas(new AreaReqSearch({}, cityId));
  }, [cityId]);

  useEffect(() => {
    loadCity();
  }, [cityId]);

  const loadCity = () => {
    CityApi.get(cityId).then((res) => {
      setSelectedCity(res);
    });
  };

  const searchAreas = (searchParams: AreaReqSearch) => {
    AreaApi.search(searchParams).then((res) => {
      setPagedRes(res);
      // console.log(res);
    });
  };

  const previousPage = () => {
    if (pagedRes?.metaData) {
      let previousPageNumber = (pagedRes?.metaData?.currentPage || 2) - 1;
      let searchParams = new AreaReqSearch(
        {
          pageNumber: previousPageNumber,
        },
        selectedCity?.cityId
      );

      searchAreas(searchParams);
    }
  };

  const nextPage = () => {
    if (pagedRes?.metaData) {
      let nextPageNumber = (pagedRes?.metaData?.currentPage || 0) + 1;
      let searchParams = new AreaReqSearch(
        { pageNumber: nextPageNumber },
        selectedCity?.cityId
      );

      searchAreas(searchParams);
    }
  };

  const showHeading = () => (
    <Flex>
      <Box>
        <Heading fontSize={"xl"}>Areas</Heading>
      </Box>
      <Spacer />
      <Box>
        <Link
          ml={2}
          as={RouteLink}
          to={"/areas/edit/" + (selectedCity?.cityId || "")}
        >
          <Button colorScheme={"blue"}>Add Area</Button>
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
            <Th>Code</Th>
            <Th></Th>
          </Tr>
        </Thead>
        <Tbody>
          {pagedRes?.pagedList?.map((item) => (
            <Tr key={item.areaId}>
              <Td>{item.name}</Td>
              <Td>{item.code}</Td>
              <Td>
                <Link
                  mr={2}
                  as={RouteLink}
                  to={"/areas/edit/" + item.cityId + "/" + item.areaId}
                >
                  <UpdateIconButton />
                </Link>
                <Link
                  as={RouteLink}
                  to={"/areas/delete/" + item.cityId + "/" + item.areaId}
                >
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
      <Center >
        <Text>Select city:</Text>
      </Center>
      <Box flex={1} ml={4}>
        <CitySearchBox
          selectedCity={selectedCity}
          handleChange={(newValue?: CityRes) => {
            navigate("/areas/" + newValue?.cityId);
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
              searchAreas(
                new AreaReqSearch(
                  { searchText: searchText },
                  selectedCity?.cityId
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
            searchAreas(
              new AreaReqSearch(
                { searchText: searchText },
                selectedCity?.cityId
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
};

export default Areas;
