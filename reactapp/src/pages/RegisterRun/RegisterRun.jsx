import { Button, Stack, TextField } from "@mui/material";
import React from "react";

const RegisterRun = () => {
    return(
        <>
        <Stack>
            <TextField type={"number"} variant="filled" label="Distance"/>
            <TextField type={"text"} variant="outlined" label="Time"
            pattern="[0-9]{2}:[0-9]{2}:[0-9]{2}" value="00:00:00"/>
            <Button variant="contained">Submit</Button>
        </Stack>
            <Button variant="contained">Back</Button>
        </>
    );
};

export default RegisterRun;