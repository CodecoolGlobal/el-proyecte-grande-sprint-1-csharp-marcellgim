import React from 'react';
import { useNavigate, useParams } from "react-router-dom";
import axiosInstance from "../fetch/axiosInstance";
import { useState, useEffect } from "react";
import LoadingSpin from "react-loading-spin";
import '../App.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

function AddPartner() {

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
    )
}

export default AddPartner

