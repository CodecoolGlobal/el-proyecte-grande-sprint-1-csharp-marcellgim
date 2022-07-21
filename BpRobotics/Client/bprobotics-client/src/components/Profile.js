import React from 'react'
import useAuth from '../hooks/useAuth'
import useAxiosFetchGet from '../hooks/useAxiosFetchGet';
import jwtDecode from 'jwt-decode';
import { useNavigate } from "react-router-dom";
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from 'react-bootstrap/Button';
import Typography from '@mui/material/Typography';

const CUSTOMER_URL = "/api/customers";

const Profile = () => {
    const { auth } = useAuth();
    const customerId = jwtDecode(auth.accessToken).functionId;
    const { data: customer } = useAxiosFetchGet(CUSTOMER_URL + `/${customerId}`);
    let navigate = useNavigate();

    return (
        <Card sx={{ maxWidth: 800 }}>
            <CardContent>
                <Typography gutterBottom variant="h3" component="div">
                    {customer.companyName}
                </Typography>
                <Typography gutterBottom variant="h6" component="div">
                    VAT Number: {customer.vatNumber}
                </Typography>
                <Typography variant="h6" component="br"></Typography>
                <Typography variant="h6" component="div">
                    Billing ZIP: {customer.billingZip}
                </Typography>
                <Typography variant="h6" component="div">
                    Billing Country: {customer.billingCountry}
                </Typography>
                <Typography variant="h6" component="div">
                    Billing City: {customer.billingCity}
                </Typography>
                <Typography variant="h6" component="div">
                    Billing Address: {customer.billingAddress}
                </Typography>
                <Typography variant="h6" component="br"></Typography>
                <Typography variant="h6" component="div">
                    Shipping ZIP: {customer.shippingZip}
                </Typography>
                <Typography variant="h6" component="div">
                    Shipping Country: {customer.shippingCountry}
                </Typography>
                <Typography variant="h6" component="div">
                    Shipping City: {customer.shippingCity}
                </Typography>
                <Typography variant="h6" component="div">
                    Shipping Address: {customer.shippingAddress}
                </Typography>
            </CardContent>
            <CardActions>
                <Button size="small" onClick={() => navigate(-1)}>Go Back</Button>
            </CardActions>
        </Card>
    );
}

export default Profile;