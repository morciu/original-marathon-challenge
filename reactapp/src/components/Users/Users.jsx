import React, { useEffect, useState } from "react";
import styles from "./Users.module.css"

const Users = () => {

    // States
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [items, setItems] = useState([]);

    // Fetch data
    useEffect(() => {
        fetch("/users/all-users")
        .then(result => result.json())
        .then(
            (result) => {
                setIsLoaded(true);
                setItems(result);
            },
            // Error handling
            (error) => {
                setIsLoaded(true);
                setError(error);
            }
        )
    }, []);

    // Display Results
    if (error) {
        return(
            <div>Error: {error.message}</div>
        );
    } else if (!isLoaded) {
        return(
            <div>Loading...</div>
        );
    } else {
        return(
            <ul>
                {items.map((item) => (
                    <li key={item.id}>{item.userName}</li>
                ))}
            </ul>
        );
    }
};

export default Users;