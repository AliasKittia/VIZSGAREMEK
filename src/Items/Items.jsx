import React, { useEffect, useState } from "react";
import "./Items.css";

// Függvény a teljes tárgy képeinek lekérésére
const getFullItemImage = (name) => {
  switch (name) {
    case "Shojin Lándzsája":
      return "http://images.tftproject.nhely.hu/fullitem/Shojin%20l%c3%a1ndzs%c3%a1ja.png";
    default:
      return `http://images.tftproject.nhely.hu/fullitem/${encodeURIComponent(name)}.png`;
  }
};

const Items = () => {
  // Állapotváltozók
  const [fullItems, setFullItems] = useState([]); // A teljes tárgyak
  const [partialItems, setPartialItems] = useState([]); // A fél tárgyak
  const [searchTerm, setSearchTerm] = useState(""); // Keresési kifejezés

  // API hívások a teljes és fél tárgyakra
  useEffect(() => {
    // Kész tárgyak (Full Items)
    fetch("http://localhost:5166/api/FullItems")
      .then((res) => res.json())
      .then((data) => {
        const formattedData = data.map((item) => ({
          ...item,
          imageUrl: getFullItemImage(item.name),
        }));
        setFullItems(formattedData);
      })
      .catch((err) => console.error("Error fetching full items:", err));

    // Fél tárgyak (Partial Items)
    fetch("http://localhost:5166/api/PartialItems")
      .then((res) => res.json())
      .then((data) => {
        const formattedData = data.map((item) => ({
          ...item,
          imageUrl: `http://images.tftproject.nhely.hu/halfitem/${item.name}.png`,
        }));
        setPartialItems(formattedData);
      })
      .catch((err) => console.error("Error fetching partial items:", err));
  }, []);

  // Keresés változása
  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  // Szűrt és rendezett kész tárgyak (Full Items) ABC sorrendben
  const filteredFullItems = fullItems
    .filter((item) => item.name.toLowerCase().includes(searchTerm.toLowerCase()))
    .sort((a, b) => a.name.localeCompare(b.name)); // ABC sorrendbe rendezés

  // Szűrt és rendezett fél tárgyak (Partial Items) ABC sorrendben
  const filteredPartialItems = partialItems
    .filter((item) => item.name.toLowerCase().includes(searchTerm.toLowerCase()))
    .sort((a, b) => a.name.localeCompare(b.name)); // ABC sorrendbe rendezés

  return (
    <div id="items-page">
      <h1 className="title">Tárgyak és receptek</h1>

      <section id="items-intro">
        <p>A játékban megtalálható tárgyak, külön bontva teljes tárgyakra és tárgyösszetevőkre.</p>
      </section>

      <div id="search-section">
        <label htmlFor="search-filter">Keresés: </label>
        <input
          type="text"
          id="search-filter"
          value={searchTerm}
          onChange={handleSearchChange}
          placeholder="Keresés név szerint..."
        />
      </div>

      <section id="full-items">
        <h2 className="title">Kész tárgyak</h2>
        <div className="card-grid">
          {filteredFullItems.map((item) => (
            <div className="card" key={item.id}>
              <img
                src={getFullItemImage(item.name)} // Itt hívjuk meg a getFullItemImage függvényt
                alt={item.name}
                className="item-image"
              />
              <h3 className="item-name">{item.name}</h3>
              <p className="item-effect">Effect 1: {item.halfitemeffect1 || "Nincs adat"}</p>
              <p className="item-effect">Effect 2: {item.halfitemeffect2 || "Nincs adat"}</p>
              <p className="item-effect">Bonus Effect: {item.bonuseffect || "Nincs adat"}</p>
              <p className="item-effect">Bonus Effect 1: {item.bonuseffect1 || "Nincs adat"}</p>
              <p className="item-effect">Bonus Effect 2: {item.bonuseffect2 || "Nincs adat"}</p>
              <p className="item-effect">Active Effect: {item.activeEffect || "Nincs adat"}</p>
            </div>
          ))}
        </div>
      </section>

      <section id="partial-items">
        <h2 className="title">Tárgyösszetevők</h2>
        <div className="card-grid">
          {filteredPartialItems.map((item) => (
            <div className="card" key={item.partial_item_id}>
              <img src={item.imageUrl} alt={item.name} className="item-image" />
              <h3 className="item-name">{item.name}</h3>
              <p className="item-effect">Effect: {item.effect || "Nincs adat"}</p>
            </div>
          ))}
        </div>
      </section>
    </div>
  );
};

export default Items;
