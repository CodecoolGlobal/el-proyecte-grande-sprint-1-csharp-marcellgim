import MaterialTable from "material-table";
import { useEffect, useState } from "react";
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";

function Customers() {

	const url = `${process.env.REACT_APP_HOST_URL}/api/customers`;
	const { data } = useAxiosFetchGet(url);

	const [customersData, setCustomersData] = useState([]);
	
	useEffect(() => {
		setCustomersData(data);
	}, [data]);

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

export default Customers;
