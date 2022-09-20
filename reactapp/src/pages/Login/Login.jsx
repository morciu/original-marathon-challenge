import React, { useState } from "react";
import styles from "./Login.module.css";
import Button from "../../components/Buttons/MainButton";
import TextInput from "../../components/Inputs/TextInput";

const Login = (props) => {

    return(
        <>
            <div className={styles.loginContainer}>
                <TextInput label="User Name" type="text"/>
                <TextInput label="Password" type="password"/>
                
                <Button type="submit" text="Log In" />
                <Button text="Register" nextPage={props.nextPage} page="register"/>
            </div>
        </>
    )
};

export default Login;