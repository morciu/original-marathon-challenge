import React from "react";
import { useParams } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";

import { Stack, Card, CardContent, Link, Typography } from "@mui/material";
import axios from "axios";

const Marathon = () => {
    const {user} = useContext(UserContext);
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

    const fetchProgress = async () => {
        const response = await axios({
            url: `/marathon/${params.marathonId}/check-progress/${user.id}`,
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage["auth-token"]}`,
            },
        });
        return response.data;
    }
    

    // Display Results
    return(
        <>
        <Typography variant="h5">Personal Progress: {}% </Typography>
        <Stack spacing={2}>
                {loading && <p>Loading...</p>}
                {error && <p>{error.message}</p>}
                {data && data.map((item) => (
                    <Stack item key={item.id}>
                        <Card>
                            <CardContent component={Link} to={`/user/${item.id}`}>
                                <Typography color={"black"} variant="h5">Username: {item.userName}</Typography>
                                <Typography color={"black"} variant="h5">Total Distance: {item.totalDistance} km</Typography>
                            </CardContent>
                        </Card>
                    </Stack>
            ))}
        </Stack>
        </>
    );
};

export default Marathon;