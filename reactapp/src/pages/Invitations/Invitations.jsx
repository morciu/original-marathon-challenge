import { Card, CardHeader, IconButton, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import React from "react";
import useCheckInvitations from "../../hooks/useCheckInvitations";
import ThumbUpIcon from '@mui/icons-material/ThumbUp';
import ThumbDownIcon from '@mui/icons-material/ThumbDown';

const Invitations = () => {
    // Request config for invitations
    const requestConfigInvitations = {
        url: `/invitation/unanswered/${localStorage.id}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    }

    const {invData, invLoading, invError} = useCheckInvitations(requestConfigInvitations);

    return(
        <>
        <Stack spacing={2}>
        {invData.length == 0 &&
        <Typography variant="h5">No Invitations</Typography>}
        {invData.map((item) => (
            <Card key={item.id}>
                <CardHeader
                    title="Invitation From: "
                    subheader={item.sender.userName}
                    />
                <IconButton aria-label="settings"><ThumbUpIcon /></IconButton>
                <IconButton aria-label="settings"><ThumbDownIcon /></IconButton>
            </Card>
        ))}
        </Stack>
        </>
    );

};

export default Invitations;