import { Card, CardActions, IconButton, Typography } from "@mui/material";
import React from "react";
import styles from "./ActivityCard.module.css";
import FavoriteIcon from '@mui/icons-material/Favorite';


const ActivityCard = (props) => {
    console.log(props)
    return(
        <>
            <Card className={styles.card}>
                <div className={styles.header}>
                    <Typography variant="h6">{new Date(props.date).toDateString()}, {new Date(props.date).toLocaleTimeString()}</Typography>
                    <IconButton aria-label="add to favorites">
                        <FavoriteIcon /> <Typography variant="p">{props.likes}</Typography>
                    </IconButton>
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