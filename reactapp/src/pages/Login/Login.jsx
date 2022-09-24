import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { Alert, Button, Grid, TextField } from "@mui/material";
import styles from "./Login.module.css";
import AppRegistrationRoundedIcon from '@mui/icons-material/AppRegistrationRounded';
import usePostHook from "../../hooks/usePostHook";
import useFetchData from "../../hooks/useFetchData";
import axios from "axios";

// Post config for axios
const requestConfig = {
    url: "/account/authenticate",
    payload: "",
    method: "POST",
};

let loginStatus = false;

const requiredFieldRule = {
    required: {
        value: true,
        message: "Field is required!",
    }
};

const handleFormSubmission = async(submission) => {
    // Only executed when valid form inputs
    requestConfig.payload = submission;
    try {
        const response = await axios({
            method: requestConfig.method,
            url: requestConfig.url,
            data: requestConfig.payload,
            headers: { "Content-Type": "application/json" }
        }
        );
        loginStatus = true;
    } catch(error) {
        console.log(error)
        loginStatus = false;
    }

    console.log(loginStatus);
};



const Login = () => {
    

    const [showAlert, setShowAlert] = useState(false);
    const { register, handleSubmit, formState: { errors } } = useForm();

    

    return(
        <>
        {showAlert && (
            <div style={{position: "absolute", top: 0}}>
                <Alert>Submission Successfull!</Alert>
            </div>
        )}
        <form className={styles.loginContainer} onSubmit={handleSubmit(handleFormSubmission)}
            action={requestConfig.url} method={requestConfig.method}>
            <TextField 
                type="text"
                error={!!errors['userName']}
                helperText={errors["userName"]?.message}
                {...register("userName", {...requiredFieldRule})}
                label="User Name" variant="outlined" />
            
            <TextField
                type="password"
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