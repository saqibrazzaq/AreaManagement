import {
  Box,
  Button,
  Container,
  Flex,
  FormControl,
  FormErrorMessage,
  FormLabel,
  Heading,
  Input,
  Link,
  Spacer,
  Stack,
  useToast,
} from "@chakra-ui/react";
import * as Yup from "yup";
import { Link as RouteLink, useNavigate, useParams } from "react-router-dom";
import React, { useEffect, useState } from "react";
import { Field, Formik } from "formik";
import { StateReqEdit, StateRes } from "../dtos/State";
import { StateApi } from "../api/stateApi";
import CountrySearchBox from "../searchboxes/CountrySearchBox";
import { CityApi } from "../api/cityApi";
import { CityReqEdit, CityRes } from "../dtos/City";
import StateSearchBox from "../searchboxes/StateSearchBox";
import { AreaReqEdit } from "../dtos/Area";
import { AreaApi } from "../api/areaApi";
import CitySearchBox from "../searchboxes/CitySearchBox";

const AreaEdit = () => {
  const [selectedCity, setSelectedCity] = useState<CityRes>();
  const params = useParams();
  const cityId = Number.parseInt(params.cityId || "0");
  const areaId = Number.parseInt(params.areaId || "0");
  const updateText = areaId ? "Update Area" : "Add Area";
  const [areaDto, setAreaDto] = useState<AreaReqEdit>(new AreaReqEdit(cityId));
  const toast = useToast();
  const navigate = useNavigate();

  useEffect(() => {
    loadAreaForEdit();
  }, [areaId]);

  useEffect(() => {
    loadCityForDropdown(areaDto.cityId);
  }, [areaDto.cityId]);

  useEffect(() => {
    loadCityForDropdown(cityId);
  }, [cityId]);

  const loadCityForDropdown = (id?:number) => {
    CityApi.get(id).then((res) => {
      setSelectedCity(res);
    });
  };

  const loadAreaForEdit = () => {
    if (areaId) {
      AreaApi.get(areaId).then((res) => {
        setAreaDto(res);
        // console.log(res);
      });
    }
  };

  // Formik validation schema
  const validationSchema = Yup.object({
    name: Yup.string().required("Name is required").max(255),
    code: Yup.string().required("Code is required").max(50),
    cityId: Yup.number().required("City Id is required").min(1, "Please select a city"),
  });

  const submitForm = (values: AreaReqEdit) => {
    // console.log(values);
    if (areaId) {
      updateArea(values);
    } else {
      createArea(values);
    }
  };

  const updateArea = (values: AreaReqEdit) => {
    AreaApi.update(areaId, values).then((res) => {
      toast({
        title: "Success",
        description: "Area updated successfully.",
        status: "success",
        position: "top-right",
      });
      navigate("/areas/" + cityId);
    });
  };

  const createArea = (values: AreaReqEdit) => {
    AreaApi.create(values).then((res) => {
      toast({
        title: "Success",
        description: "Area created successfully.",
        status: "success",
        position: "top-right",
      });
      // navigate("/states/edit/" + res.stateId)
      navigate("/areas/" + cityId);
    });
  };

  const showUpdateForm = () => (
    <Box p={0}>
      <Formik
        initialValues={areaDto}
        onSubmit={(values) => {
          submitForm(values);
        }}
        validationSchema={validationSchema}
        enableReinitialize={true}
      >
        {({ handleSubmit, errors, touched, setFieldValue }) => (
          <form onSubmit={handleSubmit}>
            <Stack spacing={4} as={Container} maxW={"3xl"}>
              <FormControl isInvalid={!!errors.cityId && touched.cityId}>
                <FormLabel htmlFor="cityId">City Id</FormLabel>
                <Field as={Input} id="cityId" name="cityId" type="hidden" />
                <CitySearchBox
                  selectedCity={selectedCity}
                  handleChange={(newValue?: CityRes) => {
                    setSelectedCity(newValue);
                    setFieldValue("cityId", newValue?.cityId)
                    // console.log(newValue)
                  }}
                />
                <FormErrorMessage>{errors.cityId}</FormErrorMessage>
              </FormControl>

              <FormControl isInvalid={!!errors.code && touched.code}>
                <FormLabel htmlFor="code">Code</FormLabel>
                <Field as={Input} id="code" name="code" type="text" />
                <FormErrorMessage>{errors.code}</FormErrorMessage>
              </FormControl>
              <FormControl isInvalid={!!errors.name && touched.name}>
                <FormLabel htmlFor="name">Name</FormLabel>
                <Field as={Input} id="name" name="name" type="text" />
                <FormErrorMessage>{errors.name}</FormErrorMessage>
              </FormControl>
              <Stack direction={"row"} spacing={6}>
                <Button type="submit" colorScheme={"blue"}>
                  {updateText}
                </Button>
              </Stack>
            </Stack>
          </form>
        )}
      </Formik>
    </Box>
  );

  const displayHeading = () => (
    <Flex>
      <Box>
        <Heading fontSize={"xl"}>{updateText}</Heading>
      </Box>
      <Spacer />
      <Box>
        <Link ml={2} as={RouteLink} to={"/areas/" + cityId}>
          <Button colorScheme={"gray"}>Back</Button>
        </Link>
      </Box>
    </Flex>
  );

  return (
    <Box width={"100%"} p={4}>
      <Stack spacing={4} as={Container} maxW={"3xl"}>
        {displayHeading()}
        {showUpdateForm()}
      </Stack>
    </Box>
  );
}

export default AreaEdit