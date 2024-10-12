import {JSX} from "react";
import AnimatedOutlet from "./components/AnimatedOutlet/AnimatedOutlet.tsx";
import NavBar from "./components/NavBar/NavBar.tsx";

function Root(): JSX.Element {
    return <>
        <NavBar/>
        <AnimatedOutlet/>
    </>
}

export default Root