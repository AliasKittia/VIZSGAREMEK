import React, { useEffect, useState } from "react";
import "./Items.css";

const Items = () => {
  const [fullItems, setFullItems] = useState([]);
  const [partialItems, setPartialItems] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    // Fetch FullItems from backend API
    fetch("http://localhost:5166/api/FullItems")
      .then((res) => res.json())
      .then((data) => setFullItems(data))
      .catch((err) => console.error("Error fetching full items:", err));

    // Fetch PartialItems from backend API
    fetch("http://localhost:5166/api/PartialItems")
      .then((res) => res.json())
      .then((data) => setPartialItems(data))
      .catch((err) => console.error("Error fetching partial items:", err));
  }, []);

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredFullItems = fullItems.filter((item) =>
    item.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const filteredPartialItems = partialItems.filter((item) =>
    item.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="page-container">
      <h1 className="title">Tárgyak és receptek</h1>
      <div className="homepage-section">
        <p>
          A játékban megtalálható tárgyak, külön bontva teljes tárgyakra és tárgyösszetevőkre.
        </p>
      </div>
      
      <div className="search-container">
        <label htmlFor="search-filter">Search: </label>
        <input
          type="text"
          id="search-filter"
          value={searchTerm}
          onChange={handleSearchChange}
          placeholder="Keresés név szerint..."
          className="search-input"
        />
      </div>

      <h2 className="title">Kész tárgyak </h2>
      <div className="card-container">
        {filteredFullItems.map((item) => (
          <div className="card" key={item.id}>
            <h2>{item.name}</h2>
            <p>Effect 1: {item.halfitemeffect1}</p>
            <p>Effect 2: {item.halfitemeffect2}</p>
            <p>Bonus Effect: {item.bonuseffect}</p>
            <p>Bonus Effect 1: {item.bonuseffect1}</p>
            <p>Bonus Effect 2: {item.bonuseffect2}</p>
            <p>Active Effect: {item.activeEffect}</p>
          </div>
        ))}
      </div>

      <h2 className="title">Tárgyösszetevők</h2>
      <div className="card-container">
        {filteredPartialItems.map((item) => (
          <div className="card" key={item.partial_item_id}>
            <h2>{item.name}</h2>
            <p>Effect: {item.effect}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Items;
