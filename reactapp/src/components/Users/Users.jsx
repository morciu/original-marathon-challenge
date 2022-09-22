import { Grid, Card, CardContent, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import useFetchData from "../../hooks/useFetchData";
import styles from "./Users.module.css"

const Users = () => {
    // Request config for axios
    const requestConfig = {
        url: "/users/all-users",
        method: "GET",
    };

    const {data, loading, error} = useFetchData(requestConfig);
    

    // Display Results
    return(
        <Grid container sx={{display: 'grid'}}>
            {loading && <p>Loading...</p>}
            {error && <p>{error.message}</p>}
            {data && data.map((item) => (
                <Grid key={item.id} item xs={8}>
                    <Card>
                        <CardContent>
                            <Typography variant="h5">Username: {item.userName}</Typography>
                            <Typography variant="h5">Total Distance: {item.totalDistance} km</Typography>
                            </CardContent>
                    </Card>
                </Grid>
            ))}
        </Grid>
    );
};

export default Users;