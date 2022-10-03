import { useState, useEffect } from "react";
import axios from "axios";

const useCheckInvitations = (requestConfig) => {
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

        fetchData();
    }, []);

    return requestState
};

export default useCheckInvitations;