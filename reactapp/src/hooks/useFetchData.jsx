import { useState, useEffect } from "react";
import Axios from "../utils/axios";

const useFetchData = (requestConfig) => {
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

        fetchData();
    }, [requestConfig.url]);

    return requestState
};

export default useFetchData;