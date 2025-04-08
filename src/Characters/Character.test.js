import React from 'react';
import '@testing-library/jest-dom';
import { render, screen, fireEvent } from '@testing-library/react';
import Characters from './Characters';

describe('Karakter oldal tesztelése', () => {
  test('Karakter oldal helyes renderelése', () => {
    render(<Characters />);
    expect(screen.getByText('Karakterek')).toBeInTheDocument();
    expect(screen.getByPlaceholderText('Keresés név szerint...')).toBeInTheDocument();
  });

  test('Keresési mező bevitelt kezel', () => {
    render(<Characters />);
    const input = screen.getByPlaceholderText('Keresés név szerint...');
    fireEvent.change(input, { target: { value: 'Akali' } });
    expect(input.value).toBe('Akali');
  });

  test('Szűrő működik', () => {
    render(<Characters />);
    const select = screen.getByLabelText('Szűrés érték szerint');
    fireEvent.change(select, { target: { value: '2' } });
    expect(select.value).toBe('2');
  });
});
