import {JSX} from "react";
import styles from "./TitleSection.module.css";
import BlurBg from "../../../components/BlurBg/BlurBg.tsx";
import DisplayButton from "../../../components/Buttons/DisplayButton.tsx";
import {useNavigate} from "react-router-dom";
import logo from '/public/logo.png';

function TitleSection(): JSX.Element {
  const navigate = useNavigate()

  return (
    <section className={styles.titleSection}>
      <img src={logo} alt="logo"/>
      <div className={styles.textCon}>
        <BlurBg/>
        <h1><span className={"text"}>Twoje projekty</span><br/>Twoja kariera</h1>
        <h4>Zadbajmy wspólnie o Twoje doświadczenie.</h4>
      </div>
      <DisplayButton onClick={() => navigate("/auth/register")} text={"Dołącz do nas"}/>
    </section>
  );
}

export default TitleSection;