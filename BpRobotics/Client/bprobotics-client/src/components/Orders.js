import { useState, useEffect } from "react";
import MaterialTable from "material-table";
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";

function Orders() {

	const url = `${process.env.REACT_APP_HOST_URL}/api/orders`;
	const { data } = useAxiosFetchGet(url);

	const [fetchData, setData] = useState([]);

	useEffect(()=> {
		setData(data)
	},[data])

	return ( 
		<div style={{ maxWidth: '100%' }}>
			<MaterialTable
			columns={[
				{ title: 'Date', field: 'date' },
				{ title: 'Company Name', field: 'customerCompanyName' },
				{ title: 'Address', field: 'address' },
					{ title: 'Devices', render: (rowData) => <div>{(rowData.devices.map(device => <><div>{device.product.name},</div><br /></>))}</div> }
			]}
			data={fetchData}
			title="Orders"
			/>
		</div>
	);
}

export default Orders;