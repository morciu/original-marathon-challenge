import { React, useState } from "react";
import { useParams } from "react-router-dom";
import useFetchData from "../../hooks/useFetchData";
import { useContext } from "react";
import { UserContext } from "../../hooks/UserContext";
import Login from "../Login/Login";

import { Stack, Card, CardContent, Link, Typography, makeStyles, CardHeader, Avatar, IconButton, Modal, Backdrop, CircularProgress, Pagination } from "@mui/material";
import axios from "axios";
import UserModal from "../../components/UserModal/UserModal";
import RunningActivityModal from "../../components/RunningActivityModal/RunningActivityModal";
import MarathonListInvitationModal from "../../components/MarathonListInvitationModal/MarathonListInvitationModal";
import GroupAddIcon from '@mui/icons-material/GroupAdd';
import EmojiEventsIcon from '@mui/icons-material/EmojiEvents';
import UserCard from "../../components/UserCard/UserCard";

const Marathon = () => {
    const {user} = useContext(UserContext);
    const params = useParams();
    
    // Handle page selection - change request
    const selectPage = (event, value) => {
        setRequestConfig({
            url: `/marathon/members-by-distance?PageNumber=${value}&PageSize=5&marathonId=${params.marathonId}`,
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage.token}`,
            },
        })
    }

    // Request Config state for changing page requests
    const [requestConfig, setRequestConfig] = useState({
        url: `/marathon/members-by-distance?PageNumber=1&PageSize=5&marathonId=${params.marathonId}`,
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage.token}`,
        },
    });

    const {data, loading, error} = useFetchData(requestConfig);

    const fetchProgress = async () => {
        const response = await axios({
            url: `/marathon/${params.marathonId}/check-progress/${user.id}`,
            method: "GET",
            headers: {
                Authorization: `Bearer ${localStorage.token}`,
            },
        });
        return response.data;
    };
    const [currentProgress, setCurrentProgress] = useState(0);
    const progress = fetchProgress().then((result) => {
        setCurrentProgress(result);
    });
    
    // Main modal content
    const [modalObject, setmodalObject] = useState({
        id: null,
        userName: null,
        totalDistance: null,
        totalTime: null,
        averagePace: null
    });

    // User Modal State
    const[openModal, setOpenModal] = useState(false);
    const handleOpenModal = (item) => {
        setmodalObject(item);
        setOpenModal(true);
    };
    const handleCloseModal = () => setOpenModal(false);

    // Child Modal (Running activity) Content
    const [childModalObjects, setChildObjects] = useState([]);

    // Child Modal State - running activities
    const[openChildModal, setOpenChildModal] = useState(false);
    const handleOpenChildModal = (item) => {
        setChildObjects(item);
        setOpenChildModal(true)
    };

    // Child Modal State - marathon list for invitations
    const[openChildMarathonModal, setOpenChildMarathonModal] = useState(false);
    const handleOpenChildMarathonModal = (item) => {
        setChildObjects(item);
        setOpenChildMarathonModal(true)
    };

    // User position state

    const handleCloseChildModal = () => setOpenChildModal(false);
    const handleCloseChildMarathonModal = () => setOpenChildMarathonModal(false);

    // Display Results
    if (user.auth){
        return(
            <>
            <UserModal open={openModal}
                modalObject={modalObject}
                handleCloseModal={handleCloseModal}
                userId={modalObject.id}
                action2={() => { handleOpenChildMarathonModal(modalObject.marathons) }} />

            <RunningActivityModal open={openChildModal}
                modalObjects={childModalObjects}
                parent={modalObject}
                handleCloseModal={handleCloseChildModal} />
            
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
                    {error && <p>{error.message}</p>}
                    {data.data && data.data.map((item) => (
                        <UserCard key={item.id} item={item} list={data.data} pageNumber={data.pageNumber}
                            pageSize={data.pageSize} action={handleOpenModal} />
                    ))}
            </Stack>
            <Pagination 
                count={data.totalPages}
                onChange={selectPage}></Pagination>
            </>
        );
            
    } else {
        return( <> <Login /> </>);
    }
};

export default Marathon;