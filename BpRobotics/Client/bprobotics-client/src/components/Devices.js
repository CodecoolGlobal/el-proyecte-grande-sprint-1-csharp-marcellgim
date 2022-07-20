import { Table, Alert } from "react-bootstrap";
import LoadingSpin from "react-loading-spin";
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import Device from "./Device";

const DEVICES_ENDPOINT = "/api/devices";

function Devices() {
    const { data: devices, isLoading, fetchError } = useAxiosFetchGet(DEVICES_ENDPOINT);
    const render = (input) => input; // Default render
    const dateRender = (date) => new Date(date).toLocaleDateString();

    const columns = [
        { title: "Serial Number", field: "serial", render: (serial) => serial ?? "-"},
        { title: "Product", field: "productName", render },
        { title: "Last Maintenance", field: "lastMaintenance", render: dateRender},
        { title: "Next Maintenance", field: "nextMaintenance", render: dateRender},
        { title: "Warranty Expires", field: "warrantyUntil", render: dateRender},
        { title: "Device Status", field: "status", render}
    ]

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
                {devices.map(device => <Device device={device} columns={columns} />)}
            </tbody>
        </Table>
    );
}

export default Devices;