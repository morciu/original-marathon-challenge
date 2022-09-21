import React from "react";
import styles from "./Register.module.css";
import Button from "@mui/material/Button";
import TextInput from "../../components/Inputs/TextInput";

const Register = (props) =>{

    return(
        <div className={styles.registerContainer}>
            <TextInput label="First Name" type="text" />
            <TextInput label="Last Name" type="text" />
            <TextInput label="User Name" type="text" />
            <TextInput label="Password" type="password" />

            <Button variant="contained">Register</Button>
        </div>
    );
};

export default Register;