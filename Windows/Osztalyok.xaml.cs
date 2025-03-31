using Karbantarto.Classes.ProjectName_Backend.DTOs;
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
        Menu MenuAblak;
        Karakterek KarakterAblak;
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
            LoadOsztalyAsync();
        }

        public static List<OsztalyDTO> OsztalyLista { get; set; } = new List<OsztalyDTO>();

        public static List<SzintDTO> SzintLista { get; set; } = new List<SzintDTO>();

        public static List<KarakterDTO> KarakterLista { get; set; } = new List<KarakterDTO>();


        //Osztályok listázása
        public async Task LoadOsztalyAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("OsztalySzintEsKarakter");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var osztalyok = JsonConvert.DeserializeObject<List<OsztalyDTO>>(json);

                OsztalyLista = osztalyok;
                OsztalyListBox.ItemsSource = OsztalyLista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void OsztalyNevKeresoTBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OsztalyListBox == null) return;

            string keresettNev = OsztalyNevKeresoTBX.Text.ToLower();

            if (string.IsNullOrWhiteSpace(keresettNev))
            {
                OsztalyListBox.ItemsSource = OsztalyLista;
            }
            else
            {
                var szurtLista = OsztalyLista.Where(k => k.ClassName.ToLower().Contains(keresettNev)).ToList();
                OsztalyListBox.ItemsSource = szurtLista;
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
                                To = 450, // Az új magasság
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
            //Nem kell, mert már itt vagyunk
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
