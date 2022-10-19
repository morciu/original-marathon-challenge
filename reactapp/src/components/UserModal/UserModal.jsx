import React from "react";
import { Modal, Box, Typography, Button } from "@mui/material";
import { Link } from "react-router-dom";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 300,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
    borderRadius: "16px"
  };

const buttonDiv = {
    display: "flex",
    gap: "4px"
};

const UserModal = (props) => {
    const {user} = useContext(UserContext);

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
                <div style={buttonDiv}>
                    {!!props.modalObject.activities?.length && 
                        <Button variant="contained" component={Link} to={`/${props.userId}/activities`}>Check Runs</Button>}
                    {props.modalObject.id != user.id && 
                    <Button variant="contained" onClick={props.action2}>Invite to challenge</Button>}
                </div>
            </Box>
        </Modal>
    );
};

export default UserModal;