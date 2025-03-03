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
    /// Interaction logic for Targyak.xaml
    /// </summary>
    public partial class Targyak : Window
    {

        Karakterek KarakterAblak;
        Osztalyok OsztalyAblak;
        Targyak TargyAblak;
        Anomaliak AnomaliaAblak;
        Erosites ErositesAblak;
        Csapatepito CsapatepitoAblak;

        public static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://localhost:5000/"),
        };

        public Targyak()
        {
            InitializeComponent();
            LoadFeltargyAsync();
            LoadTeljestargyAsync();
        }

        public static List<FelTargyLekeresDTO> FeltargyLista { get; set; } = new List<FelTargyLekeresDTO>();
        public static List<TeljesTargyLekeresDTO> TeljestargyLista { get; set; } = new List<TeljesTargyLekeresDTO>();


        public async Task LoadFeltargyAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("Item");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var feltargy = JsonConvert.DeserializeObject<List<FelTargyLekeresDTO>>(json);
                FeltargyLista = feltargy;
                FeltargyListBox.ItemsSource = FeltargyLista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        public async Task LoadTeljestargyAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("Item");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var teljestargy = JsonConvert.DeserializeObject<List<TeljesTargyLekeresDTO>>(json);
                TeljestargyLista = teljestargy;
                TeljesTargyListBox.ItemsSource = TeljestargyLista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }



        private void FoOldalBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KarakterekBTN_Click(object sender, RoutedEventArgs e)
        {
            KarakterAblak = new Karakterek();
            KarakterAblak.Show();

        }

        private void ClassokBTN_Click(object sender, RoutedEventArgs e)
        {
            OsztalyAblak = new Osztalyok();
            OsztalyAblak.Show();
        }

        private void ItemekBTN_Click(object sender, RoutedEventArgs e)
        {
            TargyAblak = new Targyak();
            TargyAblak.Show();
        }

        private void AnomaliakBTN_Click(object sender, RoutedEventArgs e)
        {
            AnomaliaAblak = new Anomaliak();
            AnomaliaAblak.Show();
        }

        private void TraitekBTN_Click(object sender, RoutedEventArgs e)
        {
            ErositesAblak = new Erosites();
            ErositesAblak.Show();
        }

        private void CsapatTervezoBTN_Click(object sender, RoutedEventArgs e)
        {
            CsapatepitoAblak = new Csapatepito();
            CsapatepitoAblak.Show();

        }

        private void KilepesBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan kilépsz?", "Kilépés", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void KijelentkezesBTN_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
