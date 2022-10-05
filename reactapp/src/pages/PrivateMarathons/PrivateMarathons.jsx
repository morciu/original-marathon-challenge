import { Backdrop, Button, Card, CardActionArea, CardContent, CardHeader, CircularProgress, Icon, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import React from "react";
import useFetchData from "../../hooks/useFetchData";
import { sendData } from "../../utils/SendData";
import { Link } from "react-router-dom";
import { OpenInFull } from "@mui/icons-material";

const PrivateMarathons = () => {
    // Request config for axios
    const requestConfig = {
        url: `/users/${localStorage.id}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };
    // Post config for axios
    const postConfig = {
        url: "/marathon/create-marathon",
        payload: { "firstUserId": localStorage.id },
        method: "POST",
    };

    const newPrivateMarathon = () => { sendData(postConfig) }

    const {data, loading, error} = useFetchData(requestConfig);

    return(
        <>
        <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
            open={loading}
        >
            <CircularProgress color="inherit" />
        </Backdrop>
        <Stack spacing={2}>
            <Button variant="contained" onClick={newPrivateMarathon}>Start a Private Marathon</Button>
            {error && <p>{error.message}</p>}
            {data.marathons && data.marathons.map((item) => (
                <>
                {item.id > 1 ?
                <Card key={item.id} component={Link} to={`/marathon/${item.id}`} >
                    <CardHeader
                        title={"Members: " + item.memberCount}
                        subheader={"Started on: "+ (new Date(item.startDate)).toDateString() }
                        />
                </Card> : null}
                </>
            ))}
        </Stack>
        </>
    );
};

export default PrivateMarathons;