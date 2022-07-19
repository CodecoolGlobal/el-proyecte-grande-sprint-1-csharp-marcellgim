import { useState, useEffect } from 'react';
import MaterialTable from 'material-table';
import { useNavigate } from "react-router-dom";
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";

import ProductModal from './ProductModal';
import Button from '@mui/material/Button';

function Products() {

	let url = `${process.env.REACT_APP_HOST_URL}/api/products`;

	const { data } = useAxiosFetchGet(url);

	const [productData, setProductData] = useState([]);

	let navigate = useNavigate(); 

	function routeChange(productId){ 
		let path = productId.toString(); 
		navigate(path);
	}

	useEffect(() => {
		setProductData(data);
	}, [data])
		
	return ( 
	<MaterialTable
		title="Products"
		columns={[
			{ title: '',
			field: 'img',
			render: item => <img onClick={() => routeChange(item.id)} src={`${process.env.REACT_APP_HOST_URL}/MyStaticFiles/images/${item.imageFileName}`} alt="" width="100" />,
			filtering: false
			},
			{ title: 'Name', field: 'name' },
			{ title: 'Description', field: 'shortDescription' },
		]}
		data={productData}        
		options={{
			filtering: true
		}}
	/> 
	);
}

export default Products;