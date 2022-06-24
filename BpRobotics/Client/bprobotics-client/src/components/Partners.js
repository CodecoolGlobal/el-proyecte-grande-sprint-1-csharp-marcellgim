import { useState, useEffect } from "react";
import MaterialTable from 'material-table';
import '../App.css';
import axiosInstance from "../fetch/axiosInstance";
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";


function Partners() {

	const [partnerData, setPartnerData] = useState([]);

	const [postCompanyName, setPostCompanyName] = useState('');
	const [postPhoneNumber, setPostPhoneNumber] = useState('');

	const [editCompanyName, setEditCompanyName] = useState('');
	const [editPhoneNumber, setEditPhoneNumber] = useState('');

	const [idToDelete, setIdToDelete] = useState('');

	const [idToUpdate, setIdToUpdate] = useState('');

	const url = `${process.env.REACT_APP_HOST_URL}/partners`;

	const { data, fetchError, isLoading } = useAxiosFetchGet(url);

	//cosmetic
	const [isPendingDelete, setIsPendingDelete] = useState(false);
	const [isPendingAdd, setIsPendingAdd] = useState(false);
	const [isPendingUpdate, setIsPendingUpdate] = useState(false);
	const [selectedRow, setSelectedRow] = useState();

	//set data state
	useEffect(() => {
		setPartnerData(data);
	}, [data])


	const handleSubmit = async (e) => {
		//e.preventDefault();
		const newPartner = { "CompanyName" : postCompanyName, "PhoneNumber" : postPhoneNumber };
		setIsPendingAdd(true);
		try {
			const response = await axiosInstance.post(url, newPartner)
			//response should send back the created object
			const allPartners = [...partnerData, response.data]
			setPartnerData(allPartners);
			setPostCompanyName('');
			setPostPhoneNumber('');
		} catch (err) {
			console.log(`Error: ${err.message}`);
		}
		setIsPendingAdd(false);
	}


	const handleUpdate = async (e) => {
		//e.preventDefault();
		const updatedPartner = { "CompanyName" : editCompanyName, "PhoneNumber" : editPhoneNumber };
		setIsPendingUpdate(true);
		try {
			const response = await axiosInstance.put(`${url}/${idToUpdate}`, updatedPartner)
			setPartnerData(partnerData.map(partner => partner.id === idToUpdate ? { ...response.data } : partner));
			setEditCompanyName('');
			setEditPhoneNumber('');
			setIdToUpdate('');
		} catch (err) {
			console.log(`Error: ${err.message}`);
		}
		setIsPendingUpdate(false);
	}


	const handleDelete = async (e) => {
		//e.preventDefault();
		setIsPendingDelete(true);
		try {
			await axiosInstance.delete(`${url}/${idToDelete}`);
			const allPartners = partnerData.filter(partner => partner.id !== idToDelete);
			setPartnerData(allPartners);
			setIdToDelete('');
		} catch (err) {
			console.log(`Error: ${err.message}`);
		}
		setIsPendingDelete(true);
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
						value={postCompanyName}
						onChange={(e) => setPostCompanyName(e.target.value)}
					/>
					<label>Phone number:</label>
					<input 
						type="text" 
						required
						value={postPhoneNumber}
						onChange={(e) => setPostPhoneNumber(e.target.value)} />
					{ !isPendingAdd && <button>Add partner</button> }
					{ isPendingAdd && <button>Adding partner...</button> }
				</form>
			</div>
			<div className="create">
				<h2>Update Partner</h2>
				<form onSubmit={handleUpdate}>
					<label>Id:</label>
					<input 
						type="text" 
						required 
						value={idToUpdate}
						onChange={(e) => setIdToUpdate(e.target.value)}
					/>
					<label>Company name:</label>
					<input 
						type="text" 
						required 
						value={editCompanyName}
						onChange={(e) => setEditCompanyName(e.target.value)}
					/>
					<label>Phone number:</label>
					<input 
						type="text" 
						required
						value={editPhoneNumber}
						onChange={(e) => setEditPhoneNumber(e.target.value)} />
					{ !isPendingUpdate && <button>Update partner</button> }
					{ isPendingUpdate && <button>Updating partner...</button> }
				</form>
			</div>
			<div className="create">
				<h2>Delete Partner</h2>
				<form onSubmit={handleDelete}>
					<label>Id:</label>
					<input 
						type="text" 
						required 
						value={idToDelete}
						onChange={(e) => setIdToDelete(e.target.value)}
					/>
					{ !isPendingDelete && <button>Delete partner</button> }
					{ isPendingDelete && <button>Deleting partner...</button> }
				</form>
			</div>
			<div style={{ maxWidth: '100%' }}>
				{isLoading && <h1>LOADING</h1>}
				{fetchError && <p style={{color: "red"}}>{fetchError}</p>}
				{!isLoading && !fetchError && 
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
				editable={{

					onRowAdd:(newRow)=> new Promise((resolve, reject) => {
						
						setPostCompanyName(newRow.companyName);
						setPostPhoneNumber(newRow.phoneNumber);
						handleSubmit();
						resolve();
					}),

					onRowUpdate:(newRow, oldRow)=> new Promise((resolve, reject) => {

						setEditCompanyName(newRow.companyName);
						setEditPhoneNumber(newRow.phoneNumber);
						setIdToUpdate(oldRow.id);
						handleUpdate();
						resolve();
					}),

					onRowDelete:(selectedRow)=>new Promise((resolve, reject)=>{
					  setIdToDelete(selectedRow.id);
					  handleDelete();
					  resolve();
				  })
				}}
				
				columns={[
					{ title: 'Id', field: 'id' },
					{ title: 'Company name', field: 'companyName' },
					{ title: 'Mobile number', field: 'phoneNumber' },
				]}
				data={partnerData}
				title="Partners"
				/>
				}
			</div>
		</>
	);
}

export default Partners;