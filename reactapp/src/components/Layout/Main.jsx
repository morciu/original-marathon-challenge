import React from "react";
import Login from "../Login/Login";
import Register from "../Register/Register";

const Main = (props) => {

    if (props.page == "login"){
        return(
            <>
                <div className="main">
                    <Login currentPage={props.page} nextPage={props.nextPage} />
                </div>
            </>
        );
    }
    else if (props.page == "register"){
        return(
            <>
                <div className="main">
                    <Register currentPage={props.page} nextPage={props.nextPage} />
                </div>
            </>
        )
    }
    
};

export default Main;