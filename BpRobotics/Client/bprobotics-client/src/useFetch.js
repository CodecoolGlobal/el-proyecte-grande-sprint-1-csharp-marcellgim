import React, { useEffect, useState } from 'react'
import axios from 'axios'

function useFetch() {

    axios.defaults.baseURL = 'https://localhost:5001/potions';
    axios.defaults.headers.post['Content-Type'] = 'application/json';

    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    // useEffect(() => {
    //     setLoading(true);
    //     axios.get(url)
    //     .then((response)=> {
    //         setData(response.data)
    //     })
    //     .catch((err) => {
    //         setError(err);
    //     })
    //     .finally(() => {
    //         setLoading(false);
    //     })
    // }, [url]);

    const getFetch = async (url) => {
        setLoading(true);
        await axios
        .get(url)
        .then((response)=> {
            setData(response.data)
        })
        .catch((err) => {
            setError(err);
        })
        .finally(() => {
            setLoading(false);
        })
    }

    const postFetch = async (postUrl, body) => {
        setLoading(true);
        await axios
        .post(postUrl, body)
        .then((response)=> {
            console.log(response);
        })
        .catch((err) => {
            setError(err);
        })
        .finally(() => {
            setLoading(false);
        })
    }
    
    return { data, loading, error, getFetch, postFetch }
}

export default useFetch