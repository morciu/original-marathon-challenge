import React from "react";
import Login from "../Login/Login";
import Button from "../Buttons/MainButton";

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