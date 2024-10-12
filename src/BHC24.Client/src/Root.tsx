import {JSX} from "react";
import {Outlet} from "react-router-dom";

function Root(): JSX.Element {
    return <>
        <Outlet/>
    </>
}

export default Root