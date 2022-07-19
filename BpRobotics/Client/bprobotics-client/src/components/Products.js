import { useState, useEffect } from 'react';
import MaterialTable from 'material-table';
import { useNavigate } from "react-router-dom";
import ProductModal from './ProductModal';
import Button from '@mui/material/Button';

function Products() {
    let url = `${process.env.REACT_APP_HOST_URL}/api/products`;
    const [productData, setProductData] = useState([]);
    const [show, setShow] = useState(false);
    const handleOpen = () => setShow(true);
    let navigate = useNavigate(); 
  function routeChange(productId){ 
    let path = productId.toString(); 
    navigate(path);
  }

    async function loadProducts() {
      const response = await fetch(url);
      const data = await response.json();
      setProductData(data);
  }

  useEffect(() => {
    loadProducts();
  }, [])
    return ( <>
    <Button variant="primary" onClick={handleOpen}>New</Button>
    <ProductModal show={show} setShow={setShow} onCreate={loadProducts}></ProductModal>
    <MaterialTable
        title="Products"
        columns={[
            { title: '',
            field: 'img',
            render: item => <img onClick={() => routeChange(item.id)} src={`https://bproboticsimages.blob.core.windows.net/images/${item.imageFileName}`} alt="" width="100" />,
            filtering: false
        },
          { title: 'Name', field: 'name' },
          { title: 'Description', field: 'shortDescription' },
        ]}
        data={productData}        
        options={{
          filtering: true
        }}
      /></> );
}

export default Products;