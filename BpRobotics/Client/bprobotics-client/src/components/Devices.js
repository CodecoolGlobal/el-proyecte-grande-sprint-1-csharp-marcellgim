import { Table, Alert } from "react-bootstrap";
import LoadingSpin from "react-loading-spin";
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import Device from "./Device";
import CreateModal from "./CreateModal";
import ServiceForm from "./ServiceForm";
import useAxios from "../hooks/useAxios";
import useAuth from "../hooks/useAuth";


const DEVICES_ENDPOINT = "/api/devices";

function Devices() {
    const { data: devices, setData: setDevices, isLoading, fetchError } = useAxiosFetchGet(DEVICES_ENDPOINT);
    const { auth } = useAuth();
    const axios = useAxios();
    const render = (input) => input; // Default render
    const dateRender = (date) => (date !== "-") ? new Date(date).toLocaleDateString() : "-";


    const columns = [
        { title: "Serial Number", field: "serial", render: (serial) => serial ?? "-"},
        { title: "Product", field: "productName", render },
        { title: "Last Maintenance", field: "lastMaintenance", render: dateRender},
        { title: "Next Maintenance", field: "nextMaintenance", render: dateRender},
        { title: "Warranty Expires", field: "warrantyUntil", render: dateRender},
        { title: "Device Status", field: "status", render}
    ]

    const postData = async (deviceId, data) => {
        const response = await axios.post(DEVICES_ENDPOINT + `/${deviceId}/services`, data);
        const newState = devices.map(device => {
            if (device.id === deviceId) {
                device.services = [...device.services, response.data];
            }
            return device;
        })
        setDevices([...newState]);
    }

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
                {devices.map(device => (
                    <>
                        <Device device={device} columns={columns}>
                            {auth?.role === "Admin" && <CreateModal typeName="service"><ServiceForm deviceId={device.id} postData={postData} /></CreateModal>}
                        </Device>
                    </>
                ))}
            </tbody>
        </Table>
    );
}

export default Devices;