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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Karbantarto.Windows
{
    /// <summary>
    /// Interaction logic for Karakterek.xaml
    /// </summary>
    public partial class Karakterek : Window
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

        public Karakterek()
        {
            InitializeComponent();
            LoadAnomaliakAsync();
        }
        public static List<KarakterLekeresDTO> KarakterLista { get; set; } = new List<KarakterLekeresDTO>();

        public async Task LoadAnomaliakAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("Character");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var karakter = JsonConvert.DeserializeObject<List<KarakterLekeresDTO>>(json);
                KarakterLista = karakter;
                KarakterListBox.ItemsSource = KarakterLista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }
       
        private void FrontCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border frontCard = sender as Border;
            if (frontCard != null)
            {
                Grid parentGrid = frontCard.Parent as Grid;
                if (parentGrid != null)
                {
                    Border backCard = parentGrid.FindName("BackCard") as Border;
                    if (backCard != null)
                    {
                        // Átméretezés és láthatóság változtatása
                        frontCard.Visibility = Visibility.Collapsed;
                        backCard.Visibility = Visibility.Visible;

                        // Animáció indítása
                        DoubleAnimation animation = new DoubleAnimation
                        {
                            To = 300, // Az új magasság
                            Duration = TimeSpan.FromSeconds(0.3)
                        };

                        // BackCard méretének animálása
                        backCard.BeginAnimation(FrameworkElement.HeightProperty, animation);
                        backCard.BeginAnimation(FrameworkElement.WidthProperty, animation);
                    }
                }
            }
        }

        private void BackCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border backCard = sender as Border;
            if (backCard != null)
            {
                Grid parentGrid = backCard.Parent as Grid;
                if (parentGrid != null)
                {
                    Border frontCard = parentGrid.FindName("FrontCard") as Border;
                    if (frontCard != null)
                    {
                        // Átméretezés és láthatóság változtatása
                        frontCard.Visibility = Visibility.Visible;
                        backCard.Visibility = Visibility.Collapsed;

                        // 3 másodperces animáció, hogy visszaálljon az eredeti méretre
                        DoubleAnimation OldSizeAnimationWidth = new DoubleAnimation
                        {
                            From = backCard.ActualWidth,
                            To = 150, // Eredeti szélesség
                            // Az aktuális szélesség
                            Duration = TimeSpan.FromSeconds(0.3) // 0.3 másodpercig tartó animáció
                        };

                        DoubleAnimation OldSizeAnimationHeight = new DoubleAnimation
                        {
                            From = backCard.ActualHeight,
                            To = 200, // Eredeti magasság
                             // Az aktuális magasság
                            Duration = TimeSpan.FromSeconds(0.3) // 0.3 másodpercig tartó animáció
                        };

                        // BackCard méretének visszaállítása animációval
                        backCard.BeginAnimation(FrameworkElement.HeightProperty, OldSizeAnimationHeight);
                        backCard.BeginAnimation(FrameworkElement.WidthProperty, OldSizeAnimationWidth);
                    }
                }
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
