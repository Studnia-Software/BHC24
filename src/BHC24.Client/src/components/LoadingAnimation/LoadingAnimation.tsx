import {JSX} from "react";
import styles from "./LoadingAnimation.module.css";
import AnimatedDiv from "../AnimatedComps/AnimatedDiv.tsx";

function LoadingAnimation(): JSX.Element {
  return (
    <AnimatedDiv className={styles.loadingAnimation}>
      <span className={styles.loadingAnimationDot}></span>
      <span className={styles.loadingAnimationDot}></span>
      <span className={styles.loadingAnimationDot}></span>
    </AnimatedDiv>
  );
}

export default LoadingAnimation;