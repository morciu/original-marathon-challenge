import Login from "../Login/Login";
import React from "react";
import { Navigate } from "react-router-dom";
import Users from "../../components/Users/Users";
import { Button, Card, CardContent, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import useFetchData from "../../hooks/useFetchData";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";
import axios from "axios";
import useCheckInvitations from "../../hooks/useCheckInvitations";
import { useEffect } from "react";
import { Link } from "react-router-dom";

const Home = () => {
    const {user} = useContext(UserContext);
    
    // Request config for user
    const requestConfig = {
        url: `/users/${localStorage.id}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    // Request config for invitations
    const requestConfigInvitations = {
        url: `/invitation/unanswered/${user.id}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    }

    const {data, loading, error} = useFetchData(requestConfig);
    const {invData, invLoading, invError} = useCheckInvitations(requestConfigInvitations);    

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
                {invData.length != 0 ?
                <Button variant="contained" color="error" component={Link} to="/invitations">Invitations</Button> :
                <Button variant="contained" component={Link} to="/invitations">Invitations</Button>
                }
            </>
            );
    } else {
        return( <> <Login /> </>)
    }
}

export default Home;