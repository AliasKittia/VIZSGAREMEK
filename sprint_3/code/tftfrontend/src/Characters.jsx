import React, { useEffect, useState } from "react";
import "./Characters.css";

const Characters = () => {
  const [characters, setCharacters] = useState([]); // Initialize state

  useEffect(() => {
    // Fetch data from backend API
    fetch("http://localhost:5287/api/Character")
      .then((res) => res.json())
      .then((data) => setCharacters(data)) // Store data in state
      .catch((err) => console.error("Error fetching characters:", err));
  }, []); // Empty dependency array means this runs once on mount

  return (
    <div className="page-container">
      <h1 className="title">Characters</h1>
      <div className="card-container">
        {characters.map((char) => (
          <div className="card" key={char.characterId}>
            <h2>{char.characterName}</h2>
            <img src={`http://localhost:5287${char.picture}`} alt={char.characterName} />
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
