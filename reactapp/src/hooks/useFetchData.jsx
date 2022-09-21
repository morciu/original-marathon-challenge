import { useState, useEffect } from "react";
import axios from "axios";

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

                const response = await axios(requestConfig);

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
    }, []);

    return requestState
};

export default useFetchData;