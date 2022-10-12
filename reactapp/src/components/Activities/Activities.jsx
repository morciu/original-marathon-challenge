import { Stack } from "@mui/system";
import React, { useContext } from "react";
import useFetchData from "../../hooks/useFetchData";
import { UserContext } from "../../hooks/UserContext";
import ActivityCard from "../ActivityCard/ActivityCard";

const Activities = () => {
    const {user} = useContext(UserContext);

    // Set up fetch request
    const fetchRequest =  {
        url: `/activity/user-activities/${user.id}`, 
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    const {data, loading, error} = useFetchData(fetchRequest);

    return(
        <>
            <Stack spacing={2}>
                {data && data.map((item) => (
                        <ActivityCard distance={item.distance}
                        time={item.duration}
                        pace={item.pace} />
                    ))}
            </Stack>
        </>
    );
};

export default Activities;