import { Button, Stack, TextField } from "@mui/material";
import React from "react";
import { useContext } from "react";
import { useForm } from "react-hook-form";
import { UserContext } from "../../hooks/UserContext";
import Login from "../Login/Login";

import { sendData } from "../../utils/SendData";

// Post config for axios
const requestConfig = {
    url: "/activity/create-activity",
    payload: "",
    method: "POST",
    headers: { 
        Authorization: `Bearer ${localStorage.token}`,
        "Content-Type": "application/json",
    }
};

const requiredFieldRule = {
    required: {
        value: true,
        message: "Field is required!",
    }
};

const RegisterRun = () => {
    const {user} = useContext(UserContext);
    const { register, handleSubmit, formState: { errors } } = useForm();

    const handleFormSubmission = async (submission) => {
        submission.userId = localStorage.id;
        submission.date = new Date();
        requestConfig.payload = submission;
        console.log(requestConfig.payload);

        if (await sendData(requestConfig)){
            console.log("All Good!");
        } else {
            console.log("something went wrong!");
        }
    };

    if (user.auth){
        return(
            <>
            <form onSubmit={handleSubmit(handleFormSubmission)}
            action={requestConfig.url} method={requestConfig.method}>
            <Stack>
                <TextField type={"number"}
                    inputProps={{maxLength: 4, step: ".01"}}
                    variant="filled" label="Distance"
                    error={!!errors['distance']}
                    {...register("distance", {...requiredFieldRule})}/>
                <TextField type={"text"} variant="outlined" label="Time"
                    error={!!errors['duration']}
                    {...register("duration", {...requiredFieldRule})}/>
                <Button type="submit" variant="contained">Submit</Button>
            </Stack>
                <Button href="/" variant="contained">Back</Button>
            </form>
            </>
        );
            
    } else {
        return( <> <Login /> </>);
    };
};

export default RegisterRun;