import {JSX} from "react";
import {Link} from "react-router-dom";
import AnimatedMain from "../../components/AnimatedMain/AnimatedMain.tsx";

function HomePage(): JSX.Element {
    return (
        <AnimatedMain>
            <h1>Home Page</h1>
            <p>Welcome to the Home Page!</p>
            <Link to={'/user/info'} >TAK</Link>
        </AnimatedMain>
    );
}

export default HomePage;