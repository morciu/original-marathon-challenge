import { Box, Button, InputAdornment, Modal, Stack, TextField } from "@mui/material";
import React from "react";
import { useEffect } from "react";
import { useContext } from "react";
import { useForm } from "react-hook-form";
import { UserContext } from "../../hooks/UserContext";
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

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 300,
    height: 300,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,

    display: "flex",
    flexDirection: "column",
    justifyContent: "space-around",
    borderRadius: "16px"
  };

const buttonDiv = {
    display: "flex",
    gap: "4px"
};

const RegisterRunModal = (props) => {
    console.log(props)
    const {user} = useContext(UserContext);
    const { register, handleSubmit, reset, formState: { errors, isSubmitSuccessful } } = useForm();

    const handleFormSubmission = async (submission) => {
        submission.userId = localStorage.id;
        submission.date = new Date();
        requestConfig.payload = submission;
        console.log(requestConfig.payload);
        console.log(submission)

        if (await sendData(requestConfig)){
            console.log("All Good!");
        } else {
            console.log("something went wrong!");
        }
    };

    // Reset form after successful submission
    useEffect(() => {
        if(isSubmitSuccessful){
            reset();
            props.setNeedsUpdate(!props.needsUpdate)
        }
    });

    return(
        <>
        <Modal open={props.open}
        onClose={() => {
            props.close();
            reset();
            }}> 
            <Box sx={style}>
            <form onSubmit={handleSubmit(handleFormSubmission)}
            action={requestConfig.url} method={requestConfig.method}>
            <Stack spacing={3}>
                <TextField type={"number"}
                    InputProps={{startAdornment: <InputAdornment position="start">km</InputAdornment>}}
                    inputProps={{ maxLength: 4, step: ".01",  }}
                    variant="outlined" label="Distance"
                    error={!!errors['distance']}
                    {...register("distance", {...requiredFieldRule})}/>
                <TextField type={"text"} variant="outlined" label="Time"
                    error={!!errors['duration']}
                    {...register("duration", {...requiredFieldRule})}/>
                <Button type="submit" variant="contained">Submit</Button>
            </Stack>
            </form>
            </Box> 
        </Modal>
        </>
    );
};

export default RegisterRunModal;