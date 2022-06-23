import {useState, useEffect} from 'react';
import axios from 'axios';

const useAxiosFetchGet = (dataUrl) => {
     const [getData, setGetData] = useState([]);
     const [fetchGetError, setFetchGetError] = useState(null);
     const [isLoading, setIsLoading] = useState(false);

     useEffect(() => {
        let isMounted = true;
        const source = axios.CancelToken.source();

        const fetchData = async (url) => {
            setIsLoading(true);
            try {
                const response = await axios.get(url, {
                    cancelToken: source.token
                });
                if (isMounted) {
                    setGetData(response.data);
                    setFetchGetError(null);
                }
            } catch (err) {
                if (isMounted) {
                    setFetchGetError(err.message);
                    setGetData([]);
                }
            } finally {
                isMounted && setTimeout(() => setIsLoading(false), 1000);
            }
        }

        fetchData(dataUrl);

        const cleanUp = () => {
            isMounted = false;
            source.cancel();
        }

        return cleanUp;
     }, [dataUrl])

     return { data: getData, fetchError: fetchGetError, isLoading };
}

export default useAxiosFetchGet