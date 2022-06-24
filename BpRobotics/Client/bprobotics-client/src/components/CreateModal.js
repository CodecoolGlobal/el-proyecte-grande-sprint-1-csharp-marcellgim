import { useState } from 'react';

import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import 'bootstrap/dist/css/bootstrap.min.css';


function CreateModal({ typeName, FormComponent, onCreate }) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const postData = async (url, data) => {
        const response = await fetch(url,
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        })

        if (response.status === 201) {
            handleClose()
            onCreate()
        }
    }

    return (
    <>
        <Button variant="primary" onClick={handleShow}>New {typeName}</Button>
        <Modal show={show} onHide={handleClose} size="lg">
        <Modal.Header closeButton>
          <Modal.Title>Enter new {typeName} details</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <FormComponent postData={postData} />
        </Modal.Body>
        <Modal.Footer>
          <Button variant="primary" onClick={handleClose}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </>
    );
}

export default CreateModal;