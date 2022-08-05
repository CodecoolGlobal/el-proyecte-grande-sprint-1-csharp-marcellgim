import { Table, Card } from 'react-bootstrap';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import { faPlay, faCircleCheck, faCircleInfo } from "@fortawesome/free-solid-svg-icons";
import useAxios from "../hooks/useAxios";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Button from 'react-bootstrap/Button';
import { useState, React } from 'react';
import Modal from 'react-bootstrap/Modal';
import 'bootstrap/dist/css/bootstrap.min.css';
import Form from 'react-bootstrap/Form';


const url = "/api/service";
const devicesUrl = "/api/devices";


function ServicesView() {
  const axiosInstance = useAxios();
  const [show, setShow] = useState(false);
  const [showUpdate, setShowUpdate] = useState(false);

  const [details, setDetails] = useState("");
  const [deviceId, setDeviceId] = useState(0);
  const [deviceSerial, setDeviceSerial] = useState("");




  const handleClose = () => setShow(false);
  const handleCloseUpdate = () => setShowUpdate(false);


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

  const showDetails = (id) => {
    setShow(true);
    setDetails(services.filter(service => service.id === id)[0].details);
    setDeviceId(services.filter(service => service.id === id)[0].device.id);
    setDeviceSerial(services.filter(service => service.id === id)[0].device.serial);
  }

  const updateSerialClick = () => {
    setShow(false);
    setShowUpdate(true);
  }

  const handleSubmit = async (e) => {
    e.preventDefault();
    setShowUpdate(false);
    try {
        await axiosInstance.put(`${devicesUrl}/${deviceId}/UpdateSerial`, { serial: deviceSerial })
    } catch (err) {
        console.log(`Error: ${err.message}`);
    }
}

  return (
    <>
    <Card body>
      <Table>
        <thead>
          <tr>
            {columns.map((column, index) => <th key={index}>{column.title}</th>)}
            <th>Start</th>
            <th>Finish</th>
            <th>Details</th>
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
                <td>
                  <Button onClick={() => { showDetails(service.id) }}>
                    <FontAwesomeIcon icon={faCircleInfo} />
                  </Button>
                </td>
              </tr>
            </>
          ))}
        </tbody>
      </Table>
    </Card>
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
          <Modal.Title>Service details</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {details}
      </Modal.Body>
      <Modal.Footer>
          <Button variant="primary" onClick={updateSerialClick}>
              Update serial
          </Button>
          <Button variant="secondary" onClick={handleClose}>
              Close
          </Button>
      </Modal.Footer>
    </Modal>
    <Modal show={showUpdate} onHide={handleCloseUpdate}>
      <Modal.Header closeButton>
          <Modal.Title>Update serial</Modal.Title>
      </Modal.Header>
      <Form onSubmit={(e)=>{handleSubmit(e)}} className="form">

      <Modal.Body>

          <Form.Label>Serial:</Form.Label>
            <Form.Control 
                type="text" 
                placeholder="Serial number" 
                value={deviceSerial} 
                onChange={(e) => setDeviceSerial(e.target.value)} 
            />
      </Modal.Body>
      <Modal.Footer>
          <Button variant="primary" type="submit">Update</Button>
          <Button variant="secondary" onClick={handleCloseUpdate}>
              Close
          </Button>
      </Modal.Footer>
      </Form>

    </Modal>
    </>
  );
}

export default ServicesView;
