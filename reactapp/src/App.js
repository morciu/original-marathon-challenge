import React, { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "normalize.css";
import Layout from "./components/Layout/Layout";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";

function App() {

  return (
      <BrowserRouter>
        <Layout />
      </BrowserRouter>
  );
}

export default App;
