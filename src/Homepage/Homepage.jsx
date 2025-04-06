import React from "react";
import "./Homepage.css";

function HomePage() {
  return (
    <div className="homepage">
      <h1 className="homepage-title">Üdvözlünk a TFT Stratégiai Útmutatón!</h1>

      <p className="homepage-text">
        Itt mindent megtalálsz, amire szükséged van ahhoz, hogy a legjobb legyél a Teamfight Tactics világában!
        Akár kezdő vagy, akár tapasztalt játékos, oldalunk segít elsajátítani a legjobb taktikai fogásokat.
      </p>

      <p className="homepage-highlight">
        Fedezd fel a legújabb tippeket és trükköket – készülj fel a győzelemre!
      </p>

      <p className="homepage-note">
        Az oldal jelenleg még fejlesztés alatt áll. <br /> MimitheEmili & AliasKittia
      </p>
    </div>
  );
}

export default HomePage;
