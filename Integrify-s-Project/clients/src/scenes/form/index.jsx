import { Box, Button, TextField } from "@mui/material";
import { Formik} from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import Header from "../../components/Header";
import React, { useState } from "react";
import LoginOutlinedIcon from '@mui/icons-material/LoginOutlined';
import HowToRegOutlinedIcon from '@mui/icons-material/HowToRegOutlined';

const Form = () => {
  const [isSignup,setIsSignup]=useState(false)
  const [key, setKey] = useState(Date.now());
  const resetState = () => {
    setIsSignup((prevState) => !prevState);
    setKey(Date.now()); // update key to reset form
  };


  const isNonMobile = useMediaQuery("(min-width:600px)");

  const handleFormSubmit = (value) => {
 
    console.log(value);
  };

  
  return (
    <Box m="20px"
    justifyContent={"center"}
    margin="auto"
    marginTop={5}
    padding={3}
    borderRadius={5}
    maxWidth={800} alignItems="center" 
    boxShadow={'5px 5px 10px #ccc'}>
      <Header title={isSignup? "CREATE USER":"LOGIN USER"} subtitle= {isSignup? "Create a New User Profile":"Login to your account "}/>

      <Formik
        key={key}
        onSubmit={handleFormSubmit}
        initialValues={initialValues}

        validationSchema={isSignup?checkoutSchema:checkoutSchema_login}
      >
      
        {({
          values,
          errors,
          touched,
          handleBlur,
          handleChange,
          handleSubmit,
          
        }) => (
          <form onSubmit={handleSubmit}>
            <Box
              display="grid"
              gap="30px"
              gridTemplateColumns="repeat(4, minmax(0, 1fr))"
              sx={{
                "& > div": { gridColumn: isNonMobile ? undefined : "span 4" },
              }}
            >
              {isSignup && 
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="First Name"
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.firstName}
               
                name="firstName"
                error={!!touched.firstName && !!errors.firstName}
                helperText={touched.firstName && errors.firstName}
                sx={{ gridColumn: "span 2" }}
              />
             
        
            } 
            {isSignup && 
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Last Name"
                
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.lastName}
                name="lastName"
                error={!!touched.lastName && !!errors.lastName}
                helperText={touched.lastName && errors.lastName}
         
                sx={{ gridColumn: "span 2" }}
              />
            }{isSignup && 
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Contact Number"
                error={!!touched.contact && !!errors.contact}
                helperText={touched.contact && errors.contact}
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.contact}
                name="contact"
                sx={{ gridColumn: "span 4" }}
              />
            }{isSignup && 
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Address 1"
                error={!!touched.address1 && !!errors.address1}
                helperText={touched.address1 && errors.address1}
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.address1}
                name="address1"
                sx={{ gridColumn: "span 4" }}
              />}{isSignup && 
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Address 2"
               
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.address2}
                name="address2"
                sx={{ gridColumn: "span 4" }}
              />}
              {isSignup && 
                <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Email"
                error={!!touched.email && !!errors.email}
                helperText={touched.email && errors.email}
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.email}
                name="email"
                sx={{ gridColumn: "span 2" }}
              />}
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="User Name"
                error={!!touched.userName && !!errors.userName}
                helperText={touched.userName && errors.userName}
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.userName}
                name="userName"
                sx={{ gridColumn: "span 2" }}
              />
              <TextField
                fullWidth
                variant="filled"
                type="password"
                label="Password"
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.password}
                name="password"
                error={!!touched.password && !!errors.password}
                helperText={touched.password && errors.password}
                sx={{ gridColumn: "span 2" }}
              />
              {isSignup && 
              <TextField
                fullWidth
                variant="filled"
                type="password"
                label="Confirm Password"
                
                onChange={handleChange}
                onBlur={handleBlur}
                value={values.confirmPswd}
                name="confirmPswd"
                error={!!touched.confirmPswd && !!errors.confirmPswd}
                helperText={touched.confirmPswd && errors.confirmPswd}
                sx={{ gridColumn: "span 2" }}
              />}
            </Box>
            <Box display="flex" justifyContent="end" mt="20px">
            <Button onClick={resetState} sx={{marginTop:3,borderRadius:3,gridColumn: "span 2"}}
              color="success"  >
                 {isSignup? "Already have an account? Log In" : "Don't have an account? Sign Up"}
              </Button>
              <Button 
                
              endIcon={isSignup ? <HowToRegOutlinedIcon/>:<LoginOutlinedIcon/>}
              variant="contained" 
              color="warning"
              sx={{marginTop:3,borderRadius:3,gridColumn: "span 2"}}
              type="submit" >
              {isSignup? "Create New User":"Login "}
             
              </Button>
            </Box>
          </form>
        )}
      </Formik>
    </Box>
  );
};

const phoneRegExp =
  /^((\+[1-9]{1,4}[ -]?)|(\([0-9]{2,3}\)[ -]?)|([0-9]{2,4})[ -]?)*?[0-9]{3,4}[ -]?[0-9]{3,4}$/;

const checkoutSchema = yup.object().shape({
  
  firstName: yup.string().required("required"),
  lastName: yup.string().required("required"),
  email: yup.string().email("invalid email").required("required"),
  contact: yup
    .string()
    .matches(phoneRegExp, "Phone number is not valid")
    .required("required"),
  address1: yup.string().required("required"),
  address2: yup.string().notRequired(),
  password: yup.string().required("required"),
  userName: yup.string().required("required"),
  confirmPswd: yup.string().required("required"),
});
const checkoutSchema_login = yup.object().shape({
  
  password: yup.string().required("required"),
  userName: yup.string().required("required"),
 
});
const initialValues = {
  firstName: "",
  lastName: "",
  email: "",
  contact: "",
  address1: "",
  address2: "",
  userName: "",
  password: "",
  confirmPswd: "",
};

export default Form;
