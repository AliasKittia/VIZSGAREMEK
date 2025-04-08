import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom';
import Characters from './Characters';

// Alaphelyzet: ne valódi fetch hívást használjunk, hanem helyettesítsük (mock)
beforeEach(() => {
  global.fetch = jest.fn(() =>
    Promise.resolve({
      json: () =>
        Promise.resolve([
          { characterId: 1, characterName: 'Akali', cost: 2, health: 500, health1: 800, health2: 1000, manaStart: 0, manaMax: 60 },
          { characterId: 2, characterName: 'Garen', cost: 1, health: 600, health1: 900, health2: 1200, manaStart: 30, manaMax: 80 },
        ]),
    })
  );
});

afterEach(() => {
  jest.clearAllMocks();
});

test('Keresés működik: csak a találat jelenik meg', async () => {
  render(<Characters />);

  // Várunk, amíg megjelennek a karakterek
  await waitFor(() => {
    expect(screen.getByText('Akali')).toBeInTheDocument();
    expect(screen.getByText('Garen')).toBeInTheDocument();
  });

  // Keresés beírása
  const input = screen.getByPlaceholderText('Keresés név szerint...');
  fireEvent.change(input, { target: { value: 'Akali' } });

  // Várjuk, hogy csak Akali maradjon a listában
  await waitFor(() => {
    expect(screen.getByText('Akali')).toBeInTheDocument();
    expect(screen.queryByText('Garen')).not.toBeInTheDocument();
  });
});
