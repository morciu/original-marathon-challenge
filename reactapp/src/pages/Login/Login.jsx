import React, { useState } from "react";
import styles from "./Login.module.css";
import Button from "@mui/material/Button";
import AppRegistrationRoundedIcon from '@mui/icons-material/AppRegistrationRounded';
import TextInput from "../../components/Inputs/TextInput";

const Login = (props) => {

    return(
        <>
            <div className={styles.loginContainer}>
                <TextInput label="User Name" type="text"/>
                <TextInput label="Password" type="password"/>
                
                <Button variant="contained">Log In</Button>
                <Button variant="outlined" href="/register" startIcon={<AppRegistrationRoundedIcon />}>
                    Register</Button>
            </div>
        </>
    )
};

export default Login;