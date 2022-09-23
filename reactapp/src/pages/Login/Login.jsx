import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { Alert, Button, Grid, TextField } from "@mui/material";
import styles from "./Login.module.css";
import AppRegistrationRoundedIcon from '@mui/icons-material/AppRegistrationRounded';
import TextInput from "../../components/Inputs/TextInput";

const requiredFieldRule = {
    required: {
        value: true,
        message: "Field is required!",
    }
};

const Login = () => {
    const [showAlert, setShowAlert] = useState(false);
    const { register, handleSubmit, formState: { errors } } = useForm();

    const handleFormSubmission = () => {
        // Only executed when valid form inputs
        setShowAlert(true)
    };

    return(
        <>
        {showAlert && (
            <div style={{position: "absolute", top: 0}}>
                <Alert>Submission Successfull!</Alert>
            </div>
        )}
        <form className={styles.loginContainer} onSubmit={handleSubmit(handleFormSubmission)}>
            <TextField 
                type="text"
                error={!!errors['userName']}
                helperText={errors["userName"]?.message}
                {...register("userName", {...requiredFieldRule})}
                label="User Name" variant="outlined" />
            
            <TextField
                type="text"
                error={!!errors['password']}
                helperText={errors["password"]?.message}
                {...register("password", {...requiredFieldRule})}
                label="Password" variant="outlined" />            
            

            <Button type="submit" variant="contained">Log In</Button>
            <Button variant="contained" href="/register" 
            startIcon={<AppRegistrationRoundedIcon />}>
                Register</Button>
        </form>
        </>
    )
};

export default Login;