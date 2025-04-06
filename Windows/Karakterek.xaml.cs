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
    public partial class Karakterek : Window
    {
        Menu MenuAblak;
        Osztalyok OsztalyAblak;
        Targyak TargyAblak;
        Anomaliak AnomaliaAblak;
        Erosites ErositesAblak;
        Csapatepito CsapatepitoAblak;

        public static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://localhost:5166/api/Character"),
        };

        public Karakterek()
        {
            InitializeComponent();
            LoadKarakterekAsync();
            FillComboBox();
        }

        public static List<KarakterLekeresDTO> KarakterLista { get; set; } = new List<KarakterLekeresDTO>();

        public async Task LoadKarakterekAsync()
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

        private void ModositasBTN_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is KarakterLekeresDTO kivalasztottKarakter)
            {
                var szerkeszto = new KarakterSzerkesztoAblak(kivalasztottKarakter);
                szerkeszto.ShowDialog();
                _ = LoadKarakterekAsync(); // frissítjük a listát mentés után
            }
        }

        private void FillComboBox()
        {
            KarakterClassCBX.Items.Clear();
            KarakterClassCBX.Items.Add(new ComboBoxItem { Content = "Összes" });
            for (int i = 1; i <= 6; i++)
            {
                KarakterClassCBX.Items.Add(new ComboBoxItem { Content = $"{i} gold" });
            }
            KarakterClassCBX.SelectedIndex = 0; // Alapértelmezettként az "Összes" legyen kiválasztva

            // A SelectionChanged esemény hozzáadása
            KarakterClassCBX.SelectionChanged += KarakterClassCBX_SelectionChanged;
        }

        private void KarakterClassCBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ellenőrizzük, hogy a ComboBoxban kiválasztott elem egy számot tartalmaz-e
            if (KarakterClassCBX.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedText = selectedItem.Content.ToString();
                int selectedCost;

                // Ha "Összes"-t választották, akkor minden karaktert megjelenítünk
                if (selectedText == "Összes")
                {
                    KarakterListBox.ItemsSource = KarakterLista;
                }
                else if (int.TryParse(selectedText.Split(' ')[0], out selectedCost))
                {
                    // Ha számot választottak, szűrjük a karaktereket a Cost érték alapján
                    var filteredCharacters = KarakterLista.Where(c => c.Cost == selectedCost).ToList();
                    KarakterListBox.ItemsSource = filteredCharacters;
                }
            }
        }

        private void KarakterNevKeresoTBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (KarakterListBox == null) return;

            string keresettNev = KarakterNevKeresoTBX.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keresettNev))
            {
                KarakterListBox.ItemsSource = KarakterLista;
            }
            else
            {
                var szurtLista = KarakterLista.Where(k => k.CharacterName.ToLower().Contains(keresettNev)).ToList();
                KarakterListBox.ItemsSource = szurtLista;
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
                    Border backCard = parentGrid.FindName("BackCard") as Border;
                    if (backCard != null)
                    {
                        if (!isFlipped)
                        {
                            frontCard.Visibility = Visibility.Collapsed;
                            backCard.Visibility = Visibility.Visible;

                            DoubleAnimation WidthAnimation = new DoubleAnimation
                            {
                                To = 550,

                                Duration = TimeSpan.FromSeconds(0.3)
                            };
                            DoubleAnimation HeightAnimation = new DoubleAnimation
                            {
                                To = 490,
                                Duration = TimeSpan.FromSeconds(0.3)
                            };

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
                            DoubleAnimation OldSizeAnimationWidth = new DoubleAnimation
                            {
                                To = 150,
                                Duration = TimeSpan.FromSeconds(0.3)
                            };

                            DoubleAnimation OldSizeAnimationHeight = new DoubleAnimation
                            {
                                To = 200,
                                Duration = TimeSpan.FromSeconds(0.3)
                            };

                            Storyboard storyboard = new Storyboard();
                            storyboard.Children.Add(OldSizeAnimationWidth);
                            storyboard.Children.Add(OldSizeAnimationHeight);

                            Storyboard.SetTarget(OldSizeAnimationWidth, backCard);
                            Storyboard.SetTargetProperty(OldSizeAnimationWidth, new PropertyPath(WidthProperty));

                            Storyboard.SetTarget(OldSizeAnimationHeight, backCard);
                            Storyboard.SetTargetProperty(OldSizeAnimationHeight, new PropertyPath(HeightProperty));

                            storyboard.Completed += (s, eArgs) =>
                            {
                                frontCard.Visibility = Visibility.Visible;
                                backCard.Visibility = Visibility.Collapsed;
                            };

                            storyboard.Begin();
                        }

                        isFlipped = !isFlipped;
                    }
                }
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
            // Nem kell semmit csinálni, mert már ezen az oldalon vagyunk
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
