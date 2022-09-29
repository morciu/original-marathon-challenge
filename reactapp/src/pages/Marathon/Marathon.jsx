import React from "react";
import { useParams } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";

import { Stack, Card, CardContent, Link, Typography } from "@mui/material";

const Marathon = () => {
    const params = useParams();


    // Request config for axios
    const requestConfig = {
        url: `/marathon/members-by-distance?marathonId=${params.marathonId}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    const {data, loading, error} = useFetchData(requestConfig);
    

    // Display Results
    return(
        <Stack spacing={2}>
                {loading && <p>Loading...</p>}
                {error && <p>{error.message}</p>}
                {data && data.map((item) => (
                <Stack item key={item.id}>
                    <Card>
                        <CardContent component={Link} to={`/user/${item.id}`}>
                            <Typography variant="h5">Username: {item.userName}</Typography>
                            <Typography variant="h5">Total Distance: {item.totalDistance} km</Typography>
                        </CardContent>
                    </Card>
                </Stack>
            ))}
        </Stack>
    );
};

export default Marathon;