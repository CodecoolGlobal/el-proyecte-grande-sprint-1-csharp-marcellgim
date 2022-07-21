import './App.css';
import { Outlet } from 'react-router-dom';
import { Nav, Navbar, Container, Button } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import useAuth from './hooks/useAuth';

function App() {
  const { logout } = useAuth();
  return (
    <div className="App">
      <header className="App-header">
        <Container>
          <Navbar collapseOnSelect expand="lg" bg="light" variant="light">
            <Container>
              <LinkContainer to="/">
                <Navbar.Brand>BP Robotics</Navbar.Brand>
              </LinkContainer>
              <Navbar.Toggle aria-controls="responsive-navbar-nav" />
              <Navbar.Collapse id="responsive-navbar-nav">
                <Nav className="me-auto">
                  <LinkContainer to="/customers">
                    <Nav.Link>Customers</Nav.Link>
                  </LinkContainer>
                  <LinkContainer to="/orders">
                    <Nav.Link>Orders</Nav.Link>
                  </LinkContainer>
                  <LinkContainer to="/partners">
                    <Nav.Link>Partners</Nav.Link>
                  </LinkContainer>
                  <LinkContainer to="/products">
                    <Nav.Link>Products</Nav.Link>
                  </LinkContainer>
                  <LinkContainer to="/users">
                    <Nav.Link>Users</Nav.Link>
                  </LinkContainer>
                  <LinkContainer to="/login">
                    <Nav.Link>Login</Nav.Link>
                  </LinkContainer>
                  <LinkContainer to="/">
                    <Nav.Link onClick={logout}>Logout</Nav.Link>
                  </LinkContainer>
                </Nav>
              </Navbar.Collapse>
            </Container>
          </Navbar>
        </Container>
      </header>
      <Container>
        <Outlet />
      </Container>
    </div>
  );
}

export default App;