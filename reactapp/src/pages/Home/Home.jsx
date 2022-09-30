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
                        <Typography variant="h5">Hello {data.userName}!</Typography>
                    </CardContent>
                    <CardContent>
                        <Typography variant="h5">You have run a total distance of {data.totalDistance}km and your total time spent running is {data.totalTime}.</Typography>
                        <Typography variant="h5">Your average running pace is {data.averagePace} min/km.</Typography>
                    </CardContent>
                    <CardContent>
                        <Typography variant="h5">Pretty good! Keep going!</Typography>
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