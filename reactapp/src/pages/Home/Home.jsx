import Login from "../Login/Login";
import React from "react";
import { Navigate } from "react-router-dom";
import Users from "../../components/Users/Users";
import { Button, Card, CardContent, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import useFetchData from "../../hooks/useFetchData";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";

const Home = () => {
    const {user} = useContext(UserContext);
    
    // Request config for axios
    const requestConfig = {
        url: `/users/${localStorage.id}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    const {data, loading, error} = useFetchData(requestConfig);

    if (user.auth){
        return(
            <>
                {loading && <p>Loading...</p>}
                {error && <p>{error.message}</p>}
                {data && 
                <Card>
                    <CardContent>
                        <Typography variant="h5">User Name: {data.userName}</Typography>
                    </CardContent>
                    <CardContent>
                        <Typography variant="h5">Total Distance: {data.totalDistance}</Typography>
                    </CardContent>
                    <CardContent>
                        <Typography variant="h5">Total Time: {data.totalTime}</Typography>
                    </CardContent>
                    <CardContent>
                        <Typography variant="h5">Average Pace: {data.averagePace}</Typography>
                    </CardContent>
                </Card>
                }
            </>
            );
    } else {
        return( <> <Login /> </>)
    }
}

export default Home;