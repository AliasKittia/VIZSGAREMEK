import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Navbar from "./Navbar/Navbar";
import Characters from "./Characters/Characters";
import Items from "./Items/Items";
import Class from "./Class/Class";
import Anomalies from "./Anomalies/Anomalies";
import Homepage from "./Homepage/Homepage";
import Augments from "./Augments/Augments";
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
