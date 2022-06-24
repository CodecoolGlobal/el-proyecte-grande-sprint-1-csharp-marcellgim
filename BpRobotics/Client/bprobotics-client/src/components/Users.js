import { useState, useEffect } from 'react';
import MaterialTable from "material-table";
import UserForm from './UserForm';
import CreateModal from './CreateModal';
import { Link } from 'react-router-dom'

function Users() {
    const [userList, setUserList] = useState();
    const columns = [
        {
            title: "Username",
            field: "userName",
            render: rowData => {
                return <Link to={`./${rowData.id}`}>{rowData.userName}</Link>
            }
        },
        { title: "First Name", field: "firstName" },
        { title: "Last Name", field: "lastName" },
        { title: "Role", field: "role" }
    ]

    async function loadUsers() {
        const response = await fetch(`${process.env.REACT_APP_HOST_URL}/api/users`);
        const data = await response.json();
        setUserList(data);
    }

    useEffect(() => {
        loadUsers();
    }, [])

    return (
    <div>
        <CreateModal typeName="User" FormComponent={UserForm} onCreate={loadUsers} />
        <MaterialTable
            title="List of users"
            data={userList} columns={columns}
        />
    </div>
    );
}

export default Users;