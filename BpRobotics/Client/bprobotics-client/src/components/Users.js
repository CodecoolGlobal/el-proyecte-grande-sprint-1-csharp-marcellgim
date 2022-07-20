import useAxiosFetchGet from '../hooks/useAxiosFetchGet';
import UserForm from './UserForm';
import CreateModal from './CreateModal';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { Table, Button } from 'react-bootstrap';
import useAxios from '../hooks/useAxios';

const USERS_URL = "/api/users"

function Users() {
    const axios = useAxios();
    const { data: users, setData: setUsers, isLoading } = useAxiosFetchGet(USERS_URL);
    const columns = ["Username", "First Name", "Last Name", "Role"]
    
    const postData = async (data) => {
        const response = await axios.post(USERS_URL, data);
        setUsers([...users, response.data]);
    }

    const deleteUser = async (userId) => {
        setUsers(users.filter(user => user.id !== userId))
        await axios.delete(USERS_URL + `/${userId}`)
    }

    if (isLoading) return (<h1>Loading...</h1>)

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
                {users.map(user => (
                    <tr key={user.id}>
                        <td>{user.userName}</td>
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