import React from "react";
import { createContext, useState } from "react";
import axios from "axios";

// Initiate Context
export const UserContext = createContext({
    id: null,
    userName: '',
    token: '',
    auth: false,
  });

// Set up context provider
export const UserProvider = ({ children }) => {
const [user, setUser] = useState({
    id: localStorage.id,
    userName: localStorage.userName,
    token: localStorage.token,
    auth: localStorage.auth,
});

// Login function
const login = async (requestConfig) => {
    try {
        const response = await axios({
            method: requestConfig.method,
            url: requestConfig.url,
            data: requestConfig.payload,
            headers: { "Content-Type": "application/json" }
        }
        );
        // Store response in local storage
        localStorage.setItem("id", response.data.id )
        localStorage.setItem("userName", response.data.userName )
        localStorage.setItem("token", response.data.token )
        localStorage.setItem("auth", true)

        setUser((user) => ({
            id: response.data.id,
            userName: response.data.userName,
            token: response.data.token,
            auth: true,
            }));
    } catch(error) {
        console.log(error)
        localStorage.clear();
    }
};

// Logout function
const logout = () => {
    setUser((user) => ({
    userName: '',
    token: '',
    auth: false,
    }));
};

return(
    <UserContext.Provider value={{ user, login, logout }}>
    {children}
    </UserContext.Provider>
);
};