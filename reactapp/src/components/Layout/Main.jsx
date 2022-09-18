import React from "react";
import Login from "../Login/Login";

const Main = () => {
    return(
        <>
            <div className="main">
                <Login userNameLabel="User Name" passwordLabel="Password" />
            </div>
        </>
    );
};

export default Main;