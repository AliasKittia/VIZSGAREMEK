import React, { useEffect, useState } from "react";
import "./Augments.css";

const Augments = () => {
  const [augments, setAugments] = useState([]); // Initialize state
  const [searchTerm, setSearchTerm] = useState(""); // Initialize search term state
  const [rarityFilter, setRarityFilter] = useState(""); // Initialize rarity filter state

  useEffect(() => {
    // Fetch data from backend API
    fetch("http://localhost:5287/api/Augments")
      .then((res) => res.json())
      .then((data) => setAugments(data)) // Store data in state
      .catch((err) => console.error("Error fetching augments:", err));
  }, []); // Empty dependency array means this runs once on mount

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleRarityChange = (event) => {
    setRarityFilter(event.target.value);
  };

  const filteredaugments = augments.filter((augment) => {
    return (
      augment.augmentName.toLowerCase().includes(searchTerm.toLowerCase()) &&
      (rarityFilter === "" || augment.augmentRarity === rarityFilter)
    );
  });

  return (
    <div className="page-container">
      <h1 className="title">Augments</h1>
      <div className="homepage-section">
        <p>
          A játékban megtalálható erősítések.
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

      <div className="filter-container">
        <label htmlFor="rarity-filter">Ritkaság: </label>
        <select
          id="rarity-filter"
          value={rarityFilter}
          onChange={handleRarityChange}
          className="filter-select"
        >
          <option value="">Összes</option>
          <option value="Arany">Arany</option>
          <option value="Prizmatikus">Prizmatikus</option>
          <option value="Ezüst">Ezüst</option>
        </select>
      </div>

      <div className="card-container">
        {filteredaugments.map((augment) => (
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