import React, { useEffect, useState } from "react";
import "./Anomalies.css";

const Anomalies = () => {
  const [anomalies, setAnomalies] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    fetch("http://localhost:5166/api/Anomalies")
      .then((res) => res.json())
      .then((data) => setAnomalies(data))
      .catch((err) => console.error("Error fetching anomalies:", err));
  }, []);

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredAnomalies = anomalies.filter((anomaly) =>
    anomaly.anomalyName.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="anomalies-page">
      <header className="anomalies-header">
        <h1 className="anomalies-title">Anomáliák</h1>
        <p className="anomalies-description">
          Böngéssz a játékban előforduló különleges anomáliák között! (Set 13)
        </p>
      </header>

      <div className="search-section">
        <label htmlFor="search-input" className="search-label">Keresés</label>
        <input
          type="text"
          id="search-input"
          className="search-box"
          placeholder="Keresés név szerint..."
          value={searchTerm}
          onChange={handleSearchChange}
        />
      </div>

      <main className="anomalies-container">
        {filteredAnomalies.map((anomaly, index) => (
          <div className="anomaly-card" key={index}>
            <h2 className="anomaly-name">{anomaly.anomalyName}</h2>
            <p className="anomaly-effect">{anomaly.anomalyEffect}</p>
          </div>
        ))}
      </main>
    </div>
  );
};

export default Anomalies;
