import { Card, Typography } from "@mui/material";
import React from "react";
import styles from "./MedalCard.module.css";

const MedalCard = (props) => {
    return(
        <Card className={styles.card}>
            <Typography variant="h6">{props.item.id}</Typography>
        </Card>
    );
};

export default MedalCard