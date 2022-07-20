import { useState, useEffect } from "react";
import '../App.css';
import axiosInstance from "../fetch/axiosInstance";
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import Table from 'react-bootstrap/Table';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash, faPlus, faEdit } from "@fortawesome/free-solid-svg-icons";
import Button from 'react-bootstrap/Button';
import LoadingSpin from "react-loading-spin";
import { useNavigate } from "react-router-dom";



function Partners() {

	let navigate = useNavigate();

	const [partnerData, setPartnerData] = useState([]);

	const url = `${process.env.REACT_APP_HOST_URL}/api/partners`;

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



	return (
		<>
			<div style={{ maxWidth: '100%' }}>
				{isLoading && <h1><LoadingSpin /></h1>}
				{fetchError && <p style={{ color: "red" }}>{fetchError}</p>}
				{!isLoading && !fetchError && partnerData &&
					<>
						<Table striped="columns">
							<thead>
								<tr>
									<th>
											<>
												<Button onClick={() => { navigate("/partners/add") }}>
													<FontAwesomeIcon icon={faPlus} />
												</Button>
											</>
									</th>
									<th>Company Name</th>
									<th>Phone Number</th>
								</tr>
							</thead>
							<tbody>
								{partnerData.map((partner) =>
									<tr key={partner.id}>
										<td>#</td>
										<td>{partner.companyName}</td>
										<td>{partner.phoneNumber}</td>

										<td>
											{!isPendingDelete ?
												<>
													<Button onClick={() => { navigate(`/partners/${partner.id}`) }}>
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
												/></>}
										</td>
									</tr>
								)}
							</tbody>
						</Table>
					</>
				}
			</div>
		</>
	);
}

export default Partners;
