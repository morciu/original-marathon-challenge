import React, { useState } from "react";
import Button from "../Buttons/MainButton";
import TextInput from "../Inputs/TextInput";

const Login = (props) => {
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
                
                <Button type="submit" text="Log In" />
                <Button text="Register" nextPage={props.nextPage} page="register"/>
            </div>
        </>
    )
};

export default Login;