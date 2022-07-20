import React from 'react';
import { useNavigate, useParams, useLocation } from "react-router-dom";
import axiosInstance from "../fetch/axiosInstance";
import { useState } from "react";
import LoadingSpin from "react-loading-spin";
import '../App.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

function UpdatePartner() {

    let navigate = useNavigate();
    const location = useLocation();
    const partner = location.state;
    const { id } = useParams();

    const url = `${process.env.REACT_APP_HOST_URL}/api/partners/${id}`;

    const [companyName, setCompanyName] = useState(partner.companyName)
    const [companyPhoneNumber, setCompanyPhoneNumber] = useState(partner.phoneNumber)

    const [isPendingUpdate, setIsPendingUpdate] = useState(false);


    const handleUpdate = async (e) => {
        e.preventDefault();
        const updatedPartner = { "Id": id, "CompanyName": companyName, "PhoneNumber": companyPhoneNumber };
        setIsPendingUpdate(true);
        try {
            const response = await axiosInstance.put(url, updatedPartner)
        } catch (err) {
            console.log(`Error: ${err.message}`);
        }
        setIsPendingUpdate(false);
        navigate(-1);
    }



    return (
        <>
            {companyName &&
                <Form onSubmit={(e) => { handleUpdate(e) }}>
                    <Form.Group className="mb-3" controlId="formBasicText">
                        <Form.Label>Company name:</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter company name"
                            required
                            value={companyName}
                            onChange={(e) => setCompanyName(e.target.value)}
                        />
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formBasicText">
                        <Form.Label>Phone number:</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter phone number"
                            required
                            value={companyPhoneNumber}
                            onChange={(e) => setCompanyPhoneNumber(e.target.value)}
                        />
                    </Form.Group>
                    {!isPendingUpdate && <Button variant="primary" type="submit">Update partner</Button>}
                    {isPendingUpdate && <button><LoadingSpin /></button>}
                </Form>
            }
        </>
    )
}

export default UpdatePartner