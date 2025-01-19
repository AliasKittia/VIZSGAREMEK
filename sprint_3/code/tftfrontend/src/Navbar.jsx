import React from "react";
import { NavLink } from "react-router-dom";
import "./Navbar.css";

function Navbar() {
  return (
    <nav className="navbar">
      <a href="/" className="navbar-logo">
        TFT Útmutató
      </a>
      <ul className="navbar-links">
        <li>
          <NavLink to="/" activeClassName="active" exact>
            Főoldal
          </NavLink>
        </li>
        <li>
          <NavLink to="/characters" activeClassName="active">
            Karakterek
          </NavLink>
        </li>
        <li>
          <NavLink to="/items" activeClassName="active">
            Tárgyak
          </NavLink>
        </li>
      </ul>
    </nav>
  );
}

export default Navbar;
