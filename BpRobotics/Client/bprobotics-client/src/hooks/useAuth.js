import { useState } from "react";
import axios from "../api/axiosInstance";
import jwtDecode from "jwt-decode";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

const AUTH_ENDPOINT = "/auth"

function useAuth() {
    const [auth, setAuth] = useState(JSON.parse(localStorage.getItem("auth")));
    const navigate = useNavigate();

    useEffect(() => {
        if (auth !== null) {
            localStorage.setItem("auth", JSON.stringify(auth))
        } else {
            localStorage.removeItem("auth");
        }
    }, [auth])

    const login = async(username, password) => {
        try {
            const response = await axios.post(AUTH_ENDPOINT + "/login", {username, password});
            if (response.data && response.status === 200) {
                const decodedToken = jwtDecode(response.data.accessToken);
                setAuth({
                    ...response.data,
                    role: decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
                });
                navigate("/");
            }
        } catch (error) {
            if (error.response) {
                console.log(error.toJSON());
            } else {
                throw new Error(error.toJSON())
            }
        }
    }

    const logout = () => {
        setAuth(null);
        navigate("/");
    }
    return { auth, login, logout };
}

export default useAuth;