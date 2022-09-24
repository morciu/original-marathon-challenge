import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import styles from "./Register.module.css"
import { Alert, Button, Grid, TextField } from "@mui/material";

const requiredFieldRule = {
    required: {
        value: true,
        message: "Field is required!",
    }
};

const Register = () =>{
    const [showAlert, setShowAlert] = useState(false);
    const { register, handleSubmit, formState: { errors } } = useForm();

    const handleFormSubmission = (data) => {
        // Only executed when valid form inputs
        console.log(true);
        console.log(data);
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