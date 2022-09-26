import Login from "../Login/Login";
import React from "react";
import { Navigate } from "react-router-dom";
import Users from "../../components/Users/Users";
import { Button, TextField } from "@mui/material";
import { Stack } from "@mui/system";

const Home = () => {
    const isAuthenticated = !!localStorage.getItem("auth-token");
    console.log(localStorage);

    if (isAuthenticated){
        
        return(
            <>
                <Button variant="contained" href="/register-run">Register Run</Button>
                <Button variant="contained" href="check-progress">Check Progress</Button>
                <Button variant="contained" href="/users">Global Leaderboard</Button>
                <Button variant="contained">Private Marathons</Button>
            </>
            );
    } else {
        return( <> <Login /> </>)
    }
}

export default Home;