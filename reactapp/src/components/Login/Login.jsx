import React, { useState } from "react";
import Button from "../Buttons/MainButton";
import TextInput from "../Inputs/TextInput";

const Login = (props) => {
    /* Test event */
    const buttonClicked = () => {
        console.log("Log in button Clicked");
    };

    const style = {
        display: "grid",
        gridTemplateRows: "repeat(4, 1fr)",
        gap: "5px",
        alignItems: "center",
    };

    return(
        <>
            <div style={style}>
                <TextInput label="User Name" type="text"/>
                <TextInput label="Password" type="password"/>
                
                <Button type="submit" text="Log In" clickEvent={buttonClicked} />
                <Button text="Register" />
            </div>
        </>
    )
};

export default Login;