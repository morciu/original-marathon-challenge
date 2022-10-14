import Login from "../Login/Login";
import React from "react";
import { Backdrop, Button, Card, CardContent, CircularProgress, TextField, Typography } from "@mui/material";
import useFetchData from "../../hooks/useFetchData";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";
import useCheckInvitations from "../../hooks/useCheckInvitations";
import { Link } from "react-router-dom";
import DashBoard from "../../components/DashBoard/DashBoard";

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
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={loading}
            >
                <CircularProgress color="inherit" />
            </Backdrop>
                {data.data && 
                <DashBoard userName={data.data.userName}
                time={data.data.totalTime}
                distance={data.data.totalDistance}
                pace={data.data.averagePace}
                medals={data.data.medals}
                invitations={invData.length != 0} />
                }
            </>
            );
    } else {
        return( <> <Login /> </>)
    }
}

export default Home;