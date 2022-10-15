import { ClassNames } from "@emotion/react";
import { Button } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import styles from "./MarathonFilters.module.css";

const MarathonFilters = (props) => {
    return(
        <Box className={styles.container}>
            {props.currentFilter == "all" && 
            <>
            <Button variant="contained" color="secondary" onClick={props.all}>All</Button>
            <Button variant="contained" onClick={props.active}>Active</Button>
            <Button variant="contained" onClick={props.finished}>Finished</Button>
            </>
            }
            {props.currentFilter == "active" && 
            <>
            <Button variant="contained" onClick={props.all}>All</Button>
            <Button variant="contained" color="secondary" onClick={props.active}>Active</Button>
            <Button variant="contained" onClick={props.finished}>Finished</Button>
            </>
            }
            {props.currentFilter == "finished" && 
            <>
            <Button variant="contained" onClick={props.all}>All</Button>
            <Button variant="contained" onClick={props.active}>Active</Button>
            <Button variant="contained" color="secondary" onClick={props.finished}>Finished</Button>
            </>
            }
        </Box>
    );
};

export default MarathonFilters;