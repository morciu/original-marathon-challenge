import React, { useEffect, useState } from "react";
import styles from "./Login.module.css";
import Button from "@mui/material/Button";
import AppRegistrationRoundedIcon from '@mui/icons-material/AppRegistrationRounded';
import TextInput from "../../components/Inputs/TextInput";
import { TextField } from "@mui/material";

const Login = () => {
    const [loginState, setLoginState] = useState({
        "userName": "",
        "password": "",
    });

    return(
        <form className={styles.loginContainer} onSubmit={(e) => {
            e.preventDefault();
            console.log(`userName: ${loginState.userName}`);
            console.log(`password: ${loginState.password}`);
        }}>
            <TextField 
                onChange={(e) => setLoginState({...loginState, "userName": e.target.value})} 
                label="User Name" variant="outlined" />
            
            <TextField
                onChange={(e) => setLoginState({...loginState, "password": e.target.value})} 
                type="password" label="Password" variant="outlined" />

            <Button type="submit" variant="contained">Log In</Button>
            <Button variant="contained" href="/register" 
            startIcon={<AppRegistrationRoundedIcon />}>
                Register</Button>
        </form>
    )
};

export default Login;