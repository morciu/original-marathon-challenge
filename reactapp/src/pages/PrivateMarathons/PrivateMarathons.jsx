import { Backdrop, Button, Card, CardActionArea, CardContent, CardHeader, CircularProgress, Icon, Pagination, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import React from "react";
import useFetchData from "../../hooks/useFetchData";
import Login from "../Login/Login";
import { sendData } from "../../utils/SendData";
import { Link } from "react-router-dom";
import { useState } from "react";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";
import MarathonFilters from "../../components/MarathonFilters/MarathonFilters";

const cardStyle = {
    fontFamily: "Roboto",
    display: "flex",
    alignItems: "center",
    padding: "2px",
    minWidth: "298px",
    height: "68px",
    borderRadius: "18px",
    boxShadow: "0 2px 4px 0 rgba(138, 148, 159, 0.2)",
};

const PrivateMarathons = () => {
    const {user} = useContext(UserContext);

    const [needsUpdate, setNeedsUpdate] = useState(false);

    // Filter state
    const [filter, setFilter] = useState("active");

    // Page state
    const [page, setPage] = useState(1);

    // Request config state for pagination
    const [requestConfig, setRequestConfig] = useState(
        {
            url: `marathon/marathons-with-player/${localStorage.id}?PageNumber=1&PageSize=4&filterWord=${filter}`,
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage.token}`,
            }
        }
    );

    const selectPage = (event, value) => {
        setPage(value)

        setRequestConfig(
            {
                url: updateFetchUrl(value, filter),
                method: "GET",
                headers: {
                    Authorization: `Bearer ${localStorage.token}`,
                }
            }
        );
    };

    // Post config for axios
    const postConfig = {
        url: "/marathon/create-marathon",
        payload: { "firstUserId": localStorage.id },
        method: "POST",
    };

    const newPrivateMarathon = () => { 
        sendData(postConfig);
        setNeedsUpdate(!needsUpdate);
    };

    const {data, loading, error} = useFetchData(requestConfig, needsUpdate);

    const updateFetchUrl = (page, filterWord) => {
        return `marathon/marathons-with-player/${localStorage.id}?PageNumber=${page}&PageSize=4&filterWord=${filter}`;
    };

    const filterMarathons = (filterWord) => { 
        if(!["all", "active", "finished"].includes(filterWord)) { filterWord = "all" };
        setFilter(filterWord);
        setRequestConfig(
            {
                url: `marathon/marathons-with-player/${localStorage.id}?PageNumber=${page}&PageSize=4&filterWord=${filterWord}`,
                method: "GET",
                headers: {
                    Authorization: `Bearer ${localStorage.token}`,
                }
            }
        );
    };

    if (user.auth){
        if(data.data?.length < 1) {
            return(
                <>
                <MarathonFilters
                        currentFilter={filter}
                        all={() => {filterMarathons("all")}}
                        active={() => {filterMarathons("active")}}
                        finished={() => {filterMarathons("finished")}} />

                <Button variant="contained" onClick={newPrivateMarathon}>Start a Running Challenge</Button>
                </>
            );
        }
        else {
            return(
                <>
                    <MarathonFilters
                        currentFilter={filter}
                        all={() => {filterMarathons("all")}}
                        active={() => {filterMarathons("active")}}
                        finished={() => {filterMarathons("finished")}} />
    
                    <Backdrop
                        sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                        open={loading}>
                        <CircularProgress color="inherit" />
                    </Backdrop>
    
                    <Stack spacing={2}>
                        <Button variant="contained" onClick={newPrivateMarathon}>Start a Running Challenge</Button>
                        {data.data && data.data.map((item) => (
                            <Card sx={cardStyle} key={item.id} component={Link} to={`/marathon/${item.id}`} >
                                <CardHeader
                                    title={"Members: " + item.memberCount}
                                    subheader={"Started on: "+ (new Date(item.startDate)).toDateString() }
                                    />
                            </Card>
                        ))}
                    </Stack>
    
                    <Pagination 
                        count={data.totalPages}
                        onChange={selectPage}></Pagination>
                </>
            );
        }
    } else {
        return( <> <Login /> </>);
    }
};

export default PrivateMarathons;