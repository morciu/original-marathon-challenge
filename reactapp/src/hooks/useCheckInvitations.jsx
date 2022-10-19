import { useState, useEffect, useContext } from "react";
import axios from "axios";
import { UserContext } from "./UserContext";

const useCheckInvitations = (requestConfig) => {
    const {user} = useContext(UserContext);

    const [requestState, setRequestState] = useState({
        invData: [],
        invLoading: false,
        invError: null,
    });

    useEffect(() => {
        const fetchData = async () => {
            try {
                setRequestState({
                    ...requestState,
                    invLoading: true,
                });

                const response = await axios(requestConfig);

                setRequestState({
                    ...requestState,
                    invLoading: false,
                    invData: response.data,
                });
            } catch(err) {
                setRequestState({
                    ...requestState,
                    invLoading: false,
                    invError: err,
                });
            } 
        };

        if(user.auth){
            fetchData();
        }
        
    }, [user]);

    return requestState
};

export default useCheckInvitations;