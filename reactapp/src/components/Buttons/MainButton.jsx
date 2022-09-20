import React from "react";

const Button = (props) => {
    const style = {
        backgroundColor: "var(--green)",
        border: "none",
        padding: "10px 40px",
        borderRadius: "8px",
        color: "var(--light)",
        fontSize: "var(--form-size)",
        textAlign: "center",
        maxHeight: "44px",
        lineHeight: "1em"
    };

    return(
        <>
            <button style={style} type={props.type}  onClick={() => props.nextPage(props.page)}>{props.text}</button>
        </>
    );
};

export default Button;