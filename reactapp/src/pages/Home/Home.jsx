import Login from "../Login/Login";
import React from "react";
import { Navigate } from "react-router-dom";
import Users from "../../components/Users/Users";

const Home = () => {
    const isAuthenticated = !!localStorage.getItem("auth-token");
    console.log(localStorage);

    if (isAuthenticated){
        
        return(
            <>
                <Users />
            </>
        );
    } else {
        return( <> <Login /> </>)
    }
}

export default Home;