import React, { useEffect, useState } from "react";
import "./Characters.css";

const Characters = () => {
  const [characters, setCharacters] = useState([]);
  const [selectedCost, setSelectedCost] = useState("all");
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    fetch("http://localhost:5166/api/Character")
      .then((res) => res.json())
      .then((data) => setCharacters(data))
      .catch((err) => console.error("Error fetching characters:", err));
  }, []);

  const handleCostChange = (event) => {
    setSelectedCost(event.target.value);
  };

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredCharacters = characters
    .filter((char) => {
      const matchesCost =
        selectedCost === "all" || char.cost === parseInt(selectedCost);
      const matchesSearch = char.characterName
        .toLowerCase()
        .includes(searchTerm.toLowerCase());
      return matchesCost && matchesSearch;
    })
    .sort((a, b) => a.characterName.localeCompare(b.characterName));

  const getCharacterImageUrl = (name) => {
    switch (name) {
      case "Dr.Mundo":
        return "http://images.tftproject.nhely.hu/Characters/DrMundo.png";
      case "Twisted Fate":
        return "http://images.tftproject.nhely.hu/Characters/TwistedFate.png";
      case "LeBlanc":
        return "http://images.tftproject.nhely.hu/Characters/Leblanc.png";
      default:
        return `http://images.tftproject.nhely.hu/Characters/${name}.png`;
    }
  };

  return (
    <div className="characters-page-container">
      <h1 className="characters-title">Karakterek</h1>
      <p className="characters-minititle">
        Keress és szűrj a karakterek között, jelenleg a set 13-ban lévő skineket láthatod.
      </p>

      <div className="characters-controls">
        <div className="characters-search-container">
          <label htmlFor="characters-search-input">Keresés</label>
          <input
            type="text"
            id="characters-search-input"
            className="characters-search-input"
            value={searchTerm}
            onChange={handleSearchChange}
            placeholder="Keresés név szerint..."
          />
        </div>

        <div className="characters-filter-container">
          <label htmlFor="characters-filter-select">Szűrés érték szerint</label>
          <select
            id="characters-filter-select"
            className="characters-filter-select"
            value={selectedCost}
            onChange={handleCostChange}
          >
            <option value="all">Összes</option>
            {[1, 2, 3, 4, 5].map((cost) => (
              <option key={cost} value={cost}>
                {cost} értékű
              </option>
            ))}
          </select>
        </div>
      </div>

      <div className="characters-card-container">
        {filteredCharacters.map((char) => (
          <div className="characters-card" key={char.characterId}>
            <h2 className="characters-name">{char.characterName}</h2>
            <img
              src={getCharacterImageUrl(char.characterName)}
              alt={char.characterName}
              onError={(e) => {
                e.target.onerror = null;
                e.target.src = "/placeholder.png";
              }}
            />
            <p className="characters-cost">Ára: {char.cost}</p>
            <p className="characters-health">
              Életereje: {char.health} / {char.health1} / {char.health2}
            </p>
            <p className="characters-mana">
              Mana: {char.manaStart} / {char.manaMax}
            </p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Characters;
