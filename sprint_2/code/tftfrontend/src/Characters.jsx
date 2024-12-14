import React, { useEffect, useState } from "react";
import "./Characters.css";

const Characters = () => {
  const [characters, setCharacters] = useState([]);

  useEffect(() => {
    fetch("https://localhost:5287/api/Characters")
      .then((res) => res.json())
      .then((data) => setCharacters(data))
      .catch((err) => console.error("Error fetching characters:", err));
  }, []);

  return (
    <div className="page-container">
      <h1 className="title">Characters</h1>
      <div className="card-container">
        {characters.map((char) => (
          <div className="card" key={char.id}>
            <h2>{char.name}</h2>
            <p>Cost: {char.cost}</p>
            <p>Health: {char.health.join(" / ")}</p>
            <p>Mana: {char.mana}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Characters;
