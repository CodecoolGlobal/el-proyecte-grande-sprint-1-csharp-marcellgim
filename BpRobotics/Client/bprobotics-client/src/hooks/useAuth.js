import { useState } from "react";
import axios from "../fetch/axiosInstance";
import jwtDecode from "jwt-decode";
import { useNavigate } from "react-router-dom";

const AUTH_ENDPOINT = "/api/auth"

function useAuth() {
    const [auth, setAuth] = useState(JSON.parse(localStorage.getItem("auth")));
    const navigate = useNavigate();

    const login = async(username, password) => {
        try {
            const response = await axios.post(AUTH_ENDPOINT + "/login", {username, password});
            if (response.data && response.status === 200) {
                const decodedToken = jwtDecode(response.data.accessToken);
                const authData = {
                    ...response.data,
                    role: decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
                };
                setAuth(authData);
                localStorage.setItem("auth", JSON.stringify(authData));
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
        localStorage.removeItem("auth");
        navigate("/");
    }
    return { auth, login, logout };
}

export default useAuth;