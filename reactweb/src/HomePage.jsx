import React, { useState } from 'react';
import './App.css'; // vagy más stílus fájl
import Augments from './Augments';
import Characters from './Characters';
import Class from './Class';
import Items from './Items';
import Portals from './Portals';
import HomePage from './HomePage';

const pages = {
  augments: Augments,
  characters: Characters,
  class: Class,
  items: Items,
  portals: Portals,
  homepage: HomePage, // Győződj meg róla, hogy az `HomePage` itt létezik
};

const HomePages = () => {
  const [currentPage, setCurrentPage] = useState('homepage');

  const CurrentPageComponent = pages[currentPage];

  return (
    <div>
      <nav>
        <button onClick={() => setCurrentPage('homepage')}>Home</button>
        <button onClick={() => setCurrentPage('augments')}>Augments</button>
        <button onClick={() => setCurrentPage('characters')}>Character</button>
        <button onClick={() => setCurrentPage('class')}>Class</button>
        <button onClick={() => setCurrentPage('items')}>Items</button>
        <button onClick={() => setCurrentPage('portals')}>Portals</button>
      </nav>
      <div>
        <CurrentPageComponent />
      </div>
    </div>
  );
};

export default HomePages;
