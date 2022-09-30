import { Button, Card, CardContent } from "@mui/material";
import React from "react";

const CheckProgress = () => {
    // Request config for axios
    const requestConfig = {
        url: "/marathon/members-by-distance?marathonId=1",
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };
    
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