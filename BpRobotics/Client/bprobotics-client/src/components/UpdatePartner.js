import React from 'react';
import { useNavigate, useParams } from "react-router-dom";
import axiosInstance from "../fetch/axiosInstance";
import { useState, useEffect } from "react";
import LoadingSpin from "react-loading-spin";
import '../App.css';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

function UpdatePartner() {

    let navigate = useNavigate();
    const { id } = useParams();

    const url = `${process.env.REACT_APP_HOST_URL}/api/partners/${id}`;

    const [companyName, setCompanyName] = useState('')
    const [companyPhoneNumber, setCompanyPhoneNumber] = useState('')

    const [isPendingUpdate, setIsPendingUpdate] = useState(false);

    const { data, fetchError, isLoading } = useAxiosFetchGet(url);

    useEffect(() => {
        setCompanyName(data.companyName);
        setCompanyPhoneNumber(data.phoneNumber);
    }, [data])


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
            {isLoading && <h1><LoadingSpin /></h1>}
            {fetchError && <p style={{ color: "red" }}>{fetchError}</p>}
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