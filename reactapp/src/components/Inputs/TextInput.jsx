import React from "react";

const TextInput = (props) => {

    return(
        <>
            <div className="input-form">
                <label htmlFor="username-input">{props.userNameLabel}</label>
                <input type="text" id="username-input" name="username-input" required></input>
            </div>
        </>
    );
};

export default TextInput;