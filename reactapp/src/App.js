import React, { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "normalize.css";
import Layout from "./components/Layout/Layout";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";

function App() {

  const [page, setPage] = useState("login");

  const changePage = (newPage) => setPage(newPage);

  return (
      <BrowserRouter>
        <Layout page={page} nextPage={changePage}>
          <Routes>
            <Route exact path="/login" element={<Login />} />
            <Route exact path="/register" element={<Register />} />
          </Routes>
        </Layout>
      </BrowserRouter>
  );
}

export default App;
