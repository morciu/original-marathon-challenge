import React, { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "normalize.css";
import Layout from "./components/Layout/Layout";

function App() {

  const [page, setPage] = useState("login");

  const changePage = (newPage) => setPage(newPage);

  return (
      <Layout page={page} nextPage={changePage} />
  );
}

export default App;
