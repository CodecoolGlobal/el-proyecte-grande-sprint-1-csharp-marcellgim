import { useState } from 'react';

function UserForm() {

    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [role, setRole] = useState(0);

    async function handleSubmit(event) {
        event.preventDefault()
        const response = await fetch(
            `${process.env.REACT_APP_HOST_URL}/users`,
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    username: userName,
                    hashedpassword: password,
                    firstname: firstName,
                    lastname: lastName,
                    role: role
                })
            }
        )

        if (response.status === 200) {
            setUserName("")
            setFirstName("")
            setLastName("")
            setPassword("")
            setRole(0)
        }

        dispatchEvent(new CustomEvent("create"))

    }

    return (
    <form onSubmit={handleSubmit}>
        <label>
            Username:
            <input type="text" onChange={(e) => setUserName(e.target.value)}/>
        </label>
        <label>
            Password:
            <input type="password" onChange={(e) => setPassword(e.target.value)} />
        </label>
        <label>
            First Name:
            <input type="text" onChange={(e) => setFirstName(e.target.value)}/>
        </label>
        <label>
            Last Name:
            <input type="text" onChange={(e) => setLastName(e.target.value)} />
        </label>
        <label>
            Role:
            <select value={role} onChange={(e) => setRole(parseInt(e.target.value))}>
                <option value="0">Admin</option>
                <option value="1">Partner</option>
                <option value="2">Customer</option>
            </select>
        </label>
        <input type="submit" value="Create user" />
    </form>
    );
}

export default UserForm;