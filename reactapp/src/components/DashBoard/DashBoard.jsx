import { Avatar, Button, IconButton, Typography } from "@mui/material";
import React from "react";
import styles from "./DashBoard.module.css";
import NotificationsIcon from '@mui/icons-material/Notifications';
import TimerIcon from '@mui/icons-material/Timer';
import DirectionsRunIcon from '@mui/icons-material/DirectionsRun';
import SpeedIcon from '@mui/icons-material/Speed';
import EmojiEventsIcon from '@mui/icons-material/EmojiEvents';
import { Box } from "@mui/system";
import { Link } from "react-router-dom";

import {logout} from "../../utils/Logout"
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";


const DashBoard = (props) => {
    const {user} = useContext(UserContext);
    return(
        <div className={styles.container}>
            <div className={styles.userHeader}>
                <div className={styles.userCont}>
                    {props.invitations == true ?
                    <IconButton component={Link} to="/invitations"><Avatar color={"red"}><NotificationsIcon color="red" /></Avatar></IconButton> :
                    <IconButton component={Link} to="/invitations"><Avatar><NotificationsIcon /></Avatar></IconButton>}
                    
                    <div>
                        <Typography variant="h5">{props.userName}</Typography>
                    </div>

                    <div>
                        <IconButton component={Link} to={`/${user.id}/medals`}><EmojiEventsIcon /></IconButton><Typography variant="p">{props.medals.length}</Typography> 
                    </div>
                </div>
                <Button variant="contained" size="small" color="secondary"
                onClick={logout}>Logout</Button>
            </div>

            <Box className={styles.summary}>
                <div className={styles.time}>
                    <IconButton><Avatar><TimerIcon /></Avatar></IconButton>
                    <Typography variant="h5">Total Time: {props.time}</Typography>
                </div>
                <div className={styles.distance}>
                    <IconButton><Avatar><DirectionsRunIcon /></Avatar></IconButton>
                    <Typography variant="h5">Total Distance: {props.distance} km</Typography>
                </div>
                <div className={styles.pace}>
                    <IconButton><Avatar><SpeedIcon /></Avatar></IconButton>
                    <Typography variant="h5">Avg Pace: {props.pace.slice(3)} min/km</Typography>
                </div>
            </Box>

            <div className={styles.activitiesButton}>
                <Button variant="contained" component={Link} to={`/${user.id}/activities`}>All Activities</Button>
            </div>
        </div>
    );
};

export default DashBoard;