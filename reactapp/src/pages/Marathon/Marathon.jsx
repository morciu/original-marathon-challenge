import { React, useState } from "react";
import { useParams } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";

import { Stack, Card, CardContent, Link, Typography, makeStyles, CardHeader, Avatar, IconButton, Modal } from "@mui/material";
import axios from "axios";
import { Favorite } from "@mui/icons-material";
import { Box } from "@mui/system";

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

    const style = {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: 400,
        bgcolor: 'background.paper',
        border: '2px solid #000',
        boxShadow: 24,
        p: 4,
      };
      
      const [modalObject, setmodalObject] = useState({
            id: null,
            userName: null,
            totalDistance: null,
            totalTime: null,
            averagePace: null
        });

      const[openModal, setOpenModal] = useState(false);
      const handleOpenModal = (item) => {
        setmodalObject(item);
        setOpenModal(true);
    }
      const handleCloseModal = () => setOpenModal(false);
    

    // Display Results
    return(
        <>
            <Typography variant="h5">Personal Progress: {}% </Typography>
            
            <Modal open={openModal}
                onClose={handleCloseModal}
                aria-labelledby={modalObject.id}>
                <Box sx={style}>
                    <Typography variant="h6" component="h2">
                        {modalObject.userName}
                    </Typography>
                    <Typography sx={{ mt: 2 }}>
                        Total Distance: {modalObject.totalDistance} km
                    </Typography>
                    <Typography sx={{ mt: 2 }}>
                        Total Time spent running: {modalObject.totalTime}
                    </Typography>
                    <Typography sx={{ mt: 2 }}>
                        Average Pace: {modalObject.averagePace != null && modalObject.averagePace.substring(3)}
                    </Typography>
                </Box>
            </Modal>

            <Stack spacing={2}>
                    {loading && <p>Loading...</p>}
                    {error && <p>{error.message}</p>}
                    {data && data.map((item) => (
                        <Card onClick={() => { handleOpenModal(item) }}>
                            <CardHeader
                                avatar={
                                    <Avatar aria-label="recipe" >
                                        {item.userName != null && item.userName.substring(0,1)}
                                    </Avatar>
                                }
                                action={
                                    <IconButton aria-label="settings"><Favorite /></IconButton>
                                }
                                title={item.userName}
                                subheader={item.totalDistance+" km"}
                                />
                        </Card>
                    ))}
            </Stack>
        </>
    );
};

export default Marathon;