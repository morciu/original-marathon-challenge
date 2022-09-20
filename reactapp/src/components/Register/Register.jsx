import React from "react";
import Button from "../Buttons/MainButton";
import TextInput from "../Inputs/TextInput";

const Register = (props) =>{

    const style = {
        display: "grid",
        gridTemplateRows: "repeat(5, 1fr)",
        gap: "5px",
        alignItems: "center",
    };

    return(
        <div style={style}>
            <TextInput label="First Name" type="text" />
            <TextInput label="Last Name" type="text" />
            <TextInput label="User Name" type="text" />
            <TextInput label="Password" type="password" />

            <Button type="submit" text="Register" nextPage={props.nextPage} page="login" />
        </div>
    );
};

export default Register;