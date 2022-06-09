import { useState, useEffect } from 'react';
import MaterialTable from 'material-table';
import { useNavigate } from "react-router-dom";
function Products() {
    let url = `${process.env.REACT_APP_HOST_URL}/api/products`;
    const [productData, setProductData] = useState([]);
    let navigate = useNavigate(); 
  function routeChange(productId){ 
    let path = productId.toString(); 
    navigate(path);
  }
    const fetchProductData = async (url) => {
        const res = await fetch(url);
        const data = await res.json();
        return data;
      }
    
      useEffect(() => {
        const getProductData = async (url) => {
          const productDataFromApi = await fetchProductData(url);
          setProductData(productDataFromApi);
        }
        getProductData(url);
      }, [url])
    return ( <MaterialTable
        title="Products"
        columns={[
            { title: '',
            field: 'img',
            render: item => <img onClick={() => routeChange(item.id)} src={`${process.env.REACT_APP_HOST_URL}/StaticFiles/images/${item.img}`} alt="" height="100" width="100" />,
            filtering: false
        },
          { title: 'Name', field: 'name' },
          { title: 'Description', field: 'shortDescription' },
        ]}
        data={productData}        
        options={{
          filtering: true
        }}
      /> );
}

export default Products;