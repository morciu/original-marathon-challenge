import axios from "axios";

export const loginUser = async (requestConfig) => {
    try {
        const response = await axios({
            method: requestConfig.method,
            url: requestConfig.url,
            data: requestConfig.payload,
            headers: requestConfig.headers
        }
        );
        // Store response in local storage
        localStorage.setItem("id", response.data.id )
        localStorage.setItem("userName", response.data.userName )
        localStorage.setItem("auth-token", response.data.token )
        return true;
    } catch(error) {
        console.log(error)
        return false;
    }
};

export const sendData = async (requestConfig) => {
    try {
        const response = await axios({
            method: requestConfig.method,
            url: requestConfig.url,
            data: requestConfig.payload,
            headers: requestConfig.headers
        }
        );
        return true;
    } catch(error) {
        console.log(error);
        return false;
    }
};