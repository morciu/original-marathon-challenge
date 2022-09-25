import React, { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "normalize.css";
import Layout from "./components/Layout/Layout";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Header from "./components/Layout/Header";
import Main from "./components/Layout/Main";
import Users from "./components/Users/Users";
import Footer from "./components/Layout/Footer";
import Home from "./pages/Home/Home"

function App() {

  

  return (
    <div className="container">
      <Header />
      <div className="main">
        <Routes>
            <Route path="/login" element={<Login />}></Route>
            <Route path="/register" element={<Register />}></Route>
            <Route path="/" element={<Home />}></Route>
        </Routes>
      </div>
      <Footer />
    </div>
  );
}

export default App;
