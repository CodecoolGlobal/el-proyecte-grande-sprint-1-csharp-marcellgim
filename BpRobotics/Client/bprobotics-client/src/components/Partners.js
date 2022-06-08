import { useState, useEffect } from "react";
import MaterialTable from 'material-table';
import '../App.css';



function Partners() {

    const [partnerData, setData] = useState([]);
    const [companyName, setCompanyName] = useState('hello');
    const [phoneNumber, setPhoneNumber] = useState('+36');
    const [isPending, setIsPending] = useState(false);

  useEffect(()=> {
    fetch(`${process.env.REACT_APP_URL}/partners`)
    .then(response => response.json())
    .then(data=>{
    console.log(data);
    setData(data);
    }).catch( err=> {
    console.log("Error Reading data " + err);
  })
  },[])

  const handleSubmit = (e) => {
    e.preventDefault();
    const newPartner = { companyName, phoneNumber };
    
    setIsPending(true);

    fetch(`${process.env.REACT_APP_URL}/partners`, {
      method: 'POST',
      headers: { "Content-type": "application/json" },
      body: JSON.stringify(newPartner)
    }).then(() => {
      console.log('New partner added');
      setIsPending(false);
    })
  }

  return (
      <>
      <div className="create">
          <h2>Add new Partner</h2>
          <form onSubmit={handleSubmit}>
              <label>Company name:</label>
              <input 
                type="text" 
                required 
                value={companyName}
                onChange={(e) => setCompanyName(e.target.value)}
              />
              <label>Phone number:</label>
              <input 
                type="text" 
                required
                value={phoneNumber}
                onChange={(e) => setPhoneNumber(e.target.value)} />
              { !isPending && <button>Add partner</button> }
              { isPending && <button>Adding partner...</button> }
          </form>
          
      </div>
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
    </>
  );
}

export default Partners;