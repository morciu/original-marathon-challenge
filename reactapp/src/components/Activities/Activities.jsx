import { Backdrop, CircularProgress, Pagination } from "@mui/material";
import { Stack } from "@mui/system";
import React, { useContext } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";
import { UserContext } from "../../hooks/UserContext";
import ActivityCard from "../ActivityCard/ActivityCard";

const Activities = () => {
    const {user} = useContext(UserContext);
    const params = useParams();

    const [fetchRequest, setFetchRequest] = useState({
        url: `/activity/user-activities/${params.userId}?PageNumber=1&PageSize=4`, 
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage.token}`,
        },
    });

    const selectPage = (event, value) => {
        setFetchRequest({
            url: `/activity/user-activities/${params.userId}?PageNumber=${value}&PageSize=4`, 
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage.token}`,
        },
        });
    };

    const {data, loading, error} = useFetchData(fetchRequest);

    return(
        <>
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={loading}>
                <CircularProgress color="inherit" />
            </Backdrop>
            <Stack spacing={2}>
                {data.data && data.data.map((item) => (
                        <ActivityCard distance={item.distance}
                        time={item.duration}
                        pace={item.pace}
                        date={item.date} />
                    ))}
            </Stack>
            <Pagination count={data.totalPages}
                onChange={selectPage}></Pagination>
        </>
    );
};

export default Activities;