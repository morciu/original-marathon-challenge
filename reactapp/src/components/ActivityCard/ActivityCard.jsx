import { Card, Typography } from "@mui/material";
import React from "react";
import styles from "./ActivityCard.module.css";

const ActivityCard = (props) => {
    return(
        <>
            <Card className={styles.card}>
                <div className={styles.header}>
                    <Typography variant="h5">{new Date(props.date).toDateString()}, {new Date(props.date).toLocaleTimeString()}</Typography>
                </div>

                <div className={styles.summary}>
                    <div className={styles.distanceContainer}>
                        <Typography variant="h6">Distance</Typography>
                        <Typography variant="h6">{props.distance}km</Typography>
                    </div>
                    <div className={styles.timeContainer}>
                        <Typography variant="h6">Time</Typography>
                        <Typography variant="h6">{props.time}</Typography>
                    </div>
                    <div className={styles.paceContainer}>
                        <Typography variant="h6">Pace</Typography>
                        <Typography variant="h6">{props.pace.slice(3)}</Typography>
                    </div>
                </div>
            </Card>
        </>
    );
};

export default ActivityCard;