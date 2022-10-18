import { Avatar, Button, Card, CardActionArea, CardHeader, Typography } from "@mui/material";
import React from "react";
import styles from "./MedalCard.module.css";
import TimerIcon from '@mui/icons-material/Timer';
import DirectionsRunIcon from '@mui/icons-material/DirectionsRun';
import { Link } from "react-router-dom";




const MedalCard = (props) => {
    return(
        <Card className={styles.card}>
            <div className={styles.header}>
                <CardHeader title={<Typography variant="h6">{new Date(props.item.date).toDateString()}</Typography>}></CardHeader>
            </div>
            
            <div className={styles.summary}>
                <div>
                    <Avatar><TimerIcon /></Avatar>
                    <Typography variant="p">{props.item.time}</Typography></div>
                <div>
                    <Avatar><DirectionsRunIcon /></Avatar>
                    <Typography variant="p">{(props.item.pace).slice(3)}</Typography>
                </div>
            </div>
            <CardActionArea className={styles.button}>
                <Button component={Link} to={`/marathon/${props.item.marathonId}`}>
                    <Typography variant="p">Check Event</Typography>
                </Button>
            </CardActionArea>
        </Card>
    );
};

export default MedalCard