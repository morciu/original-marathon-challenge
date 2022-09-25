import { Button, TextField } from "@mui/material";
import React from "react";

const RegisterRun = () => {
    return(
        <>
            <TextField variant="outlined" label="Distance"/>
            <TextField variant="outlined" label="Time"/>
            <Button variant="contained">Submit</Button>
            <Button variant="contained">Back</Button>
        </>
    );
};

export default RegisterRun;