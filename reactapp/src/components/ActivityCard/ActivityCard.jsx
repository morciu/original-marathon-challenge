import { Card, CardActions, IconButton, Typography } from "@mui/material";
import React from "react";
import styles from "./ActivityCard.module.css";
import FavoriteIcon from '@mui/icons-material/Favorite';
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";
import useFetchData from "../../hooks/useFetchData";
import { sendData } from "../../utils/SendData";
import { useState } from "react";

const summaryItem = {
    display: "grid",
    alignItems: "center"
};

const ActivityCard = (props) => {
    const {user} = useContext(UserContext);

    // Request config for user
    const [requestConfig, setRequestConfig] = useState(
        {
            url: `/like/${user.id}/liked-activities`,
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage.token}`,
            },
        }
    );

    // Request config for creating like
    const requestConfigCreateLike = {
        url: `/like/create-like`,
        payload: "",
        method: "POST",
        headers: {
            Authorization: `Bearer ${localStorage.token}`,
        },
    };

    // Request config for removing like
    const requestConfigRemoveLike = {
        url: `/like/delete-like`,
        payload: "",
        method: "DELETE",
        headers: {
            Authorization: `Bearer ${localStorage.token}`,
        },
    };

    const createLike = async () => {
        requestConfigCreateLike.payload = { "senderId":  user.id, "activityId": props.activityId};

        if (await sendData(requestConfigCreateLike)){
            console.log("All Good!");
            setRequestConfig({
                url: `/like/${user.id}/liked-activities`,
                method: "GET",
                headers: {
                    Authorization: `Bearer ${localStorage.token}`,
                },
            });
            props.setNeedsUpdate(!props.needsUpdate);
        } else {
            console.log("something went wrong!");
        }
    }

    const deleteLike = async () => {
        requestConfigRemoveLike.payload = { "senderId":  user.id, "activityId": props.activityId};

        if (await sendData(requestConfigRemoveLike)){
            console.log("All Good!");
            setRequestConfig({
                url: `/like/${user.id}/liked-activities`,
                method: "GET",
                headers: {
                    Authorization: `Bearer ${localStorage.token}`,
                },
            });
            props.setNeedsUpdate(!props.needsUpdate);
        } else {
            console.log("something went wrong!");
        }
    };

    const {data, loading, error} = useFetchData(requestConfig, props.needsUpdate);
    
    return(
        <>
            <Card className={styles.card}>
                <div className={styles.header}>
                    <Typography variant="h6">
                        {new Date(props.date).toDateString()}, {new Date(props.date).toLocaleTimeString()}
                    </Typography>
                    {data.includes(props.activityId) ? 
                        <><IconButton color="red" aria-label="add to favorites" onClick={deleteLike}>
                            <FavoriteIcon />
                        </IconButton> <Typography variant="p">{props.likes}</Typography></> : 
                        <><IconButton aria-label="add to favorites" onClick={createLike}>
                            <FavoriteIcon />
                        </IconButton> <Typography variant="p">{props.likes}</Typography></>}
                    
                </div>

                <div className={styles.summary}>
                    <div style={summaryItem}>
                        <Typography variant="p">Distance</Typography>
                        <Typography variant="p">{props.distance}km</Typography>
                    </div>
                    <div style={summaryItem}>
                        <Typography variant="p">Time</Typography>
                        <Typography variant="p">{props.time}</Typography>
                    </div>
                    <div style={summaryItem}>
                        <Typography variant="p">Pace</Typography>
                        <Typography variant="p">{props.pace.slice(3)}</Typography>
                    </div>
                </div>
            </Card>
        </>
    );
};

export default ActivityCard;