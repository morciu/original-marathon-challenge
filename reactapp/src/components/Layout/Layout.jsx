import React, { usestate } from "react";
import Header from "./Header";
import Main from "./Main";
import Footer from "./Footer";
import PhotoCredits from "../../media/PhotoCredits";
import { Route, Routes } from "react-router-dom";
import Users from "../Users/Users";

const Layout = (props) => {
    return(
        <div className="container">
            <Header />
                <Routes>
                    <Route path="/login" element={<Main nextPage={props.nextPage} page="login" />}></Route>
                    <Route path="/register" element={<Main nextPage={props.nextPage} page="register" />}></Route>
                    <Route path="/home" element={<Main nextPage={props.nextPage} page="home" />}></Route>
                    <Route path="/users" element={<Users />}></Route>
                </Routes>
            <Footer />
        </div>
    );
};

export default Layout;