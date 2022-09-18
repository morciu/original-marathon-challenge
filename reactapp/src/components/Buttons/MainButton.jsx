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
    };

    return(
        <>
            <button style={style} type="submit"  onClick={() => props.clickEvent}>Log In</button>
        </>
    );
};

export default Button;