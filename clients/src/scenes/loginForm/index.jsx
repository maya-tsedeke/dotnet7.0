import * as Yup from "yup";
import { Formik, useFormik } from "formik";
import { Button, TextField } from "@mui/material";

const initialValues = {
  firstName: "",
  lastName: "",
  email: "",
};

const onSubmit = (values) => {
  console.log(values);
};

const validationSchema = Yup.object().shape({
  firstName: Yup.string().required("Required"),
  lastName: Yup.string().required("Required"),
  email: Yup.string().email("Invalid email").required("Required"),
});

const ResetButton = ({ formik }) => (
  <Button
    type="button"
    variant="contained"
    color="secondary"
    onClick={formik.resetForm}
  >
    Reset
  </Button>
);

const MyForm = () => {
  const formik = useFormik({
    initialValues,
    onSubmit,
    validationSchema,
  });

  return (
    <form onSubmit={formik.handleSubmit}>
      <TextField
        fullWidth
        variant="filled"
        type="text"
        label="First Name"
        onChange={formik.handleChange}
        onBlur={formik.handleBlur}
        value={formik.values.firstName}
        name="firstName"
        error={formik.touched.firstName && formik.errors.firstName}
        helperText={formik.touched.firstName && formik.errors.firstName}
        sx={{ gridColumn: "span 2" }}
      />

      <TextField
        fullWidth
        variant="filled"
        type="text"
        label="Last Name"
        onChange={formik.handleChange}
        onBlur={formik.handleBlur}
        value={formik.values.lastName}
        name="lastName"
        error={formik.touched.lastName && formik.errors.lastName}
        helperText={formik.touched.lastName && formik.errors.lastName}
        sx={{ gridColumn: "span 2" }}
      />

      <TextField
        fullWidth
        variant="filled"
        type="email"
        label="Email Address"
        onChange={formik.handleChange}
        onBlur={formik.handleBlur}
        value={formik.values.email}
        name="email"
        error={formik.touched.email && formik.errors.email}
        helperText={formik.touched.email && formik.errors.email}
      />

      <Button type="submit" variant="contained" color="primary">
        Submit
      </Button>

      <ResetButton formik={formik} />
    </form>
  );
};

const App = () => {
  return (
    <div>
      <h1>My Form</h1>
      <Formik
        initialValues={initialValues}
        onSubmit={onSubmit}
        validationSchema={validationSchema}
      >
        <MyForm />
      </Formik>
    </div>
  );
};

export default App;
