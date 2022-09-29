import { Button, Card, CardContent } from "@mui/material";
import React from "react";

const CheckProgress = () => {
    return(
        <>
            <Card>
                <CardContent>
                    Progress
                </CardContent>
                <CardContent>
                    Goal: 240 km
                </CardContent>
            </Card>
            <Button href="/" variant="contained">Back</Button>
        </>
    );
};

export default CheckProgress;