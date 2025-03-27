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

        public static List<FelTargyLekeresDTO> FelTargyLista { get; set; } = new List<FelTargyLekeresDTO>();
        public static List<TeljesTargyLekeresDTO> TeljesTargyLista { get; set; } = new List<TeljesTargyLekeresDTO>();


        public async Task LoadFeltargyAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("Partialitems");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var feltargy = JsonConvert.DeserializeObject<List<FelTargyLekeresDTO>>(json);
                FelTargyLista = feltargy;
                FelTargyListBox.ItemsSource = FelTargyLista;
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
                var response = await sharedClient.GetAsync("Fullitem");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var teljestargy = JsonConvert.DeserializeObject<List<TeljesTargyLekeresDTO>>(json);
                TeljesTargyLista = teljestargy;
                TeljesTargyListBox.ItemsSource = TeljesTargyLista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private bool isFlipped = false;

        private void FrontCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border frontCard = sender as Border;
            if (frontCard != null)
            {
                Grid parentGrid = frontCard.Parent as Grid;
                if (parentGrid != null)
                {
                    Border backCard = FindChild<Border>(parentGrid, "BackCard");
                    if (backCard != null)
                    {
                        if (!isFlipped)
                        {
                            frontCard.Visibility = Visibility.Collapsed;
                            backCard.Visibility = Visibility.Visible;

                            DoubleAnimation widthAnimation = new DoubleAnimation
                            {
                                To = 200, // Az új szélesség
                                Duration = TimeSpan.FromSeconds(0.3)
                            };

                            DoubleAnimation heightAnimation = new DoubleAnimation
                            {
                                To = 250, // Az új magasság
                                Duration = TimeSpan.FromSeconds(0.3)
                            };

                            backCard.BeginAnimation(WidthProperty, widthAnimation);
                            backCard.BeginAnimation(HeightProperty, heightAnimation);

                            isFlipped = true;
                        }
                    }
                }
            }
        }

        // Segédmetódus a megfelelő elem megtalálására
        private static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T tChild && ((FrameworkElement)child).Name == childName)
                {
                    return tChild;
                }
                else
                {
                    T foundChild = FindChild<T>(child, childName);
                    if (foundChild != null)
                        return foundChild;
                }
            }
            return null;
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

        private void FeltargyBTN_Click(object sender, RoutedEventArgs e)
        {
            FelTargyListBox.Visibility = Visibility.Visible;
            TeljesTargyListBox.Visibility = Visibility.Collapsed;
        }

        private void TeljestargyBTN_Click(object sender, RoutedEventArgs e)
        {
            TeljesTargyListBox.Visibility = Visibility.Visible;
            FelTargyListBox.Visibility = Visibility.Collapsed;
        }
    }
}
