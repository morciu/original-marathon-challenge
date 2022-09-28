import { Typography } from "@mui/material";
import React from "react";
import { Link } from "react-router-dom";

const Header = () => {
    return(
        <>
            <div className="header">
            <Typography component={Link} to="/" className="title" variant="h2">Marathon Tracker</Typography>
            </div>
        </>
    );
}

export default Header;