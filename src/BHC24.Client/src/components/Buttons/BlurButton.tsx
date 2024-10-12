import {JSX} from "react";
import styles from "./BlurButton.module.css";

interface BlurButtonProps {
    onClick: () => void;
    text: string;
}

function BlurButton({onClick, text}: BlurButtonProps): JSX.Element {
    return (
        <button className={styles.blurButton} onClick={onClick}>{text}</button>
    );
}

export default BlurButton;