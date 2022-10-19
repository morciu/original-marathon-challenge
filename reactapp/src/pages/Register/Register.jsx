import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import styles from "./Register.module.css"
import { Alert, Button, Grid, TextField } from "@mui/material";
import axios from "axios";
import { Navigate, useNavigate } from "react-router-dom";
import { sendData } from "../../utils/SendData";
import Login from "../Login/Login";

// Post config for axios
const requestConfig = {
    url: "/account/register",
    payload: "",
    method: "POST",
};
const requiredFieldRule = {
    required: {
        value: true,
        message: "Field is required!",
    }
};



const Register = () =>{
    const [showAlert, setShowAlert] = useState(false);
    const { register, handleSubmit, formState: { errors } } = useForm();

    const [registered, setRegistered] = useState(false);

    // Navigate Hook
    const navigate = useNavigate();
    
    const handleFormSubmission = async (submission) => {
        requestConfig.payload = submission;
        // Clear local storare
        localStorage.clear();

        if (await sendData(requestConfig)){
            setRegistered(true)
            navigate("/login");
        } else {
            console.log("something went wrong!");
        }
    };

    return(
        <>
        {showAlert && (
            <div style={{position: "absolute", top: 0}}>
                <Alert>Submission Successfull!</Alert>
            </div>
        )}
        
        <form className={styles.registerContainer}
            onSubmit={handleSubmit(handleFormSubmission)}>
            <TextField 
                type="text"
                error={!!errors["firstName"]}
                helperText={errors["firstName"]?.message}
                {...register("firstName", {...requiredFieldRule})}
                label="First Name" variant="outlined" />
            <TextField 
                type="text"
                error={!!errors["lastName"]}
                helperText={errors["lastName"]?.message}
                {...register("lastName", {...requiredFieldRule})}
                label="Last Name" variant="outlined" />
            <TextField 
                type="text"
                error={!!errors["userName"]}
                helperText={errors["userName"]?.message}
                {...register("userName", {...requiredFieldRule})}
                label="User Name" variant="outlined" />
            <TextField 
                type="password"
                error={!!errors["password"]}
                helperText={errors["password"]?.message}
                {...register("password", {...requiredFieldRule})}
                label="Password" variant="outlined" />

            <Button type="submit" variant="contained">Register</Button>
        </form>
        </>
    );
};

export default Register;