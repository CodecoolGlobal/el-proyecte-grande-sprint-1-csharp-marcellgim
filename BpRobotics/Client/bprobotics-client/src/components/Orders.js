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
		{ title: 'Devices', field: 'devices', render: (devices) => <div>{Object.keys(devices).map(device => <div>{device}: {devices[device]}</div>)}</div>}
	];

	return ( 
		<Table striped="columns">
            <thead>
                <tr>
                {columns.map((column, index) => <th key={index}>{column.title}</th>)}
                </tr>
            </thead>
            <tbody>
                {isLoading && <h1><LoadingSpin /></h1>}
				{fetchError && <Alert variant='danger'>{fetchError}</Alert>}
                {orders.map(order => (
                    <tr key={order.id}>
                        {columns.map((column, index) => (
							<th key={index}>{column.render(order[column.field])}</th>
						))}
                    </tr>
				))}
            </tbody>
        </Table>
	);
}

export default Orders;