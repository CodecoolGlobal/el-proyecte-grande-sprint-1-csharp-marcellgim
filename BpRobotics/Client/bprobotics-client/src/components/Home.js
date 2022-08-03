import { useEffect } from "react";
import useAuth from "../hooks/useAuth";
import useFlashMessages from "../hooks/useFlashMessages";
import { Card } from "react-bootstrap";
import "../Card.css"

function Home() {
    const { auth, logout, checkExpired } = useAuth();
    const { flash } = useFlashMessages();

    useEffect(() => {
        if (!checkExpired()) {
            flash("Your session has expired. You have been logged out.")
            logout();
        }
    })

    return (
        <Card>
            <Card.Body>
                <Card.Title>Welcome to Bp Robotics</Card.Title>
                <Card.Subtitle>Use the navbar above to access features.</Card.Subtitle>
                <Card.Text>You are {!auth && "not "}logged in</Card.Text>
            </Card.Body>
        </Card>
    );
}

export default Home;