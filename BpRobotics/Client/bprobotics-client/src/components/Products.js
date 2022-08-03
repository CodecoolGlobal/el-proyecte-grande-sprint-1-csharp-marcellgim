import { useState, React } from 'react';
import '../App.css';
import { useNavigate } from "react-router-dom";
import ProductModal from './ProductModal';
import { Button, Alert, Card } from 'react-bootstrap';
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
  const {auth} = useAuth();

    let url = `${process.env.REACT_APP_HOST_URL}/api/products`;
    const [show, setShow] = useState(false);
    const handleOpen = () => setShow(true);
    const isAdmin = auth?.role === "Admin";
    
    let navigate = useNavigate(); 
  function routeChange(productId){ 
    let path = productId.toString(); 
    navigate(path);
  }
	const { data: productData, setData: setProductData, fetchError, isLoading } = useAxiosFetchGet(url);
  
  

    const forceUpdate = (product) => {
      setProductData([...productData, product])
    }
    const deleteProduct = async (productId) => {
      setProductData(productData.filter(product => product.id !== productId))
      await axios.delete(url + `/${productId}`)
  }
  const renderProduct = (product) => {
    return (
      <Tr>
        <Td className="clickable bordered"><img onClick={() => routeChange(product.id)} src={`https://bproboticsimages.blob.core.windows.net/images/${product.imageFileName}`} alt="" width="100" /></Td>
        <Td className="bordered"><strong>{product.name}</strong></Td>
        <Td className="bordered">{product.shortDescription}</Td>
        {isAdmin && <Td className="bordered"><Button onClick={() => deleteProduct(product.id)} variant="danger"><FontAwesomeIcon icon={faTrash} /></Button></Td>}

      </Tr>
    )
  }
    return ( <Card body>
    <ProductModal show={show} setShow={setShow} onCreate={forceUpdate}></ProductModal>
    <Table>
      <Thead>
        <Tr>
          <Th className="bordered"></Th>
          <Th className="bordered">Name</Th>
          <Th className="bordered">Description</Th>
          {isAdmin && <Th className="bordered">Delete</Th>}
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
      </Card> );
}

export default Products;