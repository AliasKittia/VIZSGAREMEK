import React, { useEffect, useState } from "react";
import "./Augments.css";

const Augments = () => {
  const [augments, setAugments] = useState([]); // Initialize state

  useEffect(() => {
    // Fetch data from backend API
    fetch("http://localhost:5287/api/Augments")
      .then((res) => res.json())
      .then((data) => setAugments(data)) // Store data in state
      .catch((err) => console.error("Error fetching augments:", err));
  }, []); // Empty dependency array means this runs once on mount

  return (
    <div className="page-container">
      <h1 className="title">Augments</h1>
      <p className="augments-description">
        Az alábbiakban találhatóak a játékban előforduló augmentek, amelyek különleges hatásokkal bírnak.
      </p>
      <div className="card-container">
        {augments.map((augment) => (
          <div className="card" key={augment.augmentId}>
            <h2>{augment.augmentName}</h2>
            <p>{augment.augmentRarity}</p>
            <p>{augment.augmentEffect}</p>

          </div>
        ))}
      </div>
    </div>
  );
};

export default Augments;