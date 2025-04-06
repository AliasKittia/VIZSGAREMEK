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
        Menu MenuAblak;
        Karakterek KarakterAblak;
        Osztalyok OsztalyAblak;
        Targyak TargyAblak;
        Anomaliak AnomaliaAblak;
        Erosites ErositesAblak;
        Csapatepito CsapatepitoAblak;
        FelTargyModositasWindow felTargyModositasAblak;

        public static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://localhost:5166/Api/Fullitems"),
        };
        public static HttpClient sharedsClient = new()
        {
            BaseAddress = new Uri("http://localhost:5166/Api/Partialitems"),
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
                var response = await sharedClient.GetAsync("Fullitems");
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

        private void ModositasFeltargyBTN_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is FelTargyLekeresDTO kivalasztottfeltargy)
            {
                var szerkeszto = new FelTargyModositasWindow(kivalasztottfeltargy);
                szerkeszto.ShowDialog();
                // újratöltés mentés után
                _ = LoadFeltargyAsync();
            }
        }

        private async void ModositasTeljestargyBTN_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is TeljesTargyLekeresDTO kivalasztottteljestargy)
            {
                var szerkeszto = new TeljesTargyModositasWindow(kivalasztottteljestargy);
                szerkeszto.ShowDialog();
                // újratöltés mentés után
                _ = LoadTeljestargyAsync();
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




        private void TargyNevKeresoTBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TeljesTargyListBox == null) return;

            string keresettNev = TargyNevKeresoTBX.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keresettNev))
            {
                TeljesTargyListBox.ItemsSource = TeljesTargyLista;
            }
            else
            {
                var szurtLista = TeljesTargyLista.Where(k => k.Name.ToLower().Contains(keresettNev)).ToList();
                TeljesTargyListBox.ItemsSource = szurtLista;
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
            //nem kell, mert ezen az oldalon vagyunk
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
