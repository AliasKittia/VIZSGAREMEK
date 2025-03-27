using Karbantarto.Classes;
using Karbantarto.Windows;
using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Karbantarto.Windows
{
    /// <summary>
    /// Interaction logic for Anomaliak.xaml
    /// </summary>
    public partial class Anomaliak : Window
    {
        Menu MenuAblak;
        Karakterek KarakterAblak;
        Osztalyok OsztalyAblak;
        Targyak TargyAblak;
        Erosites ErositesAblak;
        Csapatepito CsapatepitoAblak;


        public static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://localhost:5000/api/Anomalies"),
        };


        //public static  AnomaliaLekersDTO anomaliaLekersDTO;
        public Anomaliak()
        {
            InitializeComponent();
            LoadAnomaliakAsync();
            
        }

        public static List<AnomaliaLekeresDTO> AnomaliaLista { get; set; } = new List<AnomaliaLekeresDTO>();
        public async Task LoadAnomaliakAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("Anomalies");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var anomaliak = JsonConvert.DeserializeObject<List<AnomaliaLekeresDTO>>(json);
                AnomaliaLista = anomaliak;
                AnomaliaListBox.ItemsSource = AnomaliaLista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void AnomaliaNevKeresoTBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AnomaliaListBox == null) return;

            string keresettNev = AnomaliaNevKeresoTBX.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keresettNev))
            {
                AnomaliaListBox.ItemsSource = AnomaliaLista;
            }
            else
            {
                var szurtLista = AnomaliaLista.Where(k => k.AnomalyName.ToLower().Contains(keresettNev)).ToList();
                AnomaliaListBox.ItemsSource = szurtLista;
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
            //Nem kell semmit csinálni, mert már itt vagyunk
        }

        private void TraitekBTN_Click(object sender, RoutedEventArgs e)
        {
            ErositesAblak = new Erosites();
            ErositesAblak.Show();
            this.Close();
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
