import React from "react";
import { render, screen, waitFor, fireEvent } from "@testing-library/react";
import Characters from "./Characters";
import "@testing-library/jest-dom";

global.fetch = jest.fn(() =>
    Promise.resolve({
        json: () =>
            Promise.resolve([
                {
                    characterId: 1,
                    characterName: "Loris",
                    cost: 3,
                    health: 850,
                    health1: 1530,
                    health2: 2754,
                    manaStart: 50,
                    manaMax: 100,
                    characterImageBlob: "http://images.tftproject.nhely.hu/Characters/Loris.png",
                },
            ]),
    })
);

beforeEach(() => {
    fetch.mockClear();
});

test("renders character data from API", async () => {
    render(<Characters />);

    expect(screen.getByText(/Characters/i)).toBeInTheDocument();
    
    await waitFor(() => expect(fetch).toHaveBeenCalledTimes(1));

    expect(await screen.findByText("Loris")).toBeInTheDocument();
    await screen.findByText("Loris");

    const select = screen.getByLabelText(/Szűrés érték szerint:/i);
    fireEvent.change(select, { target: { value: "3" } });

    expect(screen.queryByText("Loris")).not.toBeInTheDocument();
    
    fireEvent.change(select, { target: { value: "3" } });
    expect(await screen.findByText("Loris")).toBeInTheDocument();

    expect(screen.getByAltText("Loris")).toHaveAttribute(
        "src",
        "http://images.tftproject.nhely.hu/Characters/Loris.png"
    );
});

test("filters characters by search", async () => {
    render(<Characters />);
    await screen.findByText("Loris");

    const searchInput = screen.getByPlaceholderText(/Keresés név szerint.../i);
    fireEvent.change(searchInput, { target: { value: "Loris" } });

    expect(screen.queryByText("Loris")).not.toBeInTheDocument();
    
    fireEvent.change(searchInput, { target: { value: "Loris" } });
    expect(await screen.findByText("Loris")).toBeInTheDocument();
});

test("displays no characters when API returns empty array", async () => {
    fetch.mockImplementationOnce(() =>
        Promise.resolve({
            json: () => Promise.resolve([]),
        })
    );

    render(<Characters />);

    await waitFor(() => expect(fetch).toHaveBeenCalledTimes(1));

    expect(screen.queryByText("Loris")).not.toBeInTheDocument();
    expect(screen.getByText(/No characters found/i)).toBeInTheDocument();
});

test("displays error message when API call fails", async () => {
    fetch.mockImplementationOnce(() => Promise.reject("API is down"));

    render(<Characters />);

    await waitFor(() => expect(fetch).toHaveBeenCalledTimes(1));

    expect(screen.getByText(/Error fetching characters/i)).toBeInTheDocument();
});

test("filters characters by cost", async () => {
    render(<Characters />);
    await screen.findByText("Loris");

    const select = screen.getByLabelText(/Szűrés érték szerint:/i);
    fireEvent.change(select, { target: { value: "2" } });

    expect(screen.queryByText("Loris")).not.toBeInTheDocument();
    
    fireEvent.change(select, { target: { value: "3" } });
    expect(await screen.findByText("Loris")).toBeInTheDocument();
});
