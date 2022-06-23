import { useState } from 'react';

import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import 'bootstrap/dist/css/bootstrap.min.css';
import AddProduct from './AddProduct';


function ProductModal({ onCreate, show, setShow }) {


    const handleClose = () => setShow(false);


    async function handleSubmit(event) {
        event.preventDefault()

        onCreate();
    }

    return (
        <>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Add product</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <AddProduct handleSubmit={handleSubmit} onCreate={onCreate}></AddProduct>
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

export default ProductModal;