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
        <div>
            <ul>
            {loading && <p>Loading...</p>}
            {error && <p>{error.message}</p>}
            {data && data.map((item) => (
                <li key={item.id}>{item.userName}</li>
            ))}
            </ul>
        </div>
    );
};

export default Users;