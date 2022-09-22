import { Grid } from "@mui/material";
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
        <Grid container>
            {loading && <p>Loading...</p>}
            {error && <p>{error.message}</p>}
            {data && data.map((item) => (
                <Grid item xs={8}>
                    <div className={styles.userContainer} key={item.id}>{item.userName}</div>
                </Grid>
            ))}
        </Grid>
    );
};

export default Users;