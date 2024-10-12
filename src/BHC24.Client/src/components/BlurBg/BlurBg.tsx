import {JSX} from "react";
import styles from "./BlurBg.module.css";

function BlurBg(): JSX.Element {
    return (
        <div className={styles.blurBg}>
            <div className={styles.bgImage}></div>
        </div>
    );
}

export default BlurBg;