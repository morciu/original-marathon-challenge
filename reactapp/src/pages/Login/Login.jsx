import React, { useState } from "react";
import styles from "./Login.module.css";
import Button from "@mui/material/Button";
import AppRegistrationRoundedIcon from '@mui/icons-material/AppRegistrationRounded';
import TextInput from "../../components/Inputs/TextInput";
import { TextField } from "@mui/material";

const Login = (props) => {

    const hideLabel = () => {}

    return(
        <>
            <div className={styles.loginContainer}>
                <TextField label="User Name" variant="outlined" />
                <TextField type="password" label="Password" variant="outlined" />
                
                <Button variant="contained">Log In</Button>
                <Button variant="contained" href="/register" 
                startIcon={<AppRegistrationRoundedIcon />}>
                    Register</Button>
            </div>
        </>
    )
};

export default Login;