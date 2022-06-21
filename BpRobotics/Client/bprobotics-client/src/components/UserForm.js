import { useState } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.min.css';

function UserForm({ postData }) {

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [role, setRole] = useState(0);
    const url = `${process.env.REACT_APP_HOST_URL}/api/users`

    const handleSubmit = (event) => {
        event.preventDefault();
        postData(url, {
            username: userName,
            hashedpassword: password,
            firstname: firstName,
            lastname: lastName,
            role: role
        });

        event.currentTarget.reset()
    }

    return (
    <Form onSubmit={handleSubmit}>
        <Form.Label>
            Username:
            <Form.Control type="text" onChange={(e) => setUserName(e.target.value)}/>
        </Form.Label>
        <Form.Label>
            Password:
            <Form.Control type="password" onChange={(e) => setPassword(e.target.value)} />
        </Form.Label>
        <Form.Label>
            First Name:
            <Form.Control type="text" onChange={(e) => setFirstName(e.target.value)}/>
        </Form.Label>
        <Form.Label>
            Last Name:
            <Form.Control type="text" onChange={(e) => setLastName(e.target.value)} />
        </Form.Label>
        <Form.Label>
            Role:
            <Form.Select value={role} onChange={(e) => setRole(parseInt(e.target.value))}>
                <option value="Admin">Admin</option>
                <option value="Partner">Partner</option>
                <option value="Customer">Customer</option>
            </Form.Select>
        </Form.Label>
        <Button variant="primary" type="submit" value="Create user">Create User</Button>
    </Form>
    );
}

export default UserForm;