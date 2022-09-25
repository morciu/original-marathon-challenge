import { Grid, Card, CardContent, Typography, Stack } from "@mui/material";
import React, { useEffect, useState } from "react";
import useFetchData from "../../hooks/useFetchData";
import styles from "./Users.module.css"

const Users = () => {
    // Request config for axios
    const requestConfig = {
        url: "/users/all-users",
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    const {data, loading, error} = useFetchData(requestConfig);
    

    // Display Results
    return(
        <Stack spacing={2}>
                {loading && <p>Loading...</p>}
                {error && <p>{error.message}</p>}
                {data && data.map((item) => (
                <Stack item key={item.id}>
                    <Card>
                        <CardContent>
                            <Typography variant="h5">Username: {item.userName}</Typography>
                            <Typography variant="h5">Total Distance: {item.totalDistance} km</Typography>
                        </CardContent>
                    </Card>
                </Stack>
            ))}
        </Stack>
    );
};

export default Users;