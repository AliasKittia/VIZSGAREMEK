import React, { useEffect, useState } from "react";
import "./Anomalies.css";

const Anomalies = () => {
  const [anomalies, setAnomalies] = useState([]); // Initialize state
  const [searchTerm, setSearchTerm] = useState(""); // Initialize search term state

  useEffect(() => {
    // Fetch data from backend API
    fetch("http://localhost:5166/api/Anomalies")
      .then((res) => res.json())
      .then((data) => setAnomalies(data)) // Store data in state
      .catch((err) => console.error("Error fetching anomalies:", err));
  }, []); // Empty dependency array means this runs once on mount

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredAnomalies = anomalies.filter((anomaly) =>
    anomaly.anomalyName.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="page-container">
      <h1 className="title">Anomalies</h1>
      <div className="homepage-section">
        <p>
          A játékban megtalálható anomáliák.
        </p>
      </div>

      <div className="search-container">
        <label htmlFor="search-filter">Keresés: </label>
        <input
          type="text"
          id="search-filter"
          value={searchTerm}
          onChange={handleSearchChange}
          placeholder="Keresés név szerint..."
          className="search-input"
        />
      </div>

      <div className="card-container">
        {filteredAnomalies.map((anomaly, index) => (
          <div className="card" key={index}>
            <h2>{anomaly.anomalyName}</h2>
            <p>{anomaly.anomalyEffect}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Anomalies;