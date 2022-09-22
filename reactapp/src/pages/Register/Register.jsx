import React, { useEffect, useState } from "react";
import styles from "./Register.module.css"
import Button from "@mui/material/Button";
import TextInput from "../../components/Inputs/TextInput";
import { TextField } from "@mui/material";

const Register = (props) =>{

    const [registerState, setRegisterState ] = useState({
        "firstName": "",
        "lastName": "",
        "userName": "",
        "password": "",
    });

    return(
        <form className={styles.registerContainer}
            onSubmit={(e) => {
                e.preventDefault();
                console.log(registerState);
            }}>
            <TextField 
                onChange={(e) => {setRegisterState({...registerState, "firstName": e.target.value})}}
                label="First Name" variant="outlined" />
            <TextField 
                onChange={(e) => {setRegisterState({...registerState, "lastName": e.target.value})}}
                label="Last Name" variant="outlined" />
            <TextField 
                onChange={(e) => {setRegisterState({...registerState, "userName": e.target.value})}}
                label="User Name" variant="outlined" />
            <TextField 
                onChange={(e) => {setRegisterState({...registerState, "password": e.target.value})}}
                type="password" label="Password" variant="outlined" />

            <Button type="submit" variant="contained">Register</Button>
        </form>
    );
};

export default Register;