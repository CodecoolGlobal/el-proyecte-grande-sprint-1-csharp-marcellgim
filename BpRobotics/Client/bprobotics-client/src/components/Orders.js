import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import { Table, Alert } from "react-bootstrap";
import LoadingSpin from "react-loading-spin";
import { useNavigate } from "react-router-dom";

function Orders() {

	const url = "/api/orders";
	const { data: orders, isLoading, fetchError } = useAxiosFetchGet(url);
	const render = (input) => input; // Default render
	const columns= [
		{ title: 'Date', field: 'date', render: (date) => new Date(date).toLocaleString()},
		{ title: 'Company Name', field: 'customerCompanyName', render },
		{ title: 'Address', field: 'address', render },
		{ title: 'Devices', field: 'devices', render: (devices) => <div>{Object.keys(devices).map((device, index) => <div key={index}>{device}: {devices[device]}</div>)}</div>}
	];
	const url = `${process.env.REACT_APP_HOST_URL}/api/orders`;
	const { data } = useAxiosFetchGet(url);
	const navigate = useNavigate();

	return ( 
		<Table striped="columns">
            <thead>
                <tr>
                {columns.map((column, index) => <th key={index}>{column.title}</th>)}
                </tr>
            </thead>
            <tbody>
                {isLoading && <tr><td><LoadingSpin /></td></tr>}
				{fetchError && <tr><td><Alert variant='danger'>{fetchError}</Alert></td></tr>}
                {orders.map(order => (
                    <tr key={order.id}>
                        {columns.map((column, index) => (
							<td key={index}>{column.render(order[column.field])}</td>
						))}
                    </tr>
				))}
            </tbody>
        </Table>
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