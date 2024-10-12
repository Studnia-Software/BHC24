import {JSX} from "react";
import styles from "./DisplayButton.module.css";

interface BlurButtonProps {
    onClick?: () => void;
    text: string;
    type?: "submit" | "button" | "reset";
    fill?: boolean;
}

function DisplayButton({onClick, text, type = "submit", fill}: BlurButtonProps): JSX.Element {
    return (
        <button type={type} className={`${styles.blurButton} ${fill ? styles.fill : ""}`} onClick={onClick}>{text}</button>
    );
}

export default DisplayButton;