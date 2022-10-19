import { Backdrop, CircularProgress, Pagination, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import React, { useContext } from "react";
import { useState } from "react";
import MedalCard from "../../components/MedalCard/MedalCard";
import useFetchData from "../../hooks/useFetchData";
import { UserContext } from "../../hooks/UserContext";

const Medals = () => {
    const {user} = useContext(UserContext);

    // Request settings to fetch medals
    const [requestConfig, setRequestConfig] = useState({
        url: `/medal/${user.id}/medals?PageNumber=1&PageSize=3`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage.token}`,
        },
    });

    // Handle page selection - change request
    const selectPage = (event, value) => {
        setRequestConfig({
            url: `/medal/${user.id}/medals?PageNumber=${value}&PageSize=3`,
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage.token}`,
            },
        })
    }

    // Fetch medals
    const {data, loading, error} = useFetchData(requestConfig);

    if(data.data?.length < 1) { 
        return(
        <Typography variant="h6">You haven't earned any trophies yet!</Typography>
        )}
    else {
        return(
            <>
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={loading}>
                <CircularProgress color="inherit" />
            </Backdrop>
    
            <Stack spacing={2}>
                {data.data && data.data.map((item) => (
                    <MedalCard key={item.id} item={item} />
                ))}
                
            </Stack>
    
            <Pagination 
                count={data.totalPages}
                onChange={selectPage}>
            </Pagination>
            </>
        );
    }
};

export default Medals;