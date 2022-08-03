import { useEffect } from "react";
import useAuth from "../hooks/useAuth";
import useFlashMessages from "../hooks/useFlashMessages";

function Home() {
    const { logout, checkExpired } = useAuth();
    const { flash } = useFlashMessages();

    useEffect(() => {
        if (!checkExpired()) {
            flash("Your session has expired. You have been logged out.")
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