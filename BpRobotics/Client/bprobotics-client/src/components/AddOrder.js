import React, { useEffect, useState } from 'react';
import useAxiosFetchGet from '../hooks/useAxiosFetchGet';

const AddOrder = () => {
    const customersUrl = `${process.env.REACT_APP_HOST_URL}/api/customers`;
    const ordersUrl = `${process.env.REACT_APP_HOST_URL}/api/orders`;
    const productsUrl = `${process.env.REACT_APP_HOST_URL}/api/products`;

    const [customers, setCustomers] = useState();
    const [products, setProducts] = useState();
    const [orderDict, setOrderDict] = useState([]);
    const [orderViewDict, setOrderViewDict] = useState([]);
    const [chosenProduct, setChosenProduct] = useState('');
    const [chosenQuantity, setChosenQuantity] = useState('');

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

        if (!chosenProduct) {
            setChosenProduct(products[0].name);
        }
        
        const oldValue = orderViewDict[chosenProduct] ? parseInt(orderViewDict[chosenProduct]) : 0;
        const orderViewDictWithNew = orderViewDict;
        orderViewDictWithNew[chosenProduct] =  oldValue + parseInt(chosenQuantity);
        setOrderViewDict({...orderViewDictWithNew});
    };

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
                    <form onSubmit={handleSubmit}>
                        <label htmlFor='customers'>Customer:</label>
                        <select name='customer' id='customers'>
                            {customers.map(customer => <option value={customer.id}>{customer.companyName}</option>)}
                        </select>
                        <br />
                        <label htmlFor='orders'>Current order:</label>
                        <table>
                            <thead>
                                <tr>
                                    <th>Product</th>
                                    <th>Quantity</th>
                                </tr>
                            </thead>
                            <tbody>
                                {Object.entries(orderViewDict).map(([key, value]) => (
                                    <tr>
                                        <td>{key}</td>
                                        <td>{value}</td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                        <br />
                        <div>
                            <p>Add to order</p>
                            <label htmlFor='products'>Product:</label>
                            <select
                                id='products'
                                onChange={(e) => setChosenProduct(e.target.value)} >
                                {products.map(product => <option value={product.name}>{product.name}</option>)}
                            </select>
                            <br />
                            <label htmlFor='quantity'>Quantity</label>
                            <input
                                id='quantity'
                                type="number"
                                onChange={(e) => setChosenQuantity(e.target.value)}
                                value={chosenQuantity}
                                step="1"
                                min="1" />
                            <br />
                            <button onClick={addToOrder}>Add to Order</button>
                        </div>
                        <br />
                        <button onClick={handleSubmit}>Create Order</button>
                    </form>
                ) : <p>No customers or products available</p>
            }
        </>
    )
}

export default AddOrder;