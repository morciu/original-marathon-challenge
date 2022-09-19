import React, { useState } from "react";
import Button from "../Buttons/MainButton";
import TextInput from "../Inputs/TextInput";

const Login = (props) => {
    /* Test event */
    const buttonClicked = () => {
        console.log("Log in button Clicked");
    };

    return(
        <>
            <div className="login-form">
                <TextInput userNameLabel="User Name" type="text"/>
                <TextInput userNameLabel="Password" type="password"/>
                
                <Button clickEvent={buttonClicked} />
            </div>
        </>
    )
};

export default Login;