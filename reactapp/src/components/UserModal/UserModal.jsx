import React from "react";
import { Modal, Box, Typography, Button } from "@mui/material";
import { Stack } from "@mui/system";

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

const UserModal = (props) => {
    return(
        <Modal open={props.open}
                onClose={props.handleCloseModal}
                aria-labelledby={props.modalObject.id}>
            <Box sx={style}>
                <Typography variant="h6" component="h2">
                    {props.modalObject.userName}
                </Typography>
                <Typography sx={{ mt: 2 }}>
                    Total Distance: {props.modalObject.totalDistance} km
                </Typography>
                <Typography sx={{ mt: 2 }}>
                    Total Time spent running: {props.modalObject.totalTime}
                </Typography>
                <Typography sx={{ mt: 2 }}>
                    Average Pace: {props.modalObject.averagePace != null && props.modalObject.averagePace.substring(3)}
                </Typography>
                {!!props.modalObject.activities?.length && 
                    <Button variant="contained" onClick={props.action}>Check Runs</Button>}
            </Box>
        </Modal>
    );
};

export default UserModal;