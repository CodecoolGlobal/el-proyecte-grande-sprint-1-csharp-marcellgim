import useFlashMessages from "../hooks/useFlashMessages";
import { Alert } from "react-bootstrap";
import { useEffect, useState } from "react";

function FlashMessages() {
    const [show, setShow] = useState(true);
    const { messages, clearMessages } = useFlashMessages();
    const [currentMessages, setCurrentMessages] = useState([]);

    useEffect(() => {
        if (messages.length > 0) {
            setCurrentMessages(messages);
            clearMessages();
        }
    }, [messages]);

    const handleClose = () => {
        setShow(false);
    }

    return (
        <>
        {show && (currentMessages.length > 0) && 
            <Alert variant="danger" dismissible onClose={handleClose}>
                {currentMessages.map((message, index) => (<p key={index}>{message}</p>))}
            </Alert>
        }
        </>
    );
}

export default FlashMessages;