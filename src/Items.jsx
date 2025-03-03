import React, { useEffect, useState } from "react";
import "./Items.css";

const Items = () => {
  const [fullItems, setFullItems] = useState([]);
  const [partialItems, setPartialItems] = useState([]);

  useEffect(() => {
    // Fetch FullItems from backend API
    fetch("http://localhost:5287/api/FullItems")
      .then((res) => res.json())
      .then((data) => setFullItems(data))
      .catch((err) => console.error("Error fetching full items:", err));

    // Fetch PartialItems from backend API
    fetch("http://localhost:5287/api/PartialItems")
      .then((res) => res.json())
      .then((data) => setPartialItems(data))
      .catch((err) => console.error("Error fetching partial items:", err));
  }, []);

  return (
    <div className="page-container">
      <h1 className="title">Items</h1>
      <p className="items-p">
        A játékban megtalálható tárgyak listája. A tárgyakat két csoportba oszthatjuk.
      </p>
      <h2 className="title">Full Items</h2>
      <div className="card-container">
        {fullItems.map((item) => (
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

      <h2 className="title">Partial Items</h2>
      <div className="card-container">
        {partialItems.map((item) => (
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
