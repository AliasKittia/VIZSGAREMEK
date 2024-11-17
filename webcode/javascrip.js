document.getElementById('hamburger').addEventListener('click', () => {
    const navLinks = document.getElementById('nav-links');
    navLinks.classList.toggle('active');
});

function showTable(tableNumber) {
    // Minden táblázat elrejtése
    const tables = document.querySelectorAll('.table-container');
    tables.forEach(table => table.classList.remove('active'));

    // A kiválasztott táblázat megjelenítése
    const selectedTable = document.getElementById(`tier-${tableNumber}`);
    selectedTable.classList.add('active');
}