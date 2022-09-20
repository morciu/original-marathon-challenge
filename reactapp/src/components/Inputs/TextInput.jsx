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
            <div className="form" style={mainStyle}>
                <label htmlFor={props.label} style={labelStyle}>{props.label}</label>
                <input type={props.type} id={props.label} name={props.label} required></input>
            </div>
        </>
    );
};

export default TextInput;