import { Backdrop, CircularProgress, Pagination } from "@mui/material";
import { Stack } from "@mui/system";
import React from "react";
import { useState } from "react";
import { useContext } from "react";
import { useParams } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";
import { UserContext } from "../../hooks/UserContext";
import Login from "../../pages/Login/Login";
import GlobalUserCard from "../GlobalUserCard/GlobalUserCard";
import MarathonListInvitationModal from "../MarathonListInvitationModal/MarathonListInvitationModal";
import UserCard from "../UserCard/UserCard";
import UserModal from "../UserModal/UserModal";
import styles from "./GlobalRanking.module.css"



const GlobalRanking = () => {
    const {user} = useContext(UserContext);
    const params = useParams();

    // Request configuration
    const [requestConfig, setRequestConfig] = useState({
        url: `/users/all-users?PageNumber=1&PageSize=5`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage.token}`,
        }
    });

    const selectPage = (event, value) => {
        setRequestConfig({
            url: `/users/all-users?PageNumber=${value}&PageSize=5`,
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage.token}`,
            },
        })
    }

    // Child Modal (Running activity) Content
    const [childModalObjects, setChildObjects] = useState([]);

    // Child Modal State - marathon list for invitations
    const[openChildMarathonModal, setOpenChildMarathonModal] = useState(false);
    const handleOpenChildMarathonModal = (item) => {
        setChildObjects(item);
        setOpenChildMarathonModal(true)
    };

    const handleCloseModal = () => setOpenModal(false);

    // Main modal content
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
    };

    const handleCloseChildMarathonModal = () => setOpenChildMarathonModal(false);

    const {data, loading, error} = useFetchData(requestConfig);

    if(user.auth){
        return(
            <>
                <UserModal open={openModal}
                modalObject={modalObject}
                handleCloseModal={handleCloseModal}
                userId={modalObject.id}
                action2={() => { handleOpenChildMarathonModal(modalObject.marathons) }} />

                <MarathonListInvitationModal open={openChildMarathonModal}
                modalObjects={childModalObjects}
                parent={modalObject}
                handleCloseModal={handleCloseChildMarathonModal}/>

                <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={loading}>
                <CircularProgress color="inherit" />
                </Backdrop>
    
                <Stack spacing={2}>
                        {error && console.log(error.message)}
                        {data.data && data.data.map((item) => (
                            <GlobalUserCard key={item.id} item={item} list={data.data} pageNumber={data.pageNumber}
                            pageSize={data.pageSize} action={handleOpenModal} />
                        ))}
                </Stack>
                <Pagination 
                    count={data.totalPages}
                    onChange={selectPage}></Pagination>
            </>
        );
    }
    else {
        return(<Login />)
    }
    
};

export default GlobalRanking;