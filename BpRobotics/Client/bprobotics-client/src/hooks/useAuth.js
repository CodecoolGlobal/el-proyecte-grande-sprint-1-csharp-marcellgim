import { useState } from "react";
import axios from "../api/axiosInstance";
import jwtDecode from "jwt-decode";
import { useEffect } from "react";

const AUTH_ENDPOINT = "/auth"

function useAuth() {
    const [auth, setAuth] = useState(JSON.parse(localStorage.getItem("auth")));

    useEffect(() => {
        if (auth !== null) {
            localStorage.setItem("auth", JSON.stringify(auth))
        } else {
            localStorage.removeItem("auth");
        }
    }, [auth])

    const login = async(username, password) => {
        const response = await axios.post(AUTH_ENDPOINT + "/login", {username, password});
        if (response.data) {
            const decodedToken = jwtDecode(response.data.accessToken);
            setAuth({
                ...response.data,
                role: decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
            });
        } else {
            console.log(response.error);
        }
    }

    const logout = () => {
        setAuth(null);
    }
    return { auth, login, logout };
}

export default useAuth;