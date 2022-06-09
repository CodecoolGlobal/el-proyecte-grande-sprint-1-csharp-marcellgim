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
import Orders from './components/Orders';
import ProductDetails from './components/ProductDetails';
import 'bootstrap/dist/css/bootstrap.min.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />}>
          <Route path="products" element={<Products />} />
          <Route path="products/:id" element={<ProductDetails />} />
          <Route path="partners" element={<Partners />} />
          <Route path="customers" element={<Customers />} />
          <Route path="orders" element={<Orders />} />
          <Route path="users" element={<Users />} />
        </Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);

window.addEventListener("load", () => {
  const navbar = document.querySelector("#navbar");
  setWidth();

});

function setWidth() {
  const content = document.querySelector("#content");
  const navbar = document.querySelector("#navbar");

  content.style.width = navbar.offsetWidth + 'px';
}

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
