import { useState, useEffect } from "react";
import MaterialTable from "material-table";
import { render } from "@testing-library/react";

function Orders() {
    const url = `${process.env.REACT_APP_HOST_URL}/api/orders`;
    const [fetchData, setData] = useState([]);

    useEffect(()=> {
        fetch(`${url}`)
    .then(response => response.json())
    .then(data=>{
      console.log(data);
      setData(data);
    }).catch( err=> {
      console.log("Error Reading data " + err);
    })
    },[])

    return ( 
        <div style={{ maxWidth: '100%' }}>
            <MaterialTable
            columns={[
                { title: 'Date', field: 'date' },
                { title: 'Company Name', field: 'customer.companyName' },
                { title: 'Address', render: (rowData) => rowData.address.country+","+rowData.address.city+","+rowData.address.address+","+rowData.address.zip },
                { title: 'Devices', render: (rowData) => <div>{(rowData.devices.map(device =><><div>{device.product.name},</div><br/></>))}</div>}
            ]}
            data={fetchData}
            title="Orders"

            />
        </div>
     );
}

export default Orders;