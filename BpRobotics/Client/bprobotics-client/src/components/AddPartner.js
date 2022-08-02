import React from 'react';
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import LoadingSpin from "react-loading-spin";
import '../App.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import useAxios from '../hooks/useAxios';
import useAxiosFetchGet from '../hooks/useAxiosFetchGet';


function AddPartner() {
    const axiosInstance = useAxios();
    const url = `${process.env.REACT_APP_HOST_URL}/api/partners`;
    const usersUrl = `${process.env.REACT_APP_HOST_URL}/api/users`;

    const { data: users } = useAxiosFetchGet(usersUrl);


    const [isPendingAdd, setIsPendingAdd] = useState(false);

    const [postCompanyName, setPostCompanyName] = useState('');
    const [postPhoneNumber, setPostPhoneNumber] = useState('');
    const [chosenUserId, setChosenUserId] = useState(null);
    let navigate = useNavigate();


    const handleSubmit = async (e) => {
        e.preventDefault();
        const newPartner = { "CompanyName": postCompanyName, "PhoneNumber": postPhoneNumber, "UserId": chosenUserId };
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
                <Form.Label htmlFor='users'>User:</Form.Label>
                <Form.Select name='user' id='users'
                    onChange={(e) => setChosenUserId(e.target.value)}>
                    <option selected disabled>Choose a user</option>
                    {users.map(user => <option key={user.id} value={user.id}>{user.firstName} {user.lastName}</option>)}
                </Form.Select>
            </Form.Group>
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

