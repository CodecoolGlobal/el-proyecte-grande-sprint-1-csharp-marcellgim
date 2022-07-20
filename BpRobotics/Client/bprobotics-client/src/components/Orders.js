import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import { Table, Alert } from "react-bootstrap";
import LoadingSpin from "react-loading-spin";

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

	return ( 
		<Table striped="columns">
            <thead>
                <tr>
                {columns.map((column, index) => <th key={index}>{column.title}</th>)}
                </tr>
            </thead>
            <tbody>
                {isLoading && <tr><td><LoadingSpin /></td></tr>}
				{fetchError && <Alert variant='danger'>{fetchError}</Alert>}
                {orders.map(order => (
                    <tr key={order.id}>
                        {columns.map((column, index) => (
							<td key={index}>{column.render(order[column.field])}</td>
						))}
                    </tr>
				))}
            </tbody>
        </Table>
	);
}

export default Orders;