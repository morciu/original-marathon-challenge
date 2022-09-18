import React from "react";

const PasswordInput = (props) => {
    return(
        <>
            <div className="input-form">
                <label htmlFor="password-inputt">{props.passwordLabel}</label>
                <input type="password" id="password-input" name="password-input" required></input>
            </div>
        </>
    );
};

export default PasswordInput;