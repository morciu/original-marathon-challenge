import { Backdrop, CircularProgress, Pagination } from "@mui/material";
import { Stack } from "@mui/system";
import React from "react";
import { useState } from "react";
import { useContext } from "react";
import { useParams } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";
import { UserContext } from "../../hooks/UserContext";

const GlobalRanking = () => {
    const {user} = useContext(UserContext);
    const params = useParams();

    // Request configuration
    const [requestConfig, setRequestConfig] = useState({
        url: `/users/all-users?PageNumber=1&PageSize=5`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage.token}`,
        }
    });

    const selectPage = (event, value) => {
        setRequestConfig({
            url: `/users/all-users?PageNumber=${value}&PageSize=5`,
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage.token}`,
            },
        })
    }

    const {data, loading, error} = useFetchData(requestConfig);
    console.log(data)

    return(
        <>
            <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
            open={loading}>
            <CircularProgress color="inherit" />
            </Backdrop>

            <Stack spacing={2}>
                    {error && console.log(error.message)}
                    {data.data && data.data.map((item) => (
                        <div>{item.userName}: {item.averagePace}</div>
                    ))}
            </Stack>
            <Pagination 
                count={data.totalPages}
                onChange={selectPage}></Pagination>
            </>
    );
};

export default GlobalRanking;