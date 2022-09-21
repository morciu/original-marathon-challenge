import React, { useState } from "react";
import styles from "./Login.module.css";
import Button from "@mui/material/Button";
import TextInput from "../../components/Inputs/TextInput";

const Login = (props) => {

    return(
        <>
            <div className={styles.loginContainer}>
                <TextInput label="User Name" type="text"/>
                <TextInput label="Password" type="password"/>
                
                <Button variant="contained">Log In</Button>
                <Button href="/register">Register</Button>
            </div>
        </>
    )
};

export default Login;