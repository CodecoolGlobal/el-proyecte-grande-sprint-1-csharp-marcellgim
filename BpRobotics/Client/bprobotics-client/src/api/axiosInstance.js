import axios from "axios";

const BASE_URL = `${process.env.REACT_APP_HOST_URL}/api`

export default axios.create({
    baseURL: BASE_URL,
    headers: {'Content-Type': 'application/json' }
})