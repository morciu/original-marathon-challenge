import React from "react";
import Login from "../Login/Login";
import Register from "../Register/Register";

const Main = (props) => {

    if (props.page == "login"){
        return(
            <>
                <div className="main">
                    <Login  />
                </div>
            </>
        );
    }
    else if (props.page == "register"){
        return(
            <>
                <div className="main">
                    <Register />
                </div>
            </>
        )
    }
    
};

export default Main;