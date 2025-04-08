import React, { useEffect, useState } from "react";
import "./Augments.css";

const Augments = () => {
  const [augments, setAugments] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [rarityFilter, setRarityFilter] = useState("");

  useEffect(() => {
    fetch("http://localhost:5166/api/Augment")
      .then((res) => res.json())
      .then((data) => {
        const sortedData = data.sort((a, b) =>
          a.augmentName.localeCompare(b.augmentName)
        );
        setAugments(sortedData);
      })
      .catch((err) => console.error("Error fetching augments:", err));
  }, []);

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

  const getRarityClass = (rarity) => {
    switch (rarity) {
      case "Arany":
        return "rarity-gold";
      case "Ezüst":
        return "rarity-silver";
      case "Prizmatikus":
        return "rarity-prismatic";
      default:
        return "";
    }
  };

  return (
    <div className="page-container">
      <div className="content-wrapper">
        <h1 className="title">Erősítések</h1>
        <p className="minititle">A 13. Set-ben megtalálható erősítések listája</p>

        <div className="controls">
          <div className="augment-search-container">
            <label htmlFor="augment-search">Keresés:</label>
            <input
              type="text"
              id="augment-search"
              value={searchTerm}
              onChange={handleSearchChange}
              placeholder="Keresés név szerint..."
              className="augment-search-input"
            />
          </div>

          <div className="augment-filter-container">
            <label htmlFor="augment-filter">Ritkaság:</label>
            <select
              id="augment-filter"
              value={rarityFilter}
              onChange={handleRarityChange}
              className="augment-filter-select"
            >
              <option value="">Összes</option>
              <option value="Arany">Arany</option>
              <option value="Ezüst">Ezüst</option>
              <option value="Prizmatikus">Prizmatikus</option>
            </select>
          </div>
        </div>

        <div className="card-container">
          {filteredaugments.map((augment) => (
            <div
              className={`card ${getRarityClass(augment.augmentRarity)}`}
              key={augment.augmentId}
            >
              <h2>{augment.augmentName}</h2>
              <p
                className={`rarity-label ${getRarityClass(
                  augment.augmentRarity
                )}`}
              >
                {augment.augmentRarity}
              </p>
              <p>{augment.augmentEffect}</p>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Augments;
