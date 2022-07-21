import { useState, useEffect, React } from 'react';
import '../App.css';
import { useNavigate } from "react-router-dom";
import ProductModal from './ProductModal';
import { Button, Alert } from 'react-bootstrap';
import LoadingSpin from "react-loading-spin";
import { Table, Thead, Tbody, Tr, Th, Td } from 'react-super-responsive-table';
import 'react-super-responsive-table/dist/SuperResponsiveTableStyle.css';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import useAxios from '../hooks/useAxios';
import useAuth from "../hooks/useAuth";


function Products() {
  const axios = useAxios();
  const auth = useAuth();

    let url = `${process.env.REACT_APP_HOST_URL}/api/products`;
    const [productData, setProductData] = useState([]);
    const [show, setShow] = useState(false);
    const handleOpen = () => setShow(true);
    const isAdmin = auth.auth?.role=="Admin";
    
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
    const deleteProduct = async (productId) => {
      setData(data.filter(product => product.id !== productId))
      await axios.delete(url + `/${productId}`)
  }
  const renderProduct = (product) => {
    return (
      <Tr>
        <Td className="clickable"><img onClick={() => routeChange(product.id)} src={`https://bproboticsimages.blob.core.windows.net/images/${product.imageFileName}`} alt="" width="100" /></Td>
        <Td>{product.name}</Td>
        <Td>{product.shortDescription}</Td>
        {isAdmin && <Td><Button onClick={() => deleteProduct(product.id)} variant="danger"><FontAwesomeIcon icon={faTrash} /></Button></Td>}

      </Tr>
    )
  }
    return ( <>
    <ProductModal show={show} setShow={setShow} onCreate={forceUpdate}></ProductModal>
    <Table>
      <Thead>
        <Tr>
          <Th></Th>
          <Th>Name</Th>
          <Th>Description</Th>
          {isAdmin && <Th>Delete</Th>}
        </Tr>
      </Thead>
      <Tbody>
      
        {productData.map(renderProduct)}
      </Tbody>
    </Table>
    {isLoading && <h1><LoadingSpin /></h1>}
				{fetchError && <Alert variant='danger'>{fetchError}</Alert>}
    <br></br>
    
    {isAdmin && <Button variant="secondary" onClick={handleOpen}>New product</Button>}
      </> );
}

export default Products;