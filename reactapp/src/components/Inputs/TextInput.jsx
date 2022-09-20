import React from "react";
import styles from "./Inputs.module.css"

const TextInput = (props) => {

    return(
        <>
            <div className={styles.formContainer}>
                <label htmlFor={props.label} className={styles.label}>{props.label}</label>
                <input type={props.type} id={props.label} name={props.label} required></input>
            </div>
        </>
    );
};

export default TextInput;