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


        //public static  AnomaliaLekersDTO anomaliaLekersDTO;
        public Anomaliak()
        {
            InitializeComponent();
            LoadAnomaliakAsync();
        }

        public static List<AnomaliaLekeresDTO> AnomaliakLista { get; set; } = new List<AnomaliaLekeresDTO>();
        public async Task LoadAnomaliakAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("Anomaly");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var anomaliak = JsonConvert.DeserializeObject<List<AnomaliaLekeresDTO>>(json);
                AnomaliakLista = anomaliak;
                AnomaliakListBox.ItemsSource = AnomaliakLista;
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
