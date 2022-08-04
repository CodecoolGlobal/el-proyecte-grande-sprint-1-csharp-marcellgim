import { Link } from 'react-router-dom';
import { Table, Alert } from 'react-bootstrap';
import LoadingSpin from 'react-loading-spin';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import { faPlay, faCircleCheck } from "@fortawesome/free-solid-svg-icons";
import useAxios from "../hooks/useAxios";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Button from 'react-bootstrap/Button';





const url = "/api/service";

function ServicesView() {
	const axiosInstance = useAxios();

  const { data: services, setData: setServices, isLoading, fetchError } = useAxiosFetchGet(url);
  const render = (input) => input; // Default render
  const dateRender = (date) => (date !== null) ? new Date(date).toLocaleDateString() : "-";

  const columns = [
    { title: "Partner", field: "assignedFor", render: (partner) => partner?.companyName ?? "-"},
    { title: "Requested on", field: "requestedDate", render: dateRender },
    { title: "Done on", field: "doneDate", render: dateRender},
    { title: "Service Type", field: "type", render},
    { title: "Status", field: "status", render}
  ];

  const startService = async (id) => {
		try {
			await axiosInstance.put(`${url}/${id}/start`);
services.filter(service=>service.id===id)[0].status = "In progress";
			setServices([...services]);
		} catch (err) {
			console.log(`Error: ${err.message}`);
		}
	}

  const finishService = async (id) => {
		try {
			await axiosInstance.put(`${url}/${id}/finish`);
services.filter(service=>service.id===id)[0].status = "Done";

			setServices([...services]);
		} catch (err) {
			console.log(`Error: ${err.message}`);
		}
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
                            <Button onClick={() => { startService(service.id) }}>
														<FontAwesomeIcon icon={faPlay} />
													</Button>
													<Button onClick={() => { finishService(service.id) }}>
														<FontAwesomeIcon icon={faCircleCheck} />
													</Button>
                        </tr>
                    </>
				))}
            </tbody>
        </Table>
  );
}

export default ServicesView;
