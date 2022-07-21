import { useState } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.min.css';
import useAxiosFetchGet from '../hooks/useAxiosFetchGet';

function UserForm({ postData, deviceId, deviceIndex }) {
    const { data: partners } = useAxiosFetchGet("/api/partners");
    const [type, setType] = useState("Install");
    const [partnerId, setPartnerId] = useState(null);

    const handleSubmit = (event) => {
        event.preventDefault();
        postData(deviceId, {
            type: type,
            partnerId: partnerId === "" ? null : partnerId
        });
    }

    return (
    <Form onSubmit={handleSubmit}>
        <Form.Group>
            <Form.Label>Service type:</Form.Label>
            <Form.Select value={type} onChange={(e) => setType(e.target.value)}>
                <option value="Install">Install</option>
                <option value="Repair">Repair</option>
                <option value="Maintenance">Maintenance</option>
                <option value="RemoteAssistance">Remote Assistance</option>
            </Form.Select>
        </Form.Group>
        <Form.Group>
            <Form.Label>Assign partner:</Form.Label>
            <Form.Select value={partnerId} onChange={(e) => setPartnerId(+e.target.value)}>
                <option value="">-</option>
                {partners.map(partner => <option key={partner.id} value={partner.id}>{partner.companyName}</option>)}
            </Form.Select>
        </Form.Group>
        <Button variant="primary" type="submit" value="Create user">Add Service</Button>
    </Form>
    );
}

export default UserForm;