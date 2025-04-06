using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Karbantarto.Windows
{
    /// <summary>
    /// Interaction logic for Erosites.xaml
    /// </summary>
    public partial class Erosites : Window
    {

        Menu MenuAblak;
        Karakterek KarakterAblak;
        Osztalyok OsztalyAblak;
        Targyak TargyAblak;
        Anomaliak AnomaliaAblak;
        
        Csapatepito CsapatepitoAblak;

        public static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://localhost:5166/api/Augment"),
        };

        public Erosites()
        {
            InitializeComponent();
            LoadErositesAsync();
            FillComboBox();
        }

        public static List<ErositesLekeresDTO> ErositesLista { get; set; } = new List<ErositesLekeresDTO>();

        public async Task LoadErositesAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("Augment");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var erosites = JsonConvert.DeserializeObject<List<ErositesLekeresDTO>>(json);
                ErositesLista = erosites;
                ErositesListBox.ItemsSource = ErositesLista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }
        private void ModositasBTN_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is ErositesLekeresDTO kivalasztottErosites)
            {
                var szerkeszto = new ErositesSzerkesztoAblak(kivalasztottErosites);
                szerkeszto.ShowDialog();
                _ = LoadErositesAsync(); // újratöltés mentés után
            }
        }

        private void FillComboBox()
        {
            ErositesCBX.Items.Clear();
            ErositesCBX.Items.Add(new ComboBoxItem { Content = "Összes" });

            // Az új rarity értékek beállítása
            string[] rarityOptions = { "ezüst", "arany", "prizmatikus" };

            foreach (var rarity in rarityOptions)
            {
                ErositesCBX.Items.Add(new ComboBoxItem { Content = rarity });
            }

            ErositesCBX.SelectedIndex = 0; // Alapértelmezettként az "Összes" legyen kiválasztva
            ErositesCBX.SelectionChanged += ErositesCBX_SelectionChanged; // Esemény feliratkozása
        }

        private void ErositesCBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ErositesCBX.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedText = selectedItem.Content.ToString();

                // Ha "Összes"-t választották, akkor minden elemet megjelenítünk
                if (selectedText == "Összes")
                {
                    ErositesListBox.ItemsSource = ErositesLista;
                }
                else
                {
                    // Szűrés az AugmentRarity értéke alapján
                    var filteredList = ErositesLista
                        .Where(c => c.AugmentRarity != null && c.AugmentRarity.Equals(selectedText, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    ErositesListBox.ItemsSource = filteredList;
                }
            }
        }




        private void ErositesNevKeresoTBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ErositesListBox == null) return;

            string keresettNev = ErositesNevKeresoTBX.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keresettNev))
            {
                ErositesListBox.ItemsSource = ErositesLista;
            }
            else
            {
                var szurtLista = ErositesLista.Where(k => k.AugmentName.ToLower().Contains(keresettNev)).ToList();
                ErositesListBox.ItemsSource = szurtLista;
            }
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
            //Nem kell megvalósítani, mert az erősítés oldalon vagyunk
        }

        private void CsapatTervezoBTN_Click(object sender, RoutedEventArgs e)
        {
            CsapatepitoAblak = new Csapatepito();
            CsapatepitoAblak.Show();
            this.Close();

        }

        private void KilepesBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan kilépsz?", "Kilépés", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
