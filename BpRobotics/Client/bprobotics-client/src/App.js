import './App.css';
import { Outlet } from 'react-router-dom';
import { Nav, Navbar, Container } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import useAuth from './hooks/useAuth';
import FlashMessages from './components/FlashMessages';

function App() {
  const { auth, logout } = useAuth();

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
                  {auth && (auth.role === "Admin" || auth.role === "Partner") && <LinkContainer to="/customers">
                    <Nav.Link>Customers</Nav.Link>
                  </LinkContainer>}
                  {auth && auth.role === "Customer" && <LinkContainer to="/profile">
                    <Nav.Link>Profile</Nav.Link>
                  </LinkContainer>}
                  {auth && (auth.role === "Admin" || auth.role === "Customer") && <LinkContainer to="/orders">
                    <Nav.Link>Orders</Nav.Link>
                  </LinkContainer>}
                  {auth && (auth.role === "Admin" || auth.role === "Customer") && <LinkContainer to="/devices">
                    <Nav.Link>Devices</Nav.Link>
                  </LinkContainer>}
                  {auth && auth.role === "Admin" && <LinkContainer to="/partners">
                    <Nav.Link>Partners</Nav.Link>
                  </LinkContainer>}
                  <LinkContainer to="/products">
                    <Nav.Link>Products</Nav.Link>
                  </LinkContainer>
                  {auth && auth.role === "Admin" && <LinkContainer to="/users">
                    <Nav.Link>Users</Nav.Link>
                  </LinkContainer>}
                  {!auth && <LinkContainer to="/login">
                    <Nav.Link>Login</Nav.Link>
                  </LinkContainer>}
                  {auth && <LinkContainer to="/">
                    <Nav.Link onClick={logout}>Logout</Nav.Link>
                  </LinkContainer>}
                </Nav>
              </Navbar.Collapse>
            </Container>
          </Navbar>
        </Container>
      </header>
      <Container>
        <FlashMessages />
        <Outlet />
      </Container>
    </div>
  );
}

export default App;