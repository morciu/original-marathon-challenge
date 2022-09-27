import { Button, Stack, TextField } from "@mui/material";
import React from "react";
import { useForm } from "react-hook-form";

import { postData } from "../../utils/PostData";

// Post config for axios
const requestConfig = {
    url: "/activity/create-activity",
    payload: "",
    method: "POST",
};

const requiredFieldRule = {
    required: {
        value: true,
        message: "Field is required!",
    }
};

const RegisterRun = () => {
    const { register, handleSubmit, formState: { errors } } = useForm();

    const handleFormSubmission = async (submission) => {
        submission.userId = localStorage.id;
        submission.date = new Date();
        requestConfig.payload = submission;
        console.log(requestConfig.payload);

        if (await postData(requestConfig)){
            console.log("All Good!");
        } else {
            console.log("something went wrong!");
        }
    };

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
};

export default RegisterRun;