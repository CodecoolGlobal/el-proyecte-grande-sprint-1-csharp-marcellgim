import { Table, Button } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";


function Services({ services }) {
    const render = (input) => input; // Default render
    const dateRender = (date) => (date !== null) ? new Date(date).toLocaleDateString() : "-";

    const columns = [
        { title: "Partner", field: "assignedFor", render: (partner) => partner?.companyName ?? "-"},
        { title: "Requested on", field: "requestedDate", render: dateRender },
        { title: "Done on", field: "doneDate", render: dateRender},
        { title: "Service Type", field: "type", render},
        { title: "Status", field: "status", render}
    ]

    if (services.length === 0) {
        return <h3>No services</h3>
    }

    return (
        <Table>
            <thead>
                <tr>
                    {columns.map((column, index) => <th key={index}>{column.title}</th>)}
                </tr>
            </thead>
            <tbody>
                {services.map(service => (
                    <>
                        <tr key={service.id}>
                            {columns.map((column, index) => (
                                <td key={index}>{column.render(service[column.field])}</td>
                            ))}
                            <td><Button variant="danger"><FontAwesomeIcon icon={faTrash} /></Button></td>
                        </tr>
                    </>
				))}
            </tbody>
        </Table>
    );
}

export default Services;