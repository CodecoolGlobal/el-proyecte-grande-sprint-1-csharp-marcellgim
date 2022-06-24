import MaterialTable from "material-table";
import { useEffect, useState } from "react";

function Customers() {
  const url = `${process.env.REACT_APP_HOST_URL}/api/customers`;
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
