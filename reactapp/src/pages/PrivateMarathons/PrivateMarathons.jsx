import { Button, Card, CardContent, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import React from "react";
import useFetchData from "../../hooks/useFetchData";
import { postData } from "../../utils/PostData";

const PrivateMarathons = () => {
    // Request config for axios
    const requestConfig = {
        url: `/users/${localStorage.id}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };
    // Post config for axios
    const postConfig = {
        url: "/marathon/create-marathon",
        payload: { "firstUserId": localStorage.id },
        method: "POST",
    };

    const newPrivateMarathon = () => { postData(postConfig) }

    const {data, loading, error} = useFetchData(requestConfig);

    return(
        <Stack spacing={2}>
            <Button variant="contained" onClick={newPrivateMarathon}>Start a Private Marathon</Button>
            {loading && <p>Loading...</p>}
            {error && <p>{error.message}</p>}
            {data.marathons && data.marathons.map((item) => (
                <>
                {item.id > 1 ?
                    <Stack item key={item.id}>
                    <Card>
                    <CardContent>
                        <Typography variant="h5">Start Date: {item.startDate}</Typography>
                    </CardContent>
                    </Card>             
                </Stack> : null}
                </>
            ))}
        </Stack>
    );
};

export default PrivateMarathons;