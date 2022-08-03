import React from 'react';
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import LoadingSpin from "react-loading-spin";
import '../App.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import useAxios from '../hooks/useAxios';
import useAxiosFetchGet from '../hooks/useAxiosFetchGet';


function AddCustomer() {
    const axiosInstance = useAxios();
    const url = `${process.env.REACT_APP_HOST_URL}/api/customers`;
    const usersUrl = `${process.env.REACT_APP_HOST_URL}/api/users/customers`;

    const { data: users } = useAxiosFetchGet(usersUrl);


    const [isPendingAdd, setIsPendingAdd] = useState(false);

    const [chosenUserId, setChosenUserId] = useState(null);
    const [postCompanyName, setPostCompanyName] = useState('');
    const [postVATNumber, setPostVATNumber] = useState('');
    const [postBillingZIP, setPostBillingZIP] = useState('');
    const [postBillingCountry, setPostBillingCountry] = useState('');
    const [postBillingCity, setPostBillingCity] = useState('');
    const [postBillingAddress, setPostBillingAddress] = useState('');
    const [postShippingZIP, setPostShippingZIP] = useState('');
    const [postShippingCountry, setPostShippingCountry] = useState('');
    const [postShippingCity, setPostShippingCity] = useState('');
    const [postShippingAddress, setPostShippingAddress] = useState('');

    let navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newCustomer = { 
            "CompanyName": postCompanyName,
            "VatNumber": postVATNumber,
            "BillingZip": postBillingZIP,
            "BillingCountry": postBillingCountry,
            "BillingCity": postBillingCity,
            "BillingAddress": postBillingAddress,
            "ShippingZip": postShippingZIP,
            "ShippingCountry": postShippingCountry,
            "ShippingCity": postShippingCity,
            "ShippingAddress": postShippingAddress,
            "UserId": chosenUserId
         };
        setIsPendingAdd(true);
        try {
            const response = await axiosInstance.post(url, newCustomer)
            //response should send back the created object
            setChosenUserId(null);
            setPostCompanyName('');
            setPostVATNumber('');
            setPostBillingZIP('');
            setPostBillingCountry('');
            setPostBillingCity('');
            setPostBillingAddress('');
            setPostShippingZIP('');
            setPostShippingCountry('');
            setPostShippingCity('');
            setPostShippingAddress('');
        } catch (err) {
            console.log(`Error: ${err.message}`);
        }
        setTimeout(() => { setIsPendingAdd(false) }, 1000);
        setTimeout(() => { navigate(-1) }, 1000);
    }

    return (
        <Form onSubmit={(e) => { handleSubmit(e) }} className="form">
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label htmlFor='users'>User:</Form.Label>
                <Form.Select name='user' id='users'
                    onChange={(e) => setChosenUserId(e.target.value)}
                    required>
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
                <Form.Label>VAT number:</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Enter VAT number"
                    required
                    value={postVATNumber}
                    onChange={(e) => setPostVATNumber(e.target.value)}
                />
            </Form.Group>
            <br />
            <br />

            <label>Billing Address</label>
            <br />
            <br />
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>ZIP code:</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Enter ZIP code"
                    required
                    value={postBillingZIP}
                    onChange={(e) => setPostBillingZIP(e.target.value)}
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>Country:</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter country name"
                    required
                    value={postBillingCountry}
                    onChange={(e) => setPostBillingCountry(e.target.value)}
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>City:</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter city name"
                    required
                    value={postBillingCity}
                    onChange={(e) => setPostBillingCity(e.target.value)}
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>Address:</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter address name"
                    required
                    value={postBillingAddress}
                    onChange={(e) => setPostBillingAddress(e.target.value)}
                />
            </Form.Group>
            <br />
            <br />

            <label>Shipping Address</label>
            <br />
            <br />
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>ZIP code:</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Enter ZIP code"
                    required
                    value={postShippingZIP}
                    onChange={(e) => setPostShippingZIP(e.target.value)}
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>Country:</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter country name"
                    required
                    value={postShippingCountry}
                    onChange={(e) => setPostShippingCountry(e.target.value)}
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>City:</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter city name"
                    required
                    value={postShippingCity}
                    onChange={(e) => setPostShippingCity(e.target.value)}
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicText">
                <Form.Label>Address:</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter address name"
                    required
                    value={postShippingAddress}
                    onChange={(e) => setPostShippingAddress(e.target.value)}
                />
            </Form.Group>
            {!isPendingAdd && <Button variant="primary" type="submit">Add customer</Button>}
            {isPendingAdd && <button><LoadingSpin /></button>}
        </Form>
    )
}

export default AddCustomer
