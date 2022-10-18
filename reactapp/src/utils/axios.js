import axios from "axios";

export const Axios = axios.create();

Axios.interceptors.request.use(
    async (config) => {
        const token = localStorage.token;
        if (token) config.headers['Authorization'] = 'Bearer ' + token;
        return config;
    },

    (error) => {
        Promise.reject(error)
    }
)

Axios.interceptors.response.use(
    (response) => response,
    async (error) => {
        console.log(error);
        if (error.response.status === 401) {
            localStorage.clear();
            window.location.reload();
        }
        if (error.response.status === 400) {
            window.location.reload();
        }
        Promise.reject(error);
    }
  )

export default Axios;