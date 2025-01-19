import React from "react";
import "./Homepage.css";

function HomePage() {
  return (
    <div className="homepage-container">
      <h1 className="homepage-title">Üdvözlünk a TFT Stratégiai Útmutatón!</h1>
      <div className="homepage-content">
        <p>
          Itt mindent megtalálsz, amire szükséged van ahhoz, hogy a legjobb legyél a Teamfight Tactics világában! 
          Akár kezdő vagy, akár már tapasztalt játékos, az oldalunk segítségével elsajátíthatod a legjobb taktikai fogásokat.
        </p>
        <div className="homepage-section">
          <p>
            Fedezd fel a legújabb tippeket, trükköket, és kezdj el gyakorolni a győzelemhez vezető úton!
          </p>
        </div>
      </div>
      <div className="homepage-footer">
        <p>Az oldal jelenleg még fejlesztési fázisban áll! <br /> MimitheEmili & AliasKittia</p>
      </div>
    </div>
  );
}

export default HomePage;
