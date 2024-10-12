import {JSX, useEffect, useState} from "react";
import styles from "./NavBar.module.css";
import {NavLink} from "react-router-dom";

function NavBar(): JSX.Element {
  const [onTop, setOnTop] = useState<boolean>(true);

  useEffect(() => {
    const handleScroll = () => {
      if (window.scrollY > 100) {
        setOnTop(false);
      } else {
        setOnTop(true);
      }
    };

    window.addEventListener('scroll', handleScroll);
    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  return (
    <nav className={`${styles.navBar} ${onTop ? styles.onTop : ""}`}>
      <h2>Logo</h2>
      <ul>
        <li><NavLink to={'/'}><h3>Start</h3></NavLink></li>
        <li><NavLink to={'/projects'}><h3>Odkrywaj</h3></NavLink></li>
        <li><NavLink to={'/auth'}><h3>Zaloguj</h3></NavLink></li>
      </ul>
    </nav>
  );
}

export default NavBar;