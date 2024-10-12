import {JSX} from "react";
import styles from "./AboutSection.module.css";

function AboutSection(): JSX.Element {
  return (
    <section className={styles.aboutSection}>
      <h2>O nas</h2>
      <div className={styles.aboutCon}>
        <img src="" alt=""/>
      </div>
    </section>
  );
}

export default AboutSection;
