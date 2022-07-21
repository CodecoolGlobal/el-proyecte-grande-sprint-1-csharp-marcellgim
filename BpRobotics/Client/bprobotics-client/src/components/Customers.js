import { Link } from 'react-router-dom';
import { Table, Alert } from 'react-bootstrap';
import LoadingSpin from 'react-loading-spin';
import useAxiosFetchGet from "../hooks/useAxiosFetchGet";

const CUSTOMERS_URL = "/api/customers";

function Customers() {
  const { data: customers, isLoading, fetchError } = useAxiosFetchGet(CUSTOMERS_URL);
  const render = (input) => input; // Default render
  const columns = [
    { title: 'Company Name', field: 'companyName', render },
    { title: 'VAT number', field: 'vatNumber', render }
  ];

  return (
    <Table striped="columns">
      <thead>
        <tr>
          {columns.map((column, index) => <th key={index}>{column.title}</th>)}
        </tr>
      </thead>
      <tbody>
        {isLoading && <tr><td><LoadingSpin /></td></tr>}
        {fetchError && <tr><td><Alert variant='danger'>{fetchError}</Alert></td></tr>}
        {customers.map(customer => (
          <tr key={customer.id}>
            <td><Link to={customer.id.toString()} state={customer}>{customer.companyName}</Link></td>
            <td>{customer.vatNumber}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
}

export default Customers;
