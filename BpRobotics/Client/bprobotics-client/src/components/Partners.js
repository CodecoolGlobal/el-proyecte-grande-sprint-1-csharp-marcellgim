import { useState, useEffect } from "react";
import MaterialTable from 'material-table';



function Partners() {

    const [partnerData, setData] = useState([]);


  useEffect(()=> {
    fetch(`${process.env.REACT_APP_URL}partners`)
    .then(response => response.json())
    .then(data=>{
    console.log(data);
    setData(data);
    }).catch( err=> {
    console.log("Error Reading data " + err);
  })
  },[])


  return (
      <div style={{ maxWidth: '100%' }}>
      <MaterialTable
        columns={[
          { title: 'Company name', field: 'companyName' },
          { title: 'Mobile number', field: 'phoneNumber' },
        ]}
        data={partnerData}
        title="Partners"
      />
    </div>
  );
}

export default Partners;