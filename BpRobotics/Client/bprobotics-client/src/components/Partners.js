import { useState, useEffect } from "react";
import MaterialTable from 'material-table';



function Partners() {
    const [partnerData, setData] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
          const response = await fetch(`${process.env.REACT_APP_URL}partners`);
          const newData = await response.json();
          setData(newData);
        };
    
        fetchData();
      }, []);



    return ( 
        <div style={{ maxWidth: '100%' }}>
        <MaterialTable
          columns={[
            { title: 'Company name', field: 'CompanyName' },
            { title: 'Mobile number', field: 'PhoneNumber' },
          ]}
          data={partnerData}
          title="Partners"
        />
      </div>
    );
}

export default Partners;