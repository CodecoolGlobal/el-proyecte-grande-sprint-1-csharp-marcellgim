import {useState, useEffect} from 'react';
import axios from 'axios';

const useAxiosFetchPost = (dataUrl, postData) => {
     const [data, setData] = useState([]);
     const [fetchError, setFetchError] = useState(null);
     const [isLoading, setIsLoading] = useState(false);

     useEffect(() => {
        let isMounted = true;

        const fetchPostData = async (url, dataToPost) => {
            setIsLoading(true);
            try {
                const response = await axios.post(url, dataToPost);
                if (isMounted) {
                    setData(response.data);
                    setFetchError(null);
                }
            } catch (err) {
                if (isMounted) {
                    setFetchError(err.message);
                    setData([]);
                }
            } finally {
                isMounted && setTimeout(() => setIsLoading(false), 1000);
            }
        }

        fetchPostData(dataUrl, postData);

        const cleanUp = () => {
            isMounted = false;
        }

        return cleanUp;
     }, [dataUrl])

     return { data, fetchError, isLoading };
}

export default useAxiosFetchPost