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

    const checkIfFinished = (totalDistance) => {
        var percentage = totalDistance / goalDistance * 100;
        if (percentage >= 100) {
            return true;
        }
        return false;
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
                            {checkIfFinished(props.item.totalDistance) ? 
                            <Typography variant="p" >{goalDistance} km</Typography> :
                            <Typography variant="p" >{props.item.totalDistance} km</Typography>}
                            
                        </div>
                    </Box>
                    <Box className={styles.rightContent}>
                        {checkIfFinished(props.item.totalDistance) &&
                        <Icon><EmojiEvents /> </Icon>}
                    </Box>
                    
                </Box>
                
                <Box display={'flex'} alignItems={'center'}>
                    {checkIfFinished(props.item.totalDistance) ? 
                    <>
                        <LinearProgress variant="determinate"
                            value={100} className={styles.progressBar} />
                            <span className={styles.value}>
                                100%
                            </span> </> :
                           <> <LinearProgress variant="determinate"
                            value={props.item.totalDistance / goalDistance * 100} className={styles.progressBar} />
                        <span className={styles.value}>
                            {(props.item.totalDistance / goalDistance * 100).toFixed(2)}%
                        </span> </>
                    }
                    
                </Box>
            </Box>
        </Card>
    );
};

export default UserCard;