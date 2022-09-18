import React, { useState } from "react";
import Button from "../Buttons/MainButton";
import TextInput from "../Inputs/TextInput";
import PasswordInput from "../Inputs/PasswordInput";

const Login = (props) => {
    /* Test event */
    const buttonClicked = () => {
        console.log("Log in button Clicked");
    };

    return(
        <>
            <div className="login-form">
                <TextInput userNameLabel="User Name" />
                <PasswordInput passwordLabel="Password"/>
                
                <Button clickEvent={buttonClicked} />
            </div>
        </>
    )
};

export default Login;