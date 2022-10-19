import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { Alert, Button, Grid, TextField } from "@mui/material";
import styles from "./Login.module.css";
import AppRegistrationRoundedIcon from '@mui/icons-material/AppRegistrationRounded';
import { loginUser } from "../../utils/SendData";
import useFetchData from "../../hooks/useFetchData";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { Navigate } from "react-router-dom";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";

// Post config for axios
const requestConfig = {
    url: "/account/authenticate",
    payload: "",
    method: "POST",
};

const requiredFieldRule = {
    required: {
        value: true,
        message: "Field is required!",
    }
};

const Login = (props) => {
    const navigate = useNavigate();
    const {user} = useContext(UserContext)
    // Prepare hooks
    const [showAlert, setShowAlert] = useState(false);
    const { register, handleSubmit, formState: { errors, isSubmitSuccessful } } = useForm();
    const { login } = useContext(UserContext);
    const [ userName, setUserName ] = useState();

    const handleFormSubmission = async(submission) => {
        // Clear local storare
        localStorage.clear();
        requestConfig.payload = submission;
        
        if(await login(requestConfig)){
            navigate("/");
            console.log("all good")
            setShowAlert(false)
        } else {
            console.log("something went wrong")
            setShowAlert(true)
        }
    };

    return(
        <>
        {showAlert && (
            <Alert sx={{position: "absolute", top: 0}} severity="error">Invalid Login!</Alert>
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