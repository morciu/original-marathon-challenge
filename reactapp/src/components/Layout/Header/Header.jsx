import { Typography } from "@mui/material";
import React from "react";
import { Link } from "react-router-dom";
import styles from "./Header.module.css";

const Header = () => {
    
    return(
        <>
            <div className={styles.header}>
                <Typography component={Link} to="/" variant="h2" style={{ textDecoration: 'none' }}>
                    Pheidippides' Marathon
                </Typography>
            </div>
        </>
    );
}

export default Header;