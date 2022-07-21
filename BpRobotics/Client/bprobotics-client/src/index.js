import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Products from './components/Products';
import Partners from './components/Partners';
import Customers from './components/Customers';
import Users from './components/Users';
import UserDetails from './components/UserDetails';
import Orders from './components/Orders';
import ProductDetails from './components/ProductDetails';
import RequireAuth from "./components/RequireAuth";
import 'bootstrap/dist/css/bootstrap.min.css';
import AddPartner from './components/AddPartner';
import UpdatePartner from './components/UpdatePartner';
import Login from './components/Login';
import Devices from './components/Devices';
import CustomerDetails from './components/CustomerDetails';
import Profile from './components/Profile';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />}>
          <Route path="products" element={<Products />} />
          <Route path="products/:id" element={<ProductDetails />} />
          <Route path="partners" element={<Partners />} />
          <Route path="partners/add" element={<AddPartner />} />
          <Route path="partners/:id" element={<UpdatePartner />} />
          <Route path="customers"
            element={<RequireAuth allowedRoles={["Admin"]}><Customers /></RequireAuth>}
          />
          <Route path="customers/:id" element={<CustomerDetails />} />
          <Route path="profile"
            element={<RequireAuth allowedRoles={["Customer"]}><Profile /></RequireAuth>}
          />
          <Route path="orders"
            element={<RequireAuth allowedRoles={["Admin", "Customer"]}><Orders /></RequireAuth>}
          />
          <Route path="devices"
            element={<RequireAuth allowedRoles={["Admin", "Customer"]}><Devices /></RequireAuth>}
          />
          <Route path="users"
            element={<RequireAuth allowedRoles={["Admin"]}><Users /></RequireAuth>
            }
          />
          <Route path="users/:id" element={<RequireAuth allowedRoles={[]}><UserDetails /></RequireAuth>} />
          <Route path="login" element={<Login />} />
        </Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
