import { useLocation, useNavigate } from "react-router-dom";
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from 'react-bootstrap/Button';
import Typography from '@mui/material/Typography';

function UserDetails() {
    const location = useLocation();
	const user = location.state;
    let navigate = useNavigate();

    return (
		<Card sx={{ maxWidth: 800 }}>
		<CardContent>
			<Typography gutterBottom variant="h3" component="div">
				{user.userName}
			</Typography>
			<Typography gutterBottom variant="h6" component="div">
				{user.firstName}
			</Typography>
			<Typography variant="body2" color="text.secondary">
				{user.lastName}
			</Typography>
		</CardContent>
		<CardActions>
			<Button size="small" onClick={() => navigate(-1)}>Go Back</Button>
		</CardActions>
		</Card>
    );
}

export default UserDetails;