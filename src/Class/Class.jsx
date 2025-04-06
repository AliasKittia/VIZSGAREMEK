import React, { useEffect, useState } from "react";
import "./Class.css";

const characterData = [
  
  {
    className: "Akadémia",
    characters: ["Lux","Leona","Ezreal","Heimerdinger","Jayce"],
  },
  {
    className:"A gépek hírnöke",
    characters: ["Victor"],
  },
  {
    className:"Alakváltó",
    characters: ["Swain","Gangplank","Elise","Jayce"],
  },
  {
    className:"Automata",
    characters: ["Amumu","Nocturne","Blitzcrank","Kogmaw","Malzahar"],
  },
  {
    className:"Barkácsoló",
    characters: ["Powder","Trundle","Ziggs","Gangplank","Ekko","Corki","Rumble"],
  },
  {
    className:"Család",
    characters: ["Violet","Powder","Vander"],
  },
  {
    className:"Egyeduralkodó",
    characters: ["Ziggs","Blitzcrank","Cassiopeia","Dr.Mundo","Silco","Mordekaiser"],
  },
  {
    className:"Fekete rózsa",
    characters: ["Morgana","Vladimir","Cassiopeia","Elise","LeBanc",],
  },
  {
    className:"Gladiátor",
    characters: ["Violet","Draven","Urgot","Gangplank","Vi","Sevika"],
  },
  {
    className:"Gyorstámadó",
    characters: ["Akali","Nocturne","Twisted Fate","Ambessa",],
  },
  {
    className:"Hódító",
    characters: ["Darius","Draven","Rell","Swain","Ambessa","Mordekaiser"],
  },
  {
    className:"Kísérlet",
    characters: ["Zyra","Urgot","Nunu","Dr.Mundo","Twitch","Warwick"],
  },
  {
    className:"Követ",
    characters: ["Trystana","Nami","Garen","Ambessa"],
  },
  {
    className:"Lázadó",
    characters: ["Vex","Irelia","Akali","Sett","Ezreal","Illaoi","Zoe","Jinx"],
  },
  {
    className:"Látnok",
    characters: ["Vex","Morgana","Rell","Renata","Nunu","Heimerdinger","Malzahar"],
  },
  {
    className:"Mesterlövész",
    characters: ["Maddie","Zeri","Kogmaw","Twitch","Caitlyn"],
  },
  {
    className:"Nagy menő",
    characters: ["Sevika"],
  },
  {
    className:"Örző",
    characters: ["Irelia","Singed","Rell","Leona","Loris","Illaoi","Rumble"],
  },
  {
    className:"Rajtaütő",
    characters: ["Powder","Camille","Smeech","Ekko","Jinx"],
  },
  {
    className:"Roncskirály",
    characters: ["Rumble"],
  },
  {
    className:"Szikra",
    characters: ["Zeri","Scar","Ekko"],
  },
  {
    className:"Száműzött varázsló",
    characters: ["Mel"],
  },
  {
    className:"Tüzér",
    characters: ["Tristana","Urgot","Ezreal","Corki"],
  },
  {
    className:"Varázsló",
    characters: ["Lux","Vladimir","Swain","Nami","Zoe","LeBlanc","Zoe","Jinx"],
  },
  {
    className:"Vegybáró",
    characters: ["Singed","Renata","Smeech","Renni","Silco","Sevika"],
  },
  {
    className:"Végrehajtó",
    characters: ["Maddie","Steb","Camille","Twisted Fate","Loris","Vi","Caitlyn"],
  },
  {
    className:"Vérvadász",
    characters: ["Warwick"]
  },
  {
    className:"Virrasztó",
    characters: ["Amumu","Darius","Vander","Vladimir","Scar","Garen"],
  },
  {
    className:"Zúzó",
    characters: ["Steb","Trundle","Sett","Scar","Renni","Elise"],
  },
  
 
];

const Class = () => {
  const [classes, setClasses] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    fetch("http://localhost:5166/api/Class")
      .then((res) => res.json())
      .then((data) => setClasses(data))
      .catch((err) => console.error("Error fetching classes:", err));
  }, []);

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredClasses = classes.filter((cls) =>
    cls.className.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const getClassImageUrl = (name) => {
    return `http://images.tftproject.nhely.hu/Classes/${name}.png`;
  };

  return (
    <div className="class-page">
      <header className="class-header">
        <h1 className="class-title">Osztályok</h1>
        <p className="class-description">
          Böngéssz a játékban található különböző osztályok között!
        </p>
      </header>

      <div className="search-section">
        <label htmlFor="search-input" className="search-label">Keresés osztály névre</label>
        <input
          type="text"
          id="search-input"
          className="search-box"
          placeholder="Keresés név szerint..."
          value={searchTerm}
          onChange={handleSearchChange}
        />
      </div>

      <main className="class-container">
        {filteredClasses.map((cls) => {
          const matchingClass = characterData.find(c => c.className === cls.className);
          
          return (
            <div className="class-card" key={cls.classId}>
              <img
                src={getClassImageUrl(cls.className)}
                alt={cls.className}
                className="class-image"
                onError={(e) => {
                  e.target.onerror = null;
                  e.target.src = "/placeholder.png";
                }}
              />
              <h2 className="class-name">{cls.className}</h2>
              <p className="class-effect">Alap hatás: {cls.basicEffect}</p>

              {/* Karakterek listája */}
{matchingClass && matchingClass.characters.length > 0 && (
  <div className="characters-list">
    <h3>Karakterek:</h3>
    <p>{matchingClass.characters.join(", ")}</p>
  </div>
)}

            </div>
          );
        })}
      </main>
    </div>
  );
};

export default Class;
