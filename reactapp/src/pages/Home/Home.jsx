import Login from "../Login/Login";
import React from "react";
import { Navigate } from "react-router-dom";
import Users from "../../components/Users/Users";
import { Button, Card, CardContent, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import useFetchData from "../../hooks/useFetchData";

const Home = () => {
    const isAuthenticated = !!localStorage.getItem("auth-token");

    

    // Request config for axios
    const requestConfig = {
        url: `/users/${localStorage.id}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    const {data, loading, error} = useFetchData(requestConfig);

    const totalTime = (data) => {
        let total = 0;
    } 

    

    if (isAuthenticated){
        
        return(
            <>
                {loading && <p>Loading...</p>}
                {error && <p>{error.message}</p>}
                {data && 
                <Card>
                    <Typography variant="h5">User Name: {data.userName}</Typography>
                    <Typography variant="h5">Total Distance: {data.totalDistance}</Typography>
                    <Typography variant="h5">Total Time: {data.totalTime}</Typography>
                    <Typography variant="h5">Average Pace: {data.averagePace}</Typography>
                </Card>
                }
            </>
            );
    } else {
        return( <> <Login /> </>)
    }
}

export default Home;