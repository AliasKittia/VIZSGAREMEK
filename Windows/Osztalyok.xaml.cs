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
    /// Interaction logic for Osztalyok.xaml
    /// </summary>
    public partial class Osztalyok : Window
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

        public Osztalyok()
        {
            InitializeComponent();
            LoadOsztalyokAsync();

        }

        public static List<OsztalyLekeresDTO> OsztalyLista { get; set; } = new List<OsztalyLekeresDTO>();
        
        private bool isFlipped = false;

        public async Task LoadOsztalyokAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("Class");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var osztaly = JsonConvert.DeserializeObject<List<OsztalyLekeresDTO>>(json);
                OsztalyLista = osztaly;
                OsztalyListBox.ItemsSource = OsztalyLista;
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
                        if (!isFlipped)
                        {
                            // Átméretezés és láthatóság változtatása
                            frontCard.Visibility = Visibility.Collapsed;
                            backCard.Visibility = Visibility.Visible;

                            // Animáció indítása a nagyításhoz
                            DoubleAnimation WidthAnimation = new DoubleAnimation
                            {
                                To = 550, // Az új magasság
                                Duration = TimeSpan.FromSeconds(0.3)
                            };
                            DoubleAnimation HeightAnimation = new DoubleAnimation
                            {
                                To = 350, // Az új magasság
                                Duration = TimeSpan.FromSeconds(0.3)
                            };

                            // BackCard méretének animálása
                            backCard.BeginAnimation(FrameworkElement.HeightProperty, HeightAnimation);
                            backCard.BeginAnimation(FrameworkElement.WidthProperty, WidthAnimation);
                        }


                        isFlipped = !isFlipped;
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
                        if (isFlipped)
                        {
                            // Animációk létrehozása
                            DoubleAnimation OldSizeAnimationWidth = new DoubleAnimation
                            {
                                To = 150, // Eredeti szélesség
                                Duration = TimeSpan.FromSeconds(0.3)
                            };

                            DoubleAnimation OldSizeAnimationHeight = new DoubleAnimation
                            {
                                To = 200, // Eredeti magasság
                                Duration = TimeSpan.FromSeconds(0.3)
                            };

                            // Storyboard létrehozása az animációkhoz
                            Storyboard storyboard = new Storyboard();
                            storyboard.Children.Add(OldSizeAnimationWidth);
                            storyboard.Children.Add(OldSizeAnimationHeight);

                            Storyboard.SetTarget(OldSizeAnimationWidth, backCard);
                            Storyboard.SetTargetProperty(OldSizeAnimationWidth, new PropertyPath(WidthProperty));

                            Storyboard.SetTarget(OldSizeAnimationHeight, backCard);
                            Storyboard.SetTargetProperty(OldSizeAnimationHeight, new PropertyPath(HeightProperty));

                            // Amikor az animáció befejeződik, állítsa vissza a láthatóságot
                            storyboard.Completed += (s, eArgs) =>
                            {
                                frontCard.Visibility = Visibility.Visible;
                                backCard.Visibility = Visibility.Collapsed;
                            };

                            // Animáció indítása
                            storyboard.Begin();
                        }

                        isFlipped = !isFlipped;
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
