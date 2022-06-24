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
				// { title: 'Billing Address',
				// field: 'billingAddress',
				// render: rowData => (<div>
				// 	{rowData.billingAddress.zip}{" "}
				// 	{rowData.billingAddress.country}{", "}
				// 	{rowData.billingAddress.city}{" "}
				// 	{rowData.billingAddress.address}
				// </div>)
				// },
				// { title: 'Shipping Address',
				// field: 'shippingAddress', 
				// render: rowData => (<div>
				// 	{rowData.shippingAddress.zip}{" "}
				// 	{rowData.shippingAddress.country}{", "}
				// 	{rowData.shippingAddress.city}{" "}
				// 	{rowData.shippingAddress.address}
				// </div>)
				// }
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
