import { useState, useEffect } from "react";
import MaterialTable from "material-table";
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import { useNavigate } from "react-router-dom";

function Orders() {

	const url = `${process.env.REACT_APP_HOST_URL}/api/orders`;
	const { data } = useAxiosFetchGet(url);
	const navigate = useNavigate();

	const [fetchData, setData] = useState([]);

	useEffect(()=> {
		setData(data)
	},[data])

	const handleClick = () => {
		navigate("/add-order");
	};

	return (
		<>
		<button type="button" className="btn btn-primary" onClick={handleClick}>Create new Order</button>
		<div style={{ maxWidth: '100%' }}>
			<MaterialTable
			columns={[
				{ title: 'Date', field: 'date', type: 'date', dateSetting: { locale: 'hu-HU' } },
				{ title: 'Company Name', field: 'customerCompanyName' },
				{ title: 'Address', field: 'address' },
				//{ title: 'Devices', field: 'devices', render: (rowData) => <div>{[...(rowData.devices)].map(device =><><div>{device},</div><br/></>)}</div>}
			]}
			data={fetchData}
			title="Orders"
			/>
		</div>
		</>
	);
}

export default Orders;