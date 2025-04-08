import React from 'react';
import '@testing-library/jest-dom';
import { render, screen, fireEvent } from '@testing-library/react';
import Class from './Class';

describe('Karakter oldal tesztelése', () => {
  test('Karakter oldal helyes renderelése', () => {
    render(<Class />);
    expect(screen.getByText('Osztályok')).toBeInTheDocument();
    expect(screen.getByPlaceholderText('Keresés név szerint...')).toBeInTheDocument();
  });

  test('Keresési mező bevitelt kezel', () => {
    render(<Class />);
    const input = screen.getByPlaceholderText('Keresés név szerint...');
    fireEvent.change(input, { target: { value: 'Akadémia' } });
    expect(input.value).toBe('Akadémia');
  });
});