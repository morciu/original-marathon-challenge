import React from "react";

import styles from "./UserCard.module.css"

import { Avatar, Card, CardHeader, Icon, LinearProgress, Typography } from "@mui/material";
import { EmojiEvents } from "@mui/icons-material";
import { Box } from "@mui/system";

const UserCard = (props) => {

    const goalDistance = 240;

    const claculateDistance = (totalDistance) => {
        var finishes = Math.floor(totalDistance / goalDistance);
        var currentDistance = totalDistance - (goalDistance * finishes);
        var currentPercentage = currentDistance / goalDistance * 100;

        return {currentPercentage: currentPercentage, finishes: finishes, currentDistance: currentDistance};
    }
    
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
                <Box className={styles.content}>
                    <Box className={styles.leftContent}>
                        <div className={styles.heading}>
                            <Typography align="center" variant="h5" className={styles.heading}>{props.item.userName}</Typography>
                        </div>
                        
                        <div className={styles.subHeader}>
                            <Typography variant="p" >{claculateDistance(props.item.totalDistance).currentDistance} km</Typography>
                        </div>
                    </Box>
                    <Box className={styles.rightContent}>
                        <Icon><EmojiEvents /> </Icon>x {claculateDistance(props.item.totalDistance).finishes}
                    </Box>
                    
                </Box>
                
                <Box display={'flex'} alignItems={'center'}>
                    <LinearProgress variant="determinate"
                            value={claculateDistance(props.item.totalDistance).currentPercentage} className={styles.progressBar} />
                        <span className={styles.value}>
                            {claculateDistance(props.item.totalDistance).currentPercentage.toFixed(2)}%
                        </span>
                </Box>
            </Box>
        </Card>
    );
};

export default UserCard;