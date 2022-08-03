import React from 'react';
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import LoadingSpin from "react-loading-spin";
import '../App.css';
import { Button, Card } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import useAxios from '../hooks/useAxios';

function AddPartner() {
    const axiosInstance = useAxios();
    const url = `${process.env.REACT_APP_HOST_URL}/api/partners`;
    const [isPendingAdd, setIsPendingAdd] = useState(false);

    const [postCompanyName, setPostCompanyName] = useState('');
    const [postPhoneNumber, setPostPhoneNumber] = useState('');
    let navigate = useNavigate();


    const handleSubmit = async (e) => {
        e.preventDefault();
        const newPartner = { "CompanyName": postCompanyName, "PhoneNumber": postPhoneNumber };
        setIsPendingAdd(true);
        try {
            const response = await axiosInstance.post(url, newPartner)
            //response should send back the created object
            setPostCompanyName('');
            setPostPhoneNumber('');
        } catch (err) {
            console.log(`Error: ${err.message}`);
        }
        setTimeout(() => { setIsPendingAdd(false) }, 1000);
        setTimeout(() => { navigate(-1) }, 1000);
    }


    return (
        <Card body>
        <Form onSubmit={(e)=>{handleSubmit(e)}} className="form">
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>Company name:</Form.Label>
                <Form.Control 
                    type="text" 
                    placeholder="Enter company name" 
                    required 
                    value={postCompanyName} 
                    onChange={(e) => setPostCompanyName(e.target.value)} 
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>Phone number:</Form.Label>
                <Form.Control 
                    type="text" 
                    placeholder="Enter phone number" 
                    required 
                    value={postPhoneNumber} 
                    onChange={(e) => setPostPhoneNumber(e.target.value)} 
                />
            </Form.Group>
            {!isPendingAdd && <Button variant="primary" type="submit">Add partner</Button>}
            {isPendingAdd && <button><LoadingSpin /></button>}
        </Form>
        </Card>
    )
}

export default AddPartner

