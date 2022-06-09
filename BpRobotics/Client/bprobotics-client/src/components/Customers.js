import MaterialTable from "material-table";
import { useEffect, useState } from "react";

function Customers() {
  const url = `${process.env.REACT_APP_HOST_URL}/customers`;
  const [customersData, setCustomersData] = useState([]);
  
  useEffect(() => {
    ApiGet(url).then(dataFromApi => setCustomersData(dataFromApi));
  }, [url]);

  return (
    <MaterialTable
      title="Customers"
      columns={[
        { title: 'Company Name', field: 'companyName' },
        { title: 'VAT Number', field: 'vatNumber', type: 'numeric' },
        { title: 'Billing Address',
          field: 'billingAddress',
          render: rowData => (<div>
            {rowData.billingAddress.zip}{" "}
            {rowData.billingAddress.country}{", "}
            {rowData.billingAddress.city}{" "}
            {rowData.billingAddress.address}
          </div>)
        },
        { title: 'Shipping Address',
          field: 'shippingAddress', 
          render: rowData => (<div>
            {rowData.shippingAddress.zip}{" "}
            {rowData.shippingAddress.country}{", "}
            {rowData.shippingAddress.city}{" "}
            {rowData.shippingAddress.address}
          </div>)
        }
      ]}
      data={customersData}
      options={{
        filtering: true,
        sorting: true
      }}
    />
  )
}

async function ApiGet(url) {
  const response = await fetch(url);
  return response.ok ? await response.json() : null;
}

export default Customers;
