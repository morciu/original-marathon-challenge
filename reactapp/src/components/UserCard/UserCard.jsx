import React from "react";

import { Avatar, Card, CardHeader } from "@mui/material";
import { EmojiEvents } from "@mui/icons-material";

const UserCard = (props) => {
    return(
        <Card key={props.item.id} onClick={() => { props.action(props.item) }}>
            <CardHeader
                avatar={
                    <Avatar aria-label="recipe" >
                        {props.list.indexOf(props.item) + (props.pageNumber * props.pageSize) - 4}
                    </Avatar>
                }
                action={props.item.totalDistance >= 240 && <EmojiEvents />}
                title={props.item.userName}
                subheader={props.item.totalDistance+" km"}
                ></CardHeader>
        </Card>
    );
};

export default UserCard;