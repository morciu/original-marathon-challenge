import React from "react";

import styles from "./UserCard.module.css"

import { Avatar, Card, CardHeader, LinearProgress, Typography } from "@mui/material";
import { EmojiEvents } from "@mui/icons-material";
import { Box } from "@mui/system";

const UserCard = (props) => {
    
    return(
        <Card className={styles.card} key={props.item.id} onClick={() => { props.action(props.item) }}>
            <div className={styles.avatarContainer}>
                {
                (props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4) == 1 ?
                    <Avatar aria-label="recipe" className={styles.avatarGold}>
                        {props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4}
                    </Avatar> :
                    (props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4) == 2 ?
                        <Avatar aria-label="recipe" className={styles.avatarSilver}>
                            {props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4}
                        </Avatar> : 
                        (props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4) == 3 ?
                            <Avatar aria-label="recipe" className={styles.avatarBronze}>
                                {props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4}
                            </Avatar> : 
                    <Avatar aria-label="recipe" className={styles.avatar}>
                        {props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4}
                    </Avatar>
                }
                
            </div>
            <Box className={styles.cardInnerContainer}>
                <div className={styles.heading}>
                    <Typography align="center" variant="h5" className={styles.heading}>{props.item.userName}</Typography>
                </div>
                
                <Typography variant="p" className={styles.subHeader}>{props.item.totalDistance} km</Typography>
                
                <Box display={'flex'} alignItems={'center'}>
                    <LinearProgress variant="determinate" 
                      value={props.item.totalDistance / 240 * 100} className={styles.progressBar}/>
                    <span className={styles.value}>{(props.item.totalDistance / 240 * 100).toFixed(2)}%</span>
                </Box>
            </Box>
            {/* <CardHeader
                avatar={
                    <Avatar aria-label="recipe" >
                        {props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4}
                    </Avatar>
                }
                action={props.item.totalDistance >= 240 && <EmojiEvents />}
                title={props.item.userName}
                subheader={props.item.totalDistance+" km"}
                ></CardHeader> */}
        </Card>
    );
};

export default UserCard;