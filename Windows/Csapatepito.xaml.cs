using Karbantarto.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Karbantarto.Windows
{
    /// <summary>
    /// Interaction logic for Csapatepito.xaml
    /// </summary>
    public partial class Csapatepito : Window
    {
        private int _boardId = 1; // A tábla ID-ja, amit betöltünk/mentünk
        private List<HexCellDTO> _hexCells = new List<HexCellDTO>();
        Menu MenuAblak;
        Karakterek KarakterAblak;
        Osztalyok OsztalyAblak;
        Targyak TargyAblak;
        Anomaliak AnomaliaAblak;
        Erosites ErositesAblak;
        Csapatepito CsapatepitoAblak;

        public Csapatepito()
        {
            InitializeComponent();
            CreateHexagonalGrid(4, 7); // 4 sor és 7 oszlop
            LoadBoardData(); // Betöltjük az adatbázisból a karaktereket
        }

        private void CreateHexagonalGrid(int rows, int columns)
        {
            double hexRadius = 40; // Hexagon sugara
            double hexWidth = Math.Sqrt(3) * hexRadius; // Hexagon szélessége
            double hexHeight = 2 * hexRadius; // Hexagon magassága
            double horizontalSpacing = hexWidth; // Vízszintes eltolás
            double verticalSpacing = hexHeight * 0.75; // Függőleges eltolás (csökkentett)

            // A Canvas méretének beállítása
            double canvasWidth = columns * horizontalSpacing + hexWidth;
            double canvasHeight = rows * verticalSpacing + hexHeight;
            HexGridCanvas.Width = canvasWidth;
            HexGridCanvas.Height = canvasHeight;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    // Az X és Y koordináták meghatározása
                    double x = col * horizontalSpacing;

                    // Minden második sort vízszintesen eltolunk
                    if (row % 2 == 1)
                    {
                        x += hexWidth / 2; // Elmozdítás az oszlopoknál
                    }

                    double y = row * verticalSpacing; // Függőleges eltolás változatlan

                    var hexCell = new HexCellDTO
                    {
                        Id = _hexCells.Count + 1,
                        X = col,
                        Y = row,
                        CharacterId = null // Alapértelmezetten nincs karakter
                    };

                    _hexCells.Add(hexCell);
                    DrawHexagon(x, y, hexRadius, hexCell);
                }
            }
        }


        private void DrawHexagon(double x, double y, double radius, HexCellDTO hexCell)
        {
            Polygon hexagon = new Polygon
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = Brushes.LightBlue,
                Tag = hexCell // Hozzáadjuk a hexCell objektumot a polygon tag-jához
            };

            PointCollection points = new PointCollection();

            // Hexagon pontjainak kiszámítása a szög elforgatásával
            for (int i = 0; i < 6; i++)
            {
                double angle = Math.PI / 3 * i - Math.PI / 6; // Elforgatás 30 fokkal
                double px = x + radius * Math.Cos(angle);
                double py = y + radius * Math.Sin(angle);
                points.Add(new Point(px, py));
            }

            hexagon.Points = points;

            hexagon.MouseDown += Hexagon_MouseDown; // Kattintás kezelése

            HexGridCanvas.Children.Add(hexagon);
        }


        private void Hexagon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var hexagon = sender as Polygon;
            var hexCell = hexagon.Tag as HexCellDTO;

            if (hexCell != null)
            {
                // Ha a hexagonra kattintunk, megnyitunk egy karakter kiválasztó felületet
                MessageBox.Show($"Hex {hexCell.X},{hexCell.Y} - CharacterID: {hexCell.CharacterId}");
            }
        }

        private void LoadBoardData()
        {
            // Itt kell betöltened az adatbázisból a karaktereket (Board_hexese tábla alapján)
            // Az adatok betöltése után frissíteni kell a hexagonokat a karakterekkel.
            foreach (var hexCell in _hexCells)
            {
                // Betöltés a Board_hexese táblából az adott hex_x, hex_y alapján
                var characterId = GetCharacterForCell(hexCell.X, hexCell.Y);
                hexCell.CharacterId = characterId;
            }
        }

        private int? GetCharacterForCell(int x, int y)
        {
            // Itt kell az adatbázisból lekérni a karakterek ID-ját a hex_x és hex_y alapján
            // Ha nincs karakter, akkor null-t kell visszaadni
            return null; // Csak példa, itt kell az adatbázisból lekérni az adatokat
        }

        // Táblázat mentése
        private void SaveBoardData()
        {
            foreach (var hexCell in _hexCells)
            {
                SaveHexCellData(hexCell);
            }
        }

        private void SaveHexCellData(HexCellDTO hexCell)
        {
            // Az adatokat elmenthetjük az adatbázisba a Board_hexese táblába
            // Itt kell az adatbázis műveletet elvégezni, például ADO.NET-tel
        }

        private void FoOldalBTN_Click(object sender, RoutedEventArgs e)
        {
            MenuAblak = new Menu();
            MenuAblak.Show();
            this.Close();

        }

        private void KarakterekBTN_Click(object sender, RoutedEventArgs e)
        {
            KarakterAblak = new Karakterek();
            KarakterAblak.Show();
            this.Close();
        }

        private void ClassokBTN_Click(object sender, RoutedEventArgs e)
        {
            OsztalyAblak = new Osztalyok();
            OsztalyAblak.Show();
            this.Close();
        }

        private void ItemekBTN_Click(object sender, RoutedEventArgs e)
        {
            TargyAblak = new Targyak();
            TargyAblak.Show();
            this.Close();
        }

        private void AnomaliakBTN_Click(object sender, RoutedEventArgs e)
        {
            AnomaliaAblak = new Anomaliak();
            AnomaliaAblak.Show();
            this.Close();
        }

        private void TraitekBTN_Click(object sender, RoutedEventArgs e)
        {
            ErositesAblak = new Erosites();
            ErositesAblak.Show();
            this.Close();
        }

        private void CsapatTervezoBTN_Click(object sender, RoutedEventArgs e)
        {
            //Nem kell csinálni semmit, mert már ezen az ablakon vagyunk

        }

        private void KilepesBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan kilépsz?", "Kilépés", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void TablaMentesBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

