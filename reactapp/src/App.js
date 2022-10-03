import React, { useState, useContext } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "normalize.css";

import { UserContext } from "./hooks/UserContext";

import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Header from "./components/Layout/Header";
import Users from "./components/Users/Users";
import Footer from "./components/Layout/Footer";
import Home from "./pages/Home/Home"
import RegisterRun from "./pages/RegisterRun/RegisterRun";
import CheckProgress from "./pages/CheckProgress/CheckProgress";
import PrivateMarathons from "./pages/PrivateMarathons/PrivateMarathons";
import User from "./pages/User/User";
import Marathon from "./pages/Marathon/Marathon";
import Invitations from "./pages/Invitations/Invitations";

function App() {

  const user = useContext(UserContext);

  return (
    <div className="container">
      <Header />
      <div className="main">
        <Routes>
            <Route path="/" element={<Home />}></Route>
            <Route path="/login" element={<Login />}></Route>
            <Route path="/register" element={<Register />}></Route>
            <Route path="/users" element={<Users />}></Route>
            <Route path="/register-run" element={<RegisterRun />}></Route>
            <Route path="/check-progress" element={<CheckProgress />}></Route>
            <Route path="/private-marathons" element={<PrivateMarathons />}></Route>
            <Route path="/user/:userId" element={<User />}></Route>
            <Route path="/marathon/:marathonId" element={<Marathon />}></Route>
            <Route path="/invitations" element={<Invitations />}></Route>
        </Routes>
      </div>
      <Footer />
    </div>
  );
}

export default App;
