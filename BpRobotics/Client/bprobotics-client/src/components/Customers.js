import { Link } from 'react-router-dom';
import { Table, Alert, Card } from 'react-bootstrap';
import LoadingSpin from 'react-loading-spin';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";
import useAuth from '../hooks/useAuth';
import Button from 'react-bootstrap/Button';
import { useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/free-solid-svg-icons";


const CUSTOMERS_URL = "/api/customers";

function Customers() {
  const { auth } = useAuth();
  const { data: customers, isLoading, fetchError } = useAxiosFetchGet(CUSTOMERS_URL);
  const render = (input) => input; // Default render
  const columns = [
    { title: 'Company Name', field: 'companyName', render },
    { title: 'VAT number', field: 'vatNumber', render }
  ];
  let navigate = useNavigate();

  return (
    <Card body>
    <Table striped="columns">
      <thead>
        <tr>
          <th>
            {auth?.role === "Admin" && <>
              <Button onClick={() => { navigate("/customers/add") }}>
                <FontAwesomeIcon icon={faPlus} />
              </Button>
            </>}
          </th>
          {columns.map((column, index) => <th key={index}>{column.title}</th>)}
        </tr>
      </thead>
      <tbody>
        {isLoading && <tr><td><LoadingSpin /></td></tr>}
        {fetchError && <tr><td><Alert variant='danger'>{fetchError}</Alert></td></tr>}
        {customers.map(customer => (
          <tr key={customer.id}>
            <td>#</td>
            <td><Link to={customer.id.toString()} state={customer}>{customer.companyName}</Link></td>
            <td>{customer.vatNumber}</td>
          </tr>
        ))}
      </tbody>
    </Table>
    </Card>
  );
}

export default Customers;
