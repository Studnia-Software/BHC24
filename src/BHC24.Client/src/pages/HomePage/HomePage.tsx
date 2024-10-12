import {JSX} from "react";
import {Link} from "react-router-dom";
import AnimatedMain from "../../components/AnimatedComps/AnimatedMain.tsx";

function HomePage(): JSX.Element {
  return (
    <AnimatedMain>
      <h1>Home Page</h1>
      <p>Welcome to the Home Page!</p>
      <Link to={'/user/aaa/info'}>TAK</Link>
    </AnimatedMain>
  );
}

export default HomePage;