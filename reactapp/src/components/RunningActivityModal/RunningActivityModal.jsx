import React from "react";
import { Modal, Box, Typography } from "@mui/material";
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

const RunningActivityModal = (props) => {
    return(
        <Modal open={props.open}
                onClose={props.handleCloseModal}
                aria-labelledby={props.parent.id}>
            <Box sx={style}>
            <Stack>
                {props.modalObjects && props.modalObjects.map((item) => (
                    <Typography key={item.id}>- Distance: {item.distance}, Time: {item.duration}, Pace: {item.pace}</Typography>
                ))}
            </Stack>
            </Box>
        </Modal>
    );
};

export default RunningActivityModal;