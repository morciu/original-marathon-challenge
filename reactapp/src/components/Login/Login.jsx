import React, { useState } from "react";
import PropTypes from "prop-types";

const Login = () => {
    return(
        <>
            <div class="login-form">
                <div class="input-form">
                    <label for="username-input">User Name</label>
                    <input type="text" id="username-input" name="username-input" required></input>
                </div>
                <div class="input-form">
                    <label for="password-inputt">Password</label>
                    <input type="password" id="password-input" name="password-input" required></input>
                </div>
                
                <button type="submit" class="btn">Log In</button>
            </div>
        </>
    )
};

export default Login;