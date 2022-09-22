import React from "react";
import styles from "./Register.module.css";
import Button from "@mui/material/Button";
import TextInput from "../../components/Inputs/TextInput";
import { TextField } from "@mui/material";

const Register = (props) =>{

    return(
        <div className={styles.registerContainer}>
            <TextField label="First Name" variant="outlined" />
            <TextField label="Last Name" variant="outlined" />
            <TextField label="User Name" variant="outlined" />
            <TextField type="password" label="Password" variant="outlined" />

            <Button variant="contained">Register</Button>
        </div>
    );
};

export default Register;