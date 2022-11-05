import {
  AlertDialog,
  AlertDialogBody,
  AlertDialogContent,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogOverlay,
  Box,
  Button,
  Container,
  Divider,
  Flex,
  Heading,
  HStack,
  Link,
  Spacer,
  Stack,
  Table,
  TableContainer,
  Tbody,
  Td,
  Text,
  Th,
  Tr,
  useDisclosure,
  useToast,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Link as RouteLink, useNavigate, useParams } from "react-router-dom";
import { AreaApi } from "../api/areaApi";
import { CityApi } from "../api/cityApi";
import { CountryApi } from "../api/countryApi";
import { StateApi } from "../api/stateApi";
import { CountryResWithStatesCount } from "../dtos/Country";

const CountryReset = () => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const cancelRef = React.useRef<HTMLAnchorElement>(null);

  const [countryCount, setCountryCount] = useState<number>(0);
  const [stateCount, setStateCount] = useState<number>(0);
  const [cityCount, setCityCount] = useState<number>(0);
  const [areaCount, setAreaCount] = useState<number>(0);

  const toast = useToast();
  const navigate = useNavigate();

  const showCountryInfo = () => (
    <div>
      <TableContainer>
        <Table variant="simple">
          <Tbody>
            <Tr>
              <Th>Countries</Th>
              <Td>{countryCount}</Td>
            </Tr>
            <Tr>
              <Th>States</Th>
              <Td>{stateCount}</Td>
            </Tr>
            <Tr>
              <Th>Cities</Th>
              <Td>{cityCount}</Td>
            </Tr>
            <Tr>
              <Th>Areas</Th>
              <Td>{areaCount}</Td>
            </Tr>
          </Tbody>
        </Table>
      </TableContainer>
      <HStack pt={4} spacing={4}>
        <Link onClick={onOpen}>
          <Button type="button" colorScheme={"red"}>
            YES, I WANT TO RESET ALL DATA
          </Button>
        </Link>
      </HStack>
    </div>
  );

  const showAlertDialog = () => (
    <AlertDialog
      isOpen={isOpen}
      leastDestructiveRef={cancelRef}
      onClose={onClose}
    >
      <AlertDialogOverlay>
        <AlertDialogContent>
          <AlertDialogHeader fontSize="lg" fontWeight="bold">
            RESET CITIES, STATES, COUNTRIES
          </AlertDialogHeader>

          <AlertDialogBody>
            Are you sure? You can't undo this action afterwards.
          </AlertDialogBody>

          <AlertDialogFooter>
            <Link ref={cancelRef} onClick={onClose}>
              <Button type="button" colorScheme={"gray"}>
                Cancel
              </Button>
            </Link>
            <Link onClick={resetAllData} ml={3}>
              <Button type="submit" colorScheme={"red"}>
                RESET ALL DATA
              </Button>
            </Link>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialogOverlay>
    </AlertDialog>
  );

  useEffect(() => {
    loadCountryCount();
    loadStateCount();
    loadCityCount();
    loadAreaCount();
  }, []);

  const loadAreaCount = () => {
    AreaApi.count().then((res) => {
      setAreaCount(res);
    });
  };

  const loadCityCount = () => {
    CityApi.count().then((res) => {
      setCityCount(res);
    });
  };

  const loadStateCount = () => {
    StateApi.count().then((res) => {
      setStateCount(res);
    });
  };

  const loadCountryCount = () => {
    CountryApi.count().then((res) => {
      setCountryCount(res);
      // console.log(res);
    });
  };

  const resetAllData = () => {
    CountryApi.reset().then((res) => {
      navigate("/countries");
    });
  };

  const displayHeading = () => (
    <Flex>
      <Box>
        <Heading fontSize={"xl"}>RESET ALL DATA</Heading>
      </Box>
      <Spacer />
      <Box>
        <Link ml={2} as={RouteLink} to={"/countries"}>
          <Button type="button" colorScheme={"gray"}>
            Back
          </Button>
        </Link>
      </Box>
    </Flex>
  );
  return (
    <Box width={"100%"} p={4}>
      <Stack spacing={4} as={Container} maxW={"3xl"}>
        {displayHeading()}
        <Text fontSize="xl">Are you sure you want to delete ALL DATA?</Text>
        {showCountryInfo()}
      </Stack>
      {showAlertDialog()}
    </Box>
  );
};

export default CountryReset;
