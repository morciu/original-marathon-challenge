import React, { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "normalize.css";
import Layout from "./components/Layout/Layout";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";

function App() {

  const currentUser = {
    userName: null,
    loggedIn: false
  }

  return (
      <BrowserRouter>
        <Layout user={currentUser}/>
      </BrowserRouter>
  );
}

export default App;
