import { useState, useEffect, React } from 'react';
import { useNavigate } from "react-router-dom";
import ProductModal from './ProductModal';
import Button from '@mui/material/Button';
import { Table, Thead, Tbody, Tr, Th, Td } from 'react-super-responsive-table';
import 'react-super-responsive-table/dist/SuperResponsiveTableStyle.css';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";

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
	const { data, setData, fetchError, isLoading } = useAxiosFetchGet(url);
  
  useEffect(() => {
    setProductData(data);
	}, [data])

    const forceUpdate = (product) => {
      setData([...data, product])
    }

  const renderProduct = (product) => {
    return (
      <Tr>
        <Td><img onClick={() => routeChange(product.id)} src={`https://bproboticsimages.blob.core.windows.net/images/${product.imageFileName}`} alt="" width="100" /></Td>
        <Td>{product.name}</Td>
        <Td>{product.shortDescription}</Td>
      </Tr>
    )
  }
    return ( <>
    <Button variant="primary" onClick={handleOpen}>New</Button>
    <ProductModal show={show} setShow={setShow} onCreate={forceUpdate}></ProductModal>
    <Table>
      <Thead>
        <Tr>
          <Th>Image</Th>
          <Th>Name</Th>
          <Th>Short Description</Th>
        </Tr>
      </Thead>
      <Tbody>
        {productData.map(renderProduct)}
      </Tbody>
    </Table>
      </> );
}

export default Products;