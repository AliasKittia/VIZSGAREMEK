import React, { useEffect, useState } from "react";
import "./Anomalies.css";

const Anomalies = () => {
  const [anomalies, setAnomalies] = useState([]); // Initialize state

  useEffect(() => {
    // Fetch data from backend API
    fetch("http://localhost:5287/api/Anomalies")
      .then((res) => res.json())
      .then((data) => setAnomalies(data)) // Store data in state
      .catch((err) => console.error("Error fetching anomalies:", err));
  }, []); // Empty dependency array means this runs once on mount

  return (
    <div className="page-container">
      <h1 className="title">Anomalies</h1>
      <p className="anomalies-description">
        Az alábbiakban találhatóak a játékban előforduló anomáliák, amelyek különleges hatásokkal bírnak.
      </p>
      <div className="card-container">
        {anomalies.map((anomaly) => (
          <div className="card" key={anomaly.id}>
            <h2>{anomaly.name}</h2>
            <p>{anomaly.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Anomalies;