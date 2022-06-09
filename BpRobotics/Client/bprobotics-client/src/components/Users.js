import { useState, useEffect } from 'react';
import MaterialTable from "material-table";
import UserForm from './UserForm';

function Users() {
    const [userList, setUserList] = useState();
    const columns = [
        {title: "Username", field: "userName"},
        {title: "First Name", field: "firstName"},
        {title: "Last Name", field: "lastName"},
        {
            title: "Role",
            field: "role",
            render: rowData => {
                switch (rowData.role) {
                    case 0:
                        return "Admin"
                    case 1:
                        return "Partner"
                    case 2:
                        return "Customer"
                    default:
                        return "Undefined"
                }
            }
        }
    ]

    async function loadUsers() {
        const response = await fetch(`${process.env.REACT_APP_HOST_URL}/users`);
        const data = await response.json();
        setUserList(data);
    }

    useEffect(() => {
        loadUsers();
    }, [])

    return (
    <div>
        <UserForm onCreate={loadUsers} />
        <MaterialTable
            title="List of users"
            data={userList} columns={columns}
        />
    </div>
    );
}

export default Users;