import { useState, useEffect } from 'react';
import { useNavigate, useParams } from "react-router-dom";
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from 'react-bootstrap/Button';
import Typography from '@mui/material/Typography';

function UserDetails() {
    const { id } = useParams();
    const [userDetails, setUserDetails] = useState([]);
    let navigate = useNavigate();

    let url = `${process.env.REACT_APP_HOST_URL}/api/users/${id}`;

    const loadUser = async (url) => {
        const res = await fetch(url);
        const data = await res.json();
        setUserDetails(data);
    }
    
    useEffect(() => {
        loadUser(url);
    }, [url])

    return (
    <Card sx={{ maxWidth: 800 }}>
      <CardContent>
        <Typography gutterBottom variant="h3" component="div">
            {userDetails.userName}
        </Typography>
        <Typography gutterBottom variant="h6" component="div">
            {userDetails.firstName}
        </Typography>
        <Typography variant="body2" color="text.secondary">
            {userDetails.lastName}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small" onClick={() => navigate(-1)}>Go Back</Button>
      </CardActions>
    </Card>
    );
}

export default UserDetails;