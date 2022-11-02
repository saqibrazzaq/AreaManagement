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
import { Link as RouteLink, useParams } from "react-router-dom";
import UpdateIconButton from "../components/UpdateIconButton";
import DeleteIconButton from "../components/DeleteIconButton";
import PagedRes from "../dtos/PagedResponse";
import CountrySearchBox from "../searchboxes/CountrySearchBox";
import { StateReqSearch, StateRes } from "../dtos/State";
import { CountryRes } from "../dtos/Country";
import { StateApi } from "../api/stateApi";

const States = () => {
  const [pagedRes, setPagedRes] = useState<PagedRes<StateRes>>();
  const [selectedCountry, setSelectedCountry] = useState<CountryRes>();
  const [countryId, setCountryId] = useState<number>(0);
  const [searchText, setSearchText] = useState<string>("");

  useEffect(() => {
    // console.log("URL: " + process.env.REACT_APP_API_BASE_URL)
    searchStates(new StateReqSearch({}));
  }, []);

  const searchStates = (searchParams: StateReqSearch) => {
    StateApi.search(searchParams).then((res) => {
      setPagedRes(res);
      // console.log(res);
    });
  };

  const previousPage = () => {
    if (pagedRes?.metaData) {
      let previousPageNumber = (pagedRes?.metaData?.currentPage || 2) - 1;
      let searchParams = new StateReqSearch(
        {
          pageNumber: previousPageNumber,
        },
        countryId
      );

      searchStates(searchParams);
    }
  };

  const nextPage = () => {
    if (pagedRes?.metaData) {
      let nextPageNumber = (pagedRes?.metaData?.currentPage || 0) + 1;
      let searchParams = new StateReqSearch(
        { pageNumber: nextPageNumber },
        countryId
      );

      searchStates(searchParams);
    }
  };

  const showHeading = () => (
    <Flex>
      <Box>
        <Heading fontSize={"xl"}>States</Heading>
      </Box>
      <Spacer />
      <Box>
        <Link ml={2} as={RouteLink} to={"/states/edit"}>
          <Button colorScheme={"blue"}>Add State</Button>
        </Link>
      </Box>
    </Flex>
  );

  const showStates = () => (
    <TableContainer>
      <Table variant="simple">
        <Thead>
          <Tr>
            <Th>Code</Th>
            <Th>Name</Th>
            <Th></Th>
          </Tr>
        </Thead>
        <Tbody>
          {pagedRes?.pagedList?.map((item) => (
            <Tr key={item.stateId}>
              <Td>{item.code}</Td>
              <Td>{item.name}</Td>
              <Td>
                <Link mr={2} as={RouteLink} to={"/states/edit/" + item.stateId}>
                  <UpdateIconButton />
                </Link>
                <Link as={RouteLink} to={"/states/delete/" + item.stateId}>
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
        <CountrySearchBox
          selectedCountry={selectedCountry}
          handleChange={(newValue?: CountryRes) => {
            setSelectedCountry(newValue);
            let cid = newValue?.countryId || 0;
            setCountryId(cid);
            searchStates(
              new StateReqSearch({ searchText: searchText }, cid)
            );
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
              searchStates(
                new StateReqSearch({ searchText: searchText }, countryId)
              );
            }
          }}
        />
      </Box>
      <Box ml={0}>
        <Button
          colorScheme={"blue"}
          onClick={() => {
            searchStates(
              new StateReqSearch({ searchText: searchText }, countryId)
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
        {showStates()}
      </Stack>
    </Box>
  );
};

export default States;
