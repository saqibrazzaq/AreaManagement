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
import { AreaRes } from "../dtos/Area";

const AreaDelete = () => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const cancelRef = React.useRef<HTMLAnchorElement>(null);

  const [area, setArea] = useState<AreaRes>();
  
  const toast = useToast();
  const navigate = useNavigate();
  let params = useParams();
  const cityId = params.cityId;
  const areaId = params.areaId;
  
  const deleteArea = () => {
    onClose();
    AreaApi.delete(areaId).then(res => {
      toast({
        title: "Success",
        description: area?.name + " deleted successfully.",
        status: "success",
        position: "top-right",
      });
      navigate("/areas/" + cityId);
    });
  };

  const showAreaInfo = () => (
    <div>
      <TableContainer>
        <Table variant="simple">
          <Tbody>
            <Tr>
              <Th>Name</Th>
              <Td>{area?.name}</Td>
            </Tr>
            <Tr>
              <Th>City</Th>
              <Td>{area?.city?.name + ", " + area?.city?.state?.name + ", " + area?.city?.state?.country?.name}</Td>
            </Tr>
          </Tbody>
        </Table>
      </TableContainer>
      <HStack pt={4} spacing={4}>
        <Link onClick={onOpen}>
          <Button type="button" colorScheme={"red"}>YES, I WANT TO DELETE THIS AREA</Button>
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
            Delete Area
          </AlertDialogHeader>

          <AlertDialogBody>
            Are you sure? You can't undo this action afterwards.
          </AlertDialogBody>

          <AlertDialogFooter>
            <Link ref={cancelRef} onClick={onClose}>
              <Button type="button" colorScheme={"gray"}>Cancel</Button>
            </Link>
            <Link onClick={deleteArea} ml={3}>
              <Button type="submit" colorScheme={"red"}>Delete Area</Button>
            </Link>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialogOverlay>
    </AlertDialog>
  );

  useEffect(() => {
    loadArea();
  }, []);

  const loadArea = () => {
    AreaApi.get(areaId).then(res => {
      setArea(res);
    })
  };

  const displayHeading = () => (
    <Flex>
      <Box>
        <Heading fontSize={"xl"}>Delete Area</Heading>
      </Box>
      <Spacer />
      <Box>
        <Link ml={2} as={RouteLink} to={"/areas/" + cityId}>
          <Button type="button" colorScheme={"gray"}>Back</Button>
        </Link>
      </Box>
    </Flex>
  );
  return (
    <Box p={4}>
      <Stack spacing={4} as={Container} maxW={"3xl"}>
        {displayHeading()}
        <Text fontSize="xl">
          Are you sure you want to delete the following Area?
        </Text>
        {showAreaInfo()}
      </Stack>
      {showAlertDialog()}
    </Box>
  )
}

export default AreaDelete