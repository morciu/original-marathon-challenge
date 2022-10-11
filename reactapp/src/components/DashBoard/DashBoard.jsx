import { Avatar, Button, IconButton } from "@mui/material";
import React from "react";
import styles from "./DashBoard.module.css";
import NotificationsIcon from '@mui/icons-material/Notifications';
import TimerIcon from '@mui/icons-material/Timer';
import DirectionsRunIcon from '@mui/icons-material/DirectionsRun';
import SpeedIcon from '@mui/icons-material/Speed';
import { Box } from "@mui/system";

const DashBoard = (props) => {
    return(
        <div className={styles.container}>
            <div className={styles.userHeader}>
                <div className={styles.userCont}>
                    <IconButton><Avatar><NotificationsIcon /></Avatar></IconButton>
                    <div>UserName {props.userName}</div>
                </div>
                <Button variant="outlined" size="small" color="secondary">Logout</Button>
            </div>

            <Box className={styles.summary}>
                <div className={styles.time}>
                    <IconButton><Avatar><TimerIcon /></Avatar></IconButton>
                    <div>Time {props.time}</div>
                </div>
                <div className={styles.distance}>
                    <IconButton><Avatar><DirectionsRunIcon /></Avatar></IconButton>
                    <div>Distance {props.distance}</div>
                </div>
                <div className={styles.pace}>
                    <IconButton><Avatar><SpeedIcon /></Avatar></IconButton>
                    <div>Speed {props.speed}</div>
                </div>
            </Box>

            <div className={styles.activitiesButton}>
                <Button variant="contained">All Activities</Button>
            </div>
        </div>
    );
};

export default DashBoard;