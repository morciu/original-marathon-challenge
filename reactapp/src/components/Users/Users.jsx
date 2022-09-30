import { Favorite } from "@mui/icons-material";
import { Grid, Card, CardContent, Typography, Stack, CardHeader, Avatar, IconButton } from "@mui/material";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";
import UserModal from "../UserModal/UserModal";
import styles from "./Users.module.css"

const Users = () => {
    // Request config for axios
    const requestConfig = {
        url: "/marathon/members-by-distance?marathonId=1",
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    const {data, loading, error} = useFetchData(requestConfig);

    const [modalObject, setmodalObject] = useState({
        id: null,
        userName: null,
        totalDistance: null,
        totalTime: null,
        averagePace: null
    });

    const[openModal, setOpenModal] = useState(false);
    const handleOpenModal = (item) => {
    setmodalObject(item);
    setOpenModal(true);
    }
    const handleCloseModal = () => setOpenModal(false);
    

    // Display Results
    return(
        <>
        <UserModal open={openModal}
            modalObject={modalObject}
            handleCloseModal={handleCloseModal} />

        <Stack spacing={2}>
            {loading && <p>Loading...</p>}
            {error && <p>{error.message}</p>}
            {data && data.map((item) => (
                <Card key={item.id} onClick={() => { handleOpenModal(item) }}>
                    <CardHeader
                        avatar={
                            <Avatar aria-label="recipe" >
                                {item.userName != null && item.userName.substring(0,1)}
                            </Avatar>
                        }
                        action={
                            <IconButton aria-label="settings"><Favorite /></IconButton>
                        }
                        title={item.userName}
                        subheader={item.totalDistance+" km"}
                        />
                </Card>
            ))}
        </Stack>
        </>
    );
};

export default Users;