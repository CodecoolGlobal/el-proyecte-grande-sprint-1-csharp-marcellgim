import { useEffect } from "react";
import useAuth from "../hooks/useAuth";

function Home() {
    const { logout, checkExpired } = useAuth();

    useEffect(() => {
        if (!checkExpired()) {
            logout();
        }
    })

    return (
    <>
        <h1>Placeholder</h1>
    </>
    );
}

export default Home;