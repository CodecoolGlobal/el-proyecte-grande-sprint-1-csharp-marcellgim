import { useState, useEffect } from "react";
import MaterialTable from 'material-table';
import '../App.css';




function Partners() {

    const [partnerData, setData] = useState([]);
    const [companyName, setCompanyName] = useState();
    const [phoneNumber, setPhoneNumber] = useState();
    //const [isPending, setIsPending] = useState(false);
    const [selectedRow, setSelectedRow] = useState();
    const [dummy, setDummy] = useState();
    const [dummy2, setDummy2] = useState();
    const [dummy3, setDummy3] = useState();
    const [dummy4, setDummy4] = useState();
    const [currentId, setCurrentId] = useState();

  //GET FETCH 
  useEffect(()=> {
    fetch(`${process.env.REACT_APP_HOST_URL}/partners`)
    .then(response => response.json())
    .then(data=>{
    console.log(data);
    setData(data);
    }).catch( err=> {
    console.log("Error Reading data " + err);
  })
  },[dummy])

  //POST FETCH 
  useEffect(()=> {
    console.log(companyName);
    console.log(phoneNumber);
    const newPartner = {companyName, phoneNumber};
    fetch(`${process.env.REACT_APP_HOST_URL}/partners`, {
      method: 'POST',
      headers: { "Content-type": "application/json" },
      body: JSON.stringify(newPartner)
    }).then(() => {
      console.log('New partner added');
      setDummy(dummy=>(dummy + "1"));
  })
  },[dummy2])

  //PUT FETCH 
  useEffect(()=> {
    console.log(companyName);
    console.log(phoneNumber);
    const newPartner = { companyName, phoneNumber};
    fetch(`${process.env.REACT_APP_HOST_URL}/partners/${currentId}`, {
      method: 'PUT',
      headers: { "Content-type": "application/json" },
      body: JSON.stringify(newPartner)
    }).then(() => {
      console.log(`Partner with Id: ${currentId} updated`);
      setDummy(dummy=>(dummy + "1"));
  })
  },[dummy4])

  //DELETE FETCH 
  useEffect(()=> {
    const newPartner = {companyName, phoneNumber};
    fetch(`${process.env.REACT_APP_HOST_URL}/partners/${currentId}`, {
      method: 'DELETE',
    }).then(() => {
      console.log(`Partner with Id: ${currentId} deleted`);
      setDummy(dummy=>(dummy + "1"));
  })
  },[dummy3])



  // const handleSubmit = (e) => {
  //   e.preventDefault();
  //   const newPartner = { companyName, phoneNumber };
    
  //   setIsPending(true);

  //   fetch(`${process.env.REACT_APP_URL}/partners`, {
  //     method: 'POST',
  //     headers: { "Content-type": "application/json" },
  //     body: JSON.stringify(newPartner)
  //   }).then(() => {
  //     console.log('New partner added');
  //     setIsPending(false);
  //     setDummy(dummy=>(dummy + "1"));
  //   })
  // }



  return (
      <>
      {/* <div className="create">
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
          
      </div> */}
      <div style={{ maxWidth: '100%' }}>
      <MaterialTable
        onRowClick={(evt, selectedRow) =>
          setSelectedRow(selectedRow.tableData.id)
        }
        options={{
          rowStyle: rowData => ({
            backgroundColor:
              selectedRow === rowData.tableData.id ? "#EEE" : "#FFF"
          }),
          tableLayout: "fixed",
          selection: true,
          filtering: true,
          sorting: true
        }}
        
        columns={[
          { title: 'Id', field: 'id' },
          { title: 'Company name', field: 'companyName' },
          { title: 'Mobile number', field: 'phoneNumber' },
        ]}
        editable={{
          onRowAdd:(newRow)=> new Promise((resolve, reject) => {
              
              setCompanyName(newRow.companyName);
              setPhoneNumber(`${newRow.phoneNumber}`);
              
              setTimeout(()=>{
              resolve()
              setDummy2(dummy=>(dummy + "1"));
            }
              , 1000)
          }),
          onRowUpdate:(newRow, oldRow)=> new Promise((resolve, reject) => {
              setCompanyName(newRow.companyName);
              setPhoneNumber(newRow.phoneNumber);
              setCurrentId(oldRow.id);
              setTimeout(()=>{
                resolve()
                setDummy4(dummy=>(dummy + "1"));
              }
                , 1000)
          }),
          onRowDelete:(selectedRow)=>new Promise((resolve, reject)=>{
            setCurrentId(selectedRow.id);
            setTimeout(()=>{
              resolve()
              setDummy3(dummy=>(dummy + "1"));
            }
              , 1000)
        })
        }}
        data={partnerData}
        title="Partners"
      />
    </div>
    </>
  );
}

export default Partners;