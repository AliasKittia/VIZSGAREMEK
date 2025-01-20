import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./Navbar";
import Homepage from "./Homepage";
import Characters from "./Characters";
import Items from "./Items";
import Augments from "./Augments";
import Class from "./Class";
import Anomalies from "./Anomalies";
import "./App.css";

function App() {
  return (
    <Router>
      <div className="App">
        <Navbar />
        <Routes>
          <Route path="/" element={<Homepage />} />
          <Route path="/characters" element={<Characters />} />
          <Route path="/items" element={<Items />} />
          <Route path="/augments" element={<Augments />} />
          <Route path="/class" element={<Class />} />
          <Route path="/anomalies" element={<Anomalies />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
