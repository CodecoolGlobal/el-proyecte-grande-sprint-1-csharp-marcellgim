import { useEffect } from "react";
import useAuth from "./useAuth";
import axios from "../api/axiosInstance"

function useIntercept() {
    const { auth } = useAuth();

    useEffect(() => {
        const requestIntercept = axios.interceptors.request.use(
            config => {
                if (!config.headers["Authorization"] && auth.accessToken) {
                    config.headers["Authorization"] = `Bearer ${auth?.accessToken}`;
                }
                return config;
            }, error => Promise.reject(error)
        );

        return () => {
            axios.interceptors.request.eject(requestIntercept);
        }
    })
    return axios;
}

export default useIntercept;