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
          <NavLink to="/" className={({ isActive }) => (isActive ? "active" : "")} end>
            Főoldal
          </NavLink>
        </li>
        <li>
          <NavLink to="/characters" className={({ isActive }) => (isActive ? "active" : "")}>
            Karakterek
          </NavLink>
        </li>
        <li>
          <NavLink to="/items" className={({ isActive }) => (isActive ? "active" : "")}>
            Tárgyak
          </NavLink>
        </li>
        <li>
          <NavLink to="/classes" className={({ isActive }) => (isActive ? "active" : "")}>
            Osztályok
          </NavLink>
        </li>
        <li>
          <NavLink to="/anomalies" className={({ isActive }) => (isActive ? "active" : "")}>
            Anomáliák
          </NavLink>
        </li>
        <li>
          <NavLink to="/augments" className={({ isActive }) => (isActive ? "active" : "")}>
            Augmentek
          </NavLink>
        </li>
      </ul>
    </nav>
  );
}

export default Navbar;