import {JSX} from "react";
import styles from "./NavBar.module.css";
import {Link} from "react-router-dom";

function NavBar(): JSX.Element {
    return (
        <nav className={styles.navBar}>
            <h2>Logo</h2>
            <ul>
                <li><Link to={'/'}><h5>Start</h5></Link></li>
                <li><Link to={'#'}><h5>Menu 2</h5></Link></li>
                <li><Link to={'#'}><h5>Menu 3</h5></Link></li>
                <li><Link to={'#'}><h5>Menu 4</h5></Link></li>
            </ul>
        </nav>
    );
}

export default NavBar;