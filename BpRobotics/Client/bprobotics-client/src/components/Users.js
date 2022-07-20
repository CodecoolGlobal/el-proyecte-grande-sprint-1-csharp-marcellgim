import useAxiosFetchGet from '../hooks/useAxiosFetchGet';
import UserForm from './UserForm';
import CreateModal from './CreateModal';
import { Table } from 'react-bootstrap';
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

    if (isLoading) return (<h1>Loading...</h1>)

    return (
    <>
        <CreateModal typeName="user"><UserForm postData={postData} /></CreateModal>
        <Table>
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
                    </tr>
                ))}
            </tbody>
        </Table>
    </>
    );
}

export default Users;