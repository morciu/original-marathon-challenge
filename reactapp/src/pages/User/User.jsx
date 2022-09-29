import { Card, Typography } from "@mui/material";
import React from "react";
import { useParams } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";
import Login from "../Login/Login";


const User = () => {
    const isAuthenticated = !!localStorage.getItem("auth-token");

    const params = useParams();
    
    // Request config for axios
    const requestConfig = {
        url: `/users/${params.userId}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    const {data, loading, error} = useFetchData(requestConfig);

    const totalTime = (data) => {
        let total = 0;
    }   
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

};

export default User;