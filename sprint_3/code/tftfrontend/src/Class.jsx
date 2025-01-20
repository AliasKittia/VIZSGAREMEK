import React, { useEffect, useState } from "react";
import "./Class.css";

const Class = () => {
  const [classes, setClasses] = useState([]); // Initialize state

  useEffect(() => {
    // Fetch data from backend API
    fetch("http://localhost:5287/api/Class")
      .then((res) => res.json())
      .then((data) => setClasses(data)) // Store data in state
      .catch((err) => console.error("Error fetching classes:", err));
  }, []); // Empty dependency array means this runs once on mount

  return (
    <div className="page-container">
      <h1 className="title">Classes</h1>
      <div className="card-container">
        {classes.map((cls) => (
          <div className="card" key={cls.classId}>
            <h2>{cls.className}</h2>
            <p>Basic Effect: {cls.basicEffect}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Class;