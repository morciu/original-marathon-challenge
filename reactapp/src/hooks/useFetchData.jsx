import { useState, useEffect, useContext } from "react";
import Axios from "../utils/axios";
import { UserContext } from "./UserContext";

const useFetchData = (requestConfig) => {
    const {user} = useContext(UserContext);
    
    const [requestState, setRequestState] = useState({
        data: [],
        loading: false,
        error: null,
    });

    useEffect(() => {
        

        
        const fetchData = async () => {
            try {
                setRequestState({
                    ...requestState,
                    loading: true,
                });

                const response = await Axios(requestConfig);

                setRequestState({
                    ...requestState,
                    loading: false,
                    data: response.data,
                });
            } catch(err) {
                setRequestState({
                    ...requestState,
                    loading: false,
                    error: err,
                });
            } 
        };

        if(user.auth){
            fetchData();
        }
        
    }, [requestConfig.url]);

    return requestState
};

export default useFetchData;