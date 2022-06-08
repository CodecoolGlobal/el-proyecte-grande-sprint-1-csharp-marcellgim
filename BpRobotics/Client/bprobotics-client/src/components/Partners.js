import { useState, useEffect } from "react";

function getPartners() {

}



function Partners() {
    const [partnerData, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);


    useEffect(() => {
        fetch(`${process.env.REACT_APP_URL}partners`, {
            mode: 'cors',
            headers: {
              'Access-Control-Allow-Origin':'*'
            }
          })
          .then((response) => {
            if (!response.ok) {
              throw new Error(
                `This is an HTTP error: The status is ${response.status}`
              );
            }
            return response.json();
          })
          .then((actualData) => console.log(actualData))
          .catch((err) => {
            console.log(err.message);
          });
      }, []);

    return ( <div>asd{process.env.REACT_APP_URL}</div> );
}

export default Partners;