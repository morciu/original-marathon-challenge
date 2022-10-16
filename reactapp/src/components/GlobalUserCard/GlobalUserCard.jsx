import React from "react";

import styles from "./GlobalUserCard.module.css"

import { Avatar, Card, CardHeader, Icon, LinearProgress, Typography } from "@mui/material";
import { EmojiEvents } from "@mui/icons-material";
import { Box } from "@mui/system";

const GlobalUserCard = (props) => {
    
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
                            <Typography variant="p" >{props.item.totalDistance} km</Typography>
                        </div>
                    </Box>
                    <Box className={styles.rightContent}>
                        <Typography variant="p">{props.item.medals.length}X</Typography><Icon><EmojiEvents /> </Icon>
                    </Box>
                    
                </Box>
                
                <Box display={'flex'} alignItems={'center'}>
                    
                </Box>
            </Box>
        </Card>
    );
};

export default GlobalUserCard;