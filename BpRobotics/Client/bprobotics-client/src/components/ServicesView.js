import { Table, Card } from 'react-bootstrap';
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
    { title: "Partner", field: "assignedFor", render: (partner) => partner?.companyName ?? "-" },
    { title: "Requested on", field: "requestedDate", render: dateRender },
    { title: "Done on", field: "doneDate", render: dateRender },
    { title: "Service Type", field: "type", render },
    { title: "Status", field: "status", render }
  ];

  const changeServiceStatus = async (id, change) => {
    try {
      await axiosInstance.put(`${url}/${id}/${change}`);
      services.filter(service => service.id === id)[0].status = change === "start" ? "InProgress" : "Done";
      if (change === "finish") {
        services.filter(service => service.id === id)[0].doneDate = new Date();
      }
      setServices([...services]);
    }
    catch (err) {
      console.log(`Error: ${err.message}`);
    }
  }

  return (
    <Card body>
      <Table>
        <thead>
          <tr>
            {columns.map((column, index) => <th key={index}>{column.title}</th>)}
            <th>Start</th>
            <th>Finish</th>
          </tr>
        </thead>
        <tbody>
          {services.map(service => (
            <>
              <tr key={service.id}>
                {columns.map((column, index) => (
                  <td key={index}>{column.render(service[column.field])}</td>
                ))}
                <td>
                  <Button disabled={service.status !== "Planned"} onClick={() => { changeServiceStatus(service.id, "start") }}>
                    <FontAwesomeIcon icon={faPlay} />
                  </Button>
                </td>
                <td>
                  <Button disabled={service.status !== "InProgress"} onClick={() => { changeServiceStatus(service.id, "finish") }}>
                    <FontAwesomeIcon icon={faCircleCheck} />
                  </Button>
                </td>
              </tr>
            </>
          ))}
        </tbody>
      </Table>
    </Card>
  );
}

export default ServicesView;
