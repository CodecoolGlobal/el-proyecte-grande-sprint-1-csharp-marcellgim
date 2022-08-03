import React, { useState } from 'react';
import useAxiosFetchGet from '../hooks/useAxiosFetchGet';
import { Form, Button, Alert, Card } from "react-bootstrap";
import '../CreateOrder.css';
import useAuth from '../hooks/useAuth';
import jwtDecode from "jwt-decode";
import axios from "../fetch/axiosInstance";
import { useNavigate } from "react-router-dom";

const AddOrder = () => {
    const { auth } = useAuth();
    const navigate = useNavigate();

    const customersUrl = `${process.env.REACT_APP_HOST_URL}/api/customers`;
    const ordersUrl = `${process.env.REACT_APP_HOST_URL}/api/orders`;
    const productsUrl = `${process.env.REACT_APP_HOST_URL}/api/products`;

    const [errorMessage, setErrorMessage] = useState();
    const [orderDict, setOrderDict] = useState({});
    const [orderViewDict, setOrderViewDict] = useState({});
    const [chosenCustomerId, setChosenCustomerId] = useState((auth.role === "Customer") ? jwtDecode(auth.accessToken)["functionId"] : null);

    const { data: customers } = useAxiosFetchGet(customersUrl);
    const { data: products } = useAxiosFetchGet(productsUrl);

    const addToOrder = (e) => {
        e.preventDefault();
        const newProduct = products.filter(product => !orderViewDict.hasOwnProperty(product.name));

        if (!newProduct?.length) {
            return;
        }

        setOrderViewDict({ ...orderViewDict, [newProduct[0].name]: 1 });

        setOrderDict({ ...orderDict, [newProduct[0].id]: 1 });
    };

    const switchProduct = (e, key) => {
        const prevValue = orderViewDict[key];

        delete orderViewDict[key];
        setOrderViewDict({ ...orderViewDict, [e.target.value]: prevValue })

        delete orderDict[products.filter(p => p.name === key)[0].id];
        setOrderDict({ ...orderDict, [products.filter(p => p.name === e.target.value)[0].id]: prevValue });
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            await axios.post(ordersUrl, {
                "date": Date.now,
                "customerId": chosenCustomerId,
                "productIdsAndQuantity": orderDict
            });

            navigate("/orders");
        } catch (err) {
            setErrorMessage(err.message);
        }
    };

    return (
        <Card body>
            {errorMessage && <Alert variant='danger'>{errorMessage}</Alert>}
            {customers?.length && products?.length
                ? (
                    <Form onSubmit={handleSubmit}>
                        {(auth.role === "Admin") ?
                            <>
                                <Form.Label htmlFor='customers'>Customer:</Form.Label>
                                <Form.Select name='customer' id='customers'
                                    onChange={(e) => setChosenCustomerId(e.target.value)}>
                                    <option selected disabled>Choose a Customer</option>
                                    {customers.map(customer => <option key={customer.id} value={customer.id}>{customer.companyName}</option>)}
                                </Form.Select>
                            </>
                            :
                            <></>}
                        <br />
                        <div className='inner-form-box'>
                            <Form.Label htmlFor='orders'>Current order:</Form.Label>
                            <table>
                                <thead>
                                    <tr>
                                        <th>Product</th>
                                        <th>Quantity</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {Object.keys(orderViewDict).map(key => (
                                        <tr>
                                            <td>
                                                <Form.Select
                                                    id='products'
                                                    defaultValue={key}
                                                    onChange={(e) => switchProduct(e, key)} >
                                                    {products.map(product => <option key={product.id} value={product.name}>{product.name}</option>)}
                                                </Form.Select>
                                            </td>
                                            <td>
                                                <Form.Control type="number" value={orderViewDict[key]}
                                                    id={products.filter(p => p.name === key)[0]?.id}
                                                    onInput={(e) => {
                                                        setOrderViewDict({ ...orderViewDict, [key]: +e.target.value });
                                                        setOrderDict({ ...orderDict, [+e.target.id]: +e.target.value });
                                                    }}
                                                    min="1" step="1" />
                                            </td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                            <br />
                            <Button variant="primary" onClick={addToOrder}>+ Add to order</Button>
                        </div>
                        <br />
                        <Button variant="primary" type="submit" disabled={Object.entries(orderDict).length === 0 || chosenCustomerId === null}>Create Order</Button>
                    </Form>
                ) : <p>No customers or products available</p>
            }
        </Card>
    )
}

export default AddOrder;