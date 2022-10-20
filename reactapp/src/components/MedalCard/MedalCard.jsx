import { Avatar, Button, Card, CardActionArea, CardHeader, Typography } from "@mui/material";
import React from "react";
import styles from "./MedalCard.module.css";
import TimerIcon from '@mui/icons-material/Timer';
import DirectionsRunIcon from '@mui/icons-material/DirectionsRun';
import { Link } from "react-router-dom";
import SpeedIcon from '@mui/icons-material/Speed';


const MedalCard = (props) => {
    return(
        <Card className={styles.card}>
            <div className={styles.header}>
                <CardHeader title={<Typography variant="h6">{new Date(props.item.date).toDateString()}</Typography>}></CardHeader>
            </div>
            
            <div className={styles.summary}>
                <div>
                    <Avatar sx={{backgroundColor: "#92140c"}}><TimerIcon /></Avatar>
                    <Typography variant="p">{props.item.time}</Typography></div>
                <div>
                    <Avatar Avatar sx={{backgroundColor: "#4B624B"}}><SpeedIcon /></Avatar>
                    <Typography variant="p">{(props.item.pace).slice(3)}</Typography>
                </div>
            </div>
            <CardActionArea className={styles.button}>
                <Button sx={{display: "flex", justifyContent: "center"}} component={Link} to={`/marathon/${props.item.marathonId}`}>
                    <Typography variant="p">Check Event</Typography>
                </Button>
            </CardActionArea>
        </Card>
    );
};

export default MedalCard