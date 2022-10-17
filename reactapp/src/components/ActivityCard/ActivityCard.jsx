import { Card, CardActions, IconButton, Typography } from "@mui/material";
import React from "react";
import styles from "./ActivityCard.module.css";
import FavoriteIcon from '@mui/icons-material/Favorite';
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";
import useFetchData from "../../hooks/useFetchData";


const ActivityCard = (props) => {
    const {user} = useContext(UserContext);

    // Request config for user
    const requestConfig = {
        url: `/like/${user.id}/liked-activities`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage.token}`,
        },
    };

    const {data, loading, error} = useFetchData(requestConfig);
    return(
        <>
            <Card className={styles.card}>
                <div className={styles.header}>
                    <Typography variant="h6">{new Date(props.date).toDateString()}, {new Date(props.date).toLocaleTimeString()}</Typography>
                    {data.includes(props.activityId) ? 
                        <IconButton color="red" aria-label="add to favorites">
                            <FavoriteIcon />
                        </IconButton> : 
                        <IconButton aria-label="add to favorites">
                            <FavoriteIcon />
                        </IconButton>}
                    <Typography variant="p">{props.likes}</Typography>
                </div>

                <div className={styles.summary}>
                    <div className={styles.distanceContainer}>
                        <Typography variant="p">Distance</Typography>
                        <Typography variant="p">{props.distance}km</Typography>
                    </div>
                    <div className={styles.timeContainer}>
                        <Typography variant="p">Time</Typography>
                        <Typography variant="p">{props.time}</Typography>
                    </div>
                    <div className={styles.paceContainer}>
                        <Typography variant="p">Pace</Typography>
                        <Typography variant="p">{props.pace.slice(3)}</Typography>
                    </div>
                </div>
            </Card>
        </>
    );
};

export default ActivityCard;