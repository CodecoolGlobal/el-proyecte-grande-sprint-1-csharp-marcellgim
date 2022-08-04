import { useState, useEffect } from "react";
import '../App.css';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash, faPlus, faEdit } from "@fortawesome/free-solid-svg-icons";
import { Button, Table, Card } from 'react-bootstrap';
import LoadingSpin from "react-loading-spin";
import { useNavigate } from "react-router-dom";
import useAxios from "../hooks/useAxios";
import useAuth from '../hooks/useAuth';


function Partners() {
	const { auth } = useAuth();
	const axiosInstance = useAxios();
	let navigate = useNavigate();

	const [partnerData, setPartnerData] = useState([]);

	const url = "/api/partners";

	const { data, fetchError, isLoading } = useAxiosFetchGet(url);

	//cosmetic
	const [isPendingDelete, setIsPendingDelete] = useState(false);

	//set data state
	useEffect(() => {
		setPartnerData(data);
	}, [data])


	const handleDelete = async (id) => {
		setIsPendingDelete(true);
		try {
			await axiosInstance.delete(`${url}/${id}`);
			const allPartners = partnerData.filter(partner => partner.id !== id);
			setPartnerData(allPartners);
		} catch (err) {
			console.log(`Error: ${err.message}`);
		}
		setTimeout(() => { setIsPendingDelete(false) }, 1500);
	}

	const goToUpdate = (id, partner) => {
		navigate(`/partners/${id}`, {state: partner})
	}



	return (
		<Card body>
			<div style={{ maxWidth: '100%' }}>
				{isLoading && <h1><LoadingSpin /></h1>}
				{fetchError && <p style={{ color: "red" }}>{fetchError}</p>}
				{!isLoading && !fetchError && partnerData &&
					<>
						<Table striped="columns">
							<thead>
								<tr>
									<th>
											{ auth?.role === "Admin" && <>
												<Button onClick={() => { navigate("/partners/add") }}>
													<FontAwesomeIcon icon={faPlus} />
												</Button>
											</>}
									</th>
									<th>Company Name</th>
									<th>Phone Number</th>
									<th>Connected User</th>
								</tr>
							</thead>
							<tbody>
								{partnerData.map((partner) =>
									<tr key={partner.id}>
										<td>#</td>
										<td>{partner.companyName}</td>
										<td>{partner.phoneNumber}</td>
										<td>{partner.connectedUser}</td>


										<td>
											{ auth?.role === "Admin" &&
												(!isPendingDelete ?
												<>
													<Button onClick={() => { goToUpdate(partner.id, partner) }}>
														<FontAwesomeIcon icon={faEdit} />
													</Button>
													<Button onClick={() => { handleDelete(partner.id) }}>
														<FontAwesomeIcon icon={faTrash} />
													</Button>
												</>
												:
												<><LoadingSpin
													width="6px"
													primaryColor="yellow"
													size="30px"
												/></>)}
										</td>
									</tr>
								)}
							</tbody>
						</Table>
					</>
				}
			</div>
		</Card>
	);
}

export default Partners;
