import './App.css';
import { Link, Outlet } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>BP Robotics</h1>
        <nav>
          <Link to="/customers">Customers</Link> |{" "}
          <Link to="/orders">Orders</Link> |{" "}
          <Link to="/partners">Partners</Link> |{" "}
          <Link to="/products">Products</Link> |{" "}
          <Link to="/users">users</Link>
       </nav>
      </header>
      <Outlet />
    </div>
  );
}

export default App;