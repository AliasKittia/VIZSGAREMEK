import React, { useEffect, useState } from "react";
import "./Characters.css";

const Characters = () => {
  const [characters, setCharacters] = useState([]); // Initialize state
  const [selectedCost, setSelectedCost] = useState("all"); // State for selected cost filter
  const [searchTerm, setSearchTerm] = useState(""); // State for search term

  useEffect(() => {
    // Fetch data from backend API
    fetch("http://localhost:5287/api/Character")
      .then((res) => res.json())
      .then((data) => setCharacters(data)) // Store data in state
      .catch((err) => console.error("Error fetching characters:", err));
  }, []); // Empty dependency array means this runs once on mount

  const imageExtension = ".png";
  const baseUrl = "http://images.tftproject.nhely.hu";

  const handleCostChange = (event) => {
    setSelectedCost(event.target.value);
  };

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredCharacters = characters.filter(char => {
    const matchesCost = selectedCost === "all" || char.cost === parseInt(selectedCost);
    const matchesSearch = char.characterName.toLowerCase().includes(searchTerm.toLowerCase());
    return matchesCost && matchesSearch;
  });

  return (
    <div className="page-container">
      <h1 className="title">Characters</h1>
      <div className="filter-container">
        <label htmlFor="cost-filter">Szűrés érték szerint: </label>
        <select id="cost-filter" value={selectedCost} onChange={handleCostChange}>
          <option value="all">All</option>
          <option value="1">1</option>
          <option value="2">2</option>
          <option value="3">3</option>
          <option value="4">4</option>
          <option value="5">5</option>
        </select>
        <label htmlFor="search-filter">Search: </label>
        <input
          type="text"
          id="search-filter"
          value={searchTerm}
          onChange={handleSearchChange}
          placeholder="Keresés név szerint..."
        />
      </div>
      <div className="card-container">
        {filteredCharacters.map((char) => (
          <div className="card" key={char.characterId}>
            <h2>{char.characterName}</h2>
            <img src={baseUrl + char.characterImageBlob + imageExtension} alt={char.characterName} />
            <p>Cost: {char.cost}</p>
            <p>Health: {char.health} / {char.health1} / {char.health2}</p>
            <p>Mana: {char.manaStart} / {char.manaMax}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Characters;
