import { useState, useEffect } from 'react';
import { useNavigate, useParams } from "react-router-dom";
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
function Products() {
  const { id } = useParams();
    let url = `${process.env.REACT_APP_HOST_URL}/api/products/${id}`;
    const [productDetailsData, setProductDetailsData] = useState([]);
    let navigate = useNavigate(); 
    const fetchProductDetailsData = async (url) => {
        const res = await fetch(url);
        const data = await res.json();
        return data;
      }
    
      useEffect(() => {
        const getProductDetailsData = async (url) => {
          const productDetailsDataFromApi = await fetchProductDetailsData(url);
          setProductDetailsData(productDetailsDataFromApi);
        }
        getProductDetailsData(url);
      }, [url])
    return (
    <Card sx={{ maxWidth: 800 }}>
      <CardMedia
        component="img"

        image={`https://bproboticsimages.blob.core.windows.net/images/${productDetailsData.imageFileName}`}
        alt={productDetailsData.name}
      />
      <CardContent>
        <Typography gutterBottom variant="h3" component="div">
        {productDetailsData.name}
        </Typography>
        <Typography gutterBottom variant="h6" component="div">
        {productDetailsData.shortDescription}
        </Typography>
        <Typography variant="body2" color="text.secondary">
        {productDetailsData.longDescription}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small" onClick={() => navigate(-1)}>Go Back</Button>
      </CardActions>
    </Card>);
}

export default Products;