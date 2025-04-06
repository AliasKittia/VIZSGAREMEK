import React from "react";
import { NavLink } from "react-router-dom";
import "./Navbar.css";

function Navbar() {
  return (
    <nav className="navbar">
      <div className="navbar-container">
        <NavLink to="/" className="navbar-logo">
          TFT Útmutató
        </NavLink>
        <ul className="navbar-links">
          <li><NavLink to="/" end>Főoldal</NavLink></li>
          <li><NavLink to="/characters">Karakterek</NavLink></li>
          <li><NavLink to="/items">Tárgyak</NavLink></li>
          <li><NavLink to="/classes">Osztályok</NavLink></li>
          <li><NavLink to="/anomalies">Anomáliák</NavLink></li>
          <li><NavLink to="/augments">Augmentek</NavLink></li>
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;
