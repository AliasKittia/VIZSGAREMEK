import React, { useEffect, useState } from "react";
import "./Items.css";

const Items = () => {
  const [items, setItems] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5287/api/Items")
      .then((res) => res.json())
      .then((data) => setItems(data))
      .catch((err) => console.error("Error fetching items:", err));
  }, []);

  return (
    <div className="page-container">
      <h1 className="title">Items</h1>
      <div className="card-container">
        {items.map((item) => (
          <div className="card" key={item.id}>
            <h2>{item.name}</h2>
            <img src={`http://localhost:5287${item.icon}`} alt={item.name} />
            <p>{item.description}</p>
            <p>Effects: {item.effects}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Items;
