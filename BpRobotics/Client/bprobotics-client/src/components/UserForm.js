import { useState } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.min.css';

function UserForm({ postData }) {

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [role, setRole] = useState("Admin");

    const handleSubmit = (event) => {
        event.preventDefault();
        postData({
            username: userName,
            password: password,
            firstname: firstName,
            lastname: lastName,
            role: role
        });
    }

    return (
    <Form onSubmit={handleSubmit}>
        <Form.Group className='mb-10'>
            <Form.Label>Username:</Form.Label>
            <Form.Control type="text" onChange={(e) => setUserName(e.target.value)}/>
        </Form.Group>
        <Form.Group>
            <Form.Label>Password:</Form.Label>
            <Form.Control type="password" onChange={(e) => setPassword(e.target.value)} />
        </Form.Group>
        <Form.Group>
            <Form.Label>First Name:</Form.Label>
            <Form.Control type="text" onChange={(e) => setFirstName(e.target.value)}/>
        </Form.Group>
        <Form.Group>
            <Form.Label>Last Name:</Form.Label>
            <Form.Control type="text" onChange={(e) => setLastName(e.target.value)} />
        </Form.Group>
        <Form.Group>
            <Form.Label>Role:</Form.Label>
            <Form.Select value={role} onChange={(e) => setRole(e.target.value)}>
                <option value="Admin">Admin</option>
                <option value="Partner">Partner</option>
                <option value="Customer">Customer</option>
            </Form.Select>
        </Form.Group>
        <Button variant="primary" type="submit" value="Create user">Create User</Button>
    </Form>
    );
}

export default UserForm;