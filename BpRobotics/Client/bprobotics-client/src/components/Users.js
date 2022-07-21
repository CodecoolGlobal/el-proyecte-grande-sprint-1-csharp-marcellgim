import useAxiosFetchGet from '../hooks/useAxiosFetchGet';
import UserForm from './UserForm';
import CreateModal from './CreateModal';
import { Link } from "react-router-dom"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import LoadingSpin from "react-loading-spin";
import { Table, Button, Alert } from 'react-bootstrap';
import useAxios from '../hooks/useAxios';

const USERS_URL = "/api/users"

function Users() {
    const axios = useAxios();
    const { data: users, setData: setUsers, isLoading, fetchError } = useAxiosFetchGet(USERS_URL);
    const columns = ["Username", "First Name", "Last Name", "Role"]
    
    const postData = async (data) => {
        const response = await axios.post(USERS_URL, data);
        setUsers([...users, response.data]);
    }

    const deleteUser = async (userId) => {
        setUsers(users.filter(user => user.id !== userId))
        await axios.delete(USERS_URL + `/${userId}`)
    }

    return (
    <>
        <CreateModal typeName="user"><UserForm postData={postData} /></CreateModal>
        <Table striped="columns">
            <thead>
                <tr>
                {columns.map((heading, index) => <th key={index}>{heading}</th>)}
                </tr>
            </thead>
            <tbody>
                {isLoading && <h1><LoadingSpin /></h1>}
				{fetchError && <Alert variant='danger'>{fetchError}</Alert>}
                {users.map(user => (
                    <tr key={user.id}>
                        <td><Link to={user.id.toString()} state={user}>{user.userName}</Link></td>
                        <td>{user.firstName}</td>
                        <td>{user.lastName}</td>
                        <td>{user.role}</td>
                        <td><Button onClick={() => deleteUser(user.id)} variant="danger"><FontAwesomeIcon icon={faTrash} /></Button></td>
                    </tr>
                ))}
            </tbody>
        </Table>
    </>
    );
}

export default Users;