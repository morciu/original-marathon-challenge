import React, { useState, useContext } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "normalize.css";

import { UserContext } from "./hooks/UserContext";

import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Header from "./components/Layout/Header/Header";
import Users from "./components/Users/Users";
import Footer from "./components/Layout/Footer";
import Home from "./pages/Home/Home"
import RegisterRun from "./pages/RegisterRun/RegisterRun";
import CheckProgress from "./pages/CheckProgress/CheckProgress";
import PrivateMarathons from "./pages/PrivateMarathons/PrivateMarathons";
import User from "./pages/User/User";
import Marathon from "./pages/Marathon/Marathon";
import Invitations from "./pages/Invitations/Invitations";
import DashBoard from "./components/DashBoard/DashBoard";
import Activities from "./components/Activities/Activities";
import Medals from "./pages/Medals/Medals";
import GlobalRanking from "./components/GlobalRanking/GlobalRanking";

function App() {

  const user = useContext(UserContext);

  const [needsUpdate, setNeedsUpdate] = useState(false);

  return (
    <div className="container">
      <Header />
      <div className="main">
        <Routes>
            <Route path="/" element={<Home needsUpdate={needsUpdate} setNeedsUpdate={setNeedsUpdate} />}></Route>
            <Route path="/login" element={<Login />}></Route>
            <Route path="/register" element={<Register />}></Route>
            <Route path="/check-progress" element={<CheckProgress />}></Route>
            <Route path="/private-marathons" element={<PrivateMarathons />}></Route>
            <Route path="/user/:userId" element={<User />}></Route>
            <Route path="/marathon/:marathonId" element={<Marathon />}></Route>
            <Route path="/invitations" element={<Invitations />}></Route>
            <Route path="/:userId/activities" element={<Activities needsUpdate={needsUpdate} setNeedsUpdate={setNeedsUpdate} />}></Route>
            <Route path="/:userId/medals" element={<Medals />}></Route>
            <Route path="/global-ranking" element={<GlobalRanking />}></Route>
        </Routes>
      </div>
      <Footer needsUpdate={needsUpdate} setNeedsUpdate={setNeedsUpdate} />
    </div>
  );
}

export default App;
