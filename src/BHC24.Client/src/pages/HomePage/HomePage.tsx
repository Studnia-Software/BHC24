import {JSX} from "react";
import AnimatedMain from "../../components/AnimatedComps/AnimatedMain.tsx";
import TitleSection from "./TitleSection/TitleSection.tsx";
import AboutSection from "./AboutSection/AboutSection.tsx";
import {Link} from "react-router-dom";
import AnimatedMain from "../../components/AnimatedComps/AnimatedMain.tsx";

function HomePage(): JSX.Element {
  return (
    <AnimatedMain>
      <TitleSection/>
      <AboutSection/>
    </AnimatedMain>
  );
}

export default HomePage;