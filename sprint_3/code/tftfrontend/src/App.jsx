import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Navbar from "./Navbar";
import Characters from "./Characters";
import Items from "./Items";
import Class from "./Class";
import Anomalies from "./Anomalies";
import Homepage from "./Homepage";
import Augments from "./Augments";
import "./App.css";

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Homepage />} />
        <Route path="/characters" element={<Characters />} />
        <Route path="/items" element={<Items />} />
        <Route path="/classes" element={<Class />} />
        <Route path="/anomalies" element={<Anomalies />} />
        <Route path="/augments" element={<Augments />} />
      </Routes>
    </Router>
  );
}

export default App;
