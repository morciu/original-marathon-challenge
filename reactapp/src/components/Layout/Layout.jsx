import React, { usestate } from "react";
import Header from "./Header";
import Main from "./Main";
import Footer from "./Footer";
import PhotoCredits from "../../media/PhotoCredits";

const Layout = (props) => {
    return(
        <>
            <div className="container">
                <Header />
                    <Main nextPage={props.nextPage} page={props.page} />
                <Footer />
            </div>
            
        </>
    );
};

export default Layout;