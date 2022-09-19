import React from "react";

const TextInput = (props) => {

    const mainStyle = {
        display: "grid",
        gridTemplateRows: "1fr 1fr",
        gap: "5px",
        color: "var(--light)",
        fontSize: "var(--form-size)",
    };

    const labelStyle = {
        display: "flex",
        justifyContent: "flext-start",
        alignItems: "center",
        paddingLeft: "4px"
    };

    return(
        <>
            <div className="input-form" style={mainStyle}>
                <label htmlFor="username-input" style={labelStyle}>{props.userNameLabel}</label>
                <input type={props.type} id="username-input" name="username-input" required></input>
            </div>
        </>
    );
};

export default TextInput;