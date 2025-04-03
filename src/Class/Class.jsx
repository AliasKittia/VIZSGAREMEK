import React, { useEffect, useState } from "react";
import "./Class.css";

const Class = () => {
  const [classes, setClasses] = useState([]); // Initialize state
  const [searchTerm, setSearchTerm] = useState(""); // Initialize search term state

  useEffect(() => {
    // Fetch data from backend API
    fetch("http://localhost:5166/api/Class")
      .then((res) => res.json())
      .then((data) => setClasses(data)) // Store data in state
      .catch((err) => console.error("Error fetching classes:", err));
  }, []); // Empty dependency array means this runs once on mount

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredClasses = classes.filter((cls) =>
    cls.className.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="page-container">
      <h1 className="title">Classes</h1>
      <div className="homepage-section">
        <p>
          A játékban megtalálható osztályok.
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

      <div className="card-container">
        {filteredClasses.map((cls) => (
          <div className="card" key={cls.classId}>
            <h2>{cls.className}</h2>
            <p>Alap hatás: {cls.basicEffect}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Class;