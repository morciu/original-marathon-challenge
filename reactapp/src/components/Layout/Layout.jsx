import React, { usestate } from "react";
import Header from "./Header";
import Main from "./Main";
import Footer from "./Footer";
import PhotoCredits from "../../media/PhotoCredits";

const Layout = () => {
    return(
        <>
            <div className="container">
                <Header />
                <Main />
                <Footer />
            </div>
            
        </>
    );
};

export default Layout;