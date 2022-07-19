import React, { useEffect, useState } from 'react';
import useAxiosFetchGet from '../hooks/useAxiosFetchGet';
import { Form, Button } from "react-bootstrap";
import '../CreateOrder.css';

const AddOrder = () => {
    const customersUrl = `${process.env.REACT_APP_HOST_URL}/api/customers`;
    const ordersUrl = `${process.env.REACT_APP_HOST_URL}/api/orders`;
    const productsUrl = `${process.env.REACT_APP_HOST_URL}/api/products`;

    const [customers, setCustomers] = useState();
    const [products, setProducts] = useState();
    const [orderDict, setOrderDict] = useState([]);
    const [orderViewDict, setOrderViewDict] = useState({});

    const { data: customerData } = useAxiosFetchGet(customersUrl);
    const { data: productsData } = useAxiosFetchGet(productsUrl);

    useEffect(() => {
        setCustomers(customerData);
    }, [customerData]);

    useEffect(() => {
        setProducts(productsData);
    }, [productsData]);

    const addToOrder = (e) => {
        e.preventDefault();
        const newProduct = products.filter(product => !orderViewDict.hasOwnProperty(product.name));
        
        if (!newProduct?.length) {
            return;
        }

        setOrderViewDict({ ...orderViewDict, [newProduct[0].name]: 1 });
    };

    const switchProduct = (e, key) => {
        setOrderViewDict({ ...orderDict, [e.target.value]: orderViewDict[key] })
        delete orderViewDict[key];
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {

        } catch (err) {
            console.log(err);
        }
    };

    return (
        <>
            {customers?.length && products?.length
                ? (
                    <Form onSubmit={handleSubmit}>
                        <Form.Label htmlFor='customers'>Customer:</Form.Label>
                        <Form.Select name='customer' id='customers'>
                            {customers.map(customer => <option value={customer.id}>{customer.companyName}</option>)}
                        </Form.Select>
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
                                                    onInput={(e) => setOrderViewDict({ ...orderViewDict, [key]: e.target.value })}
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
                        <Button variant="primary" type="submit">Create Order</Button>
                    </Form>
                ) : <p>No customers or products available</p>
            }
        </>
    )
}

export default AddOrder;