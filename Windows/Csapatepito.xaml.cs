using Karbantarto.Classes;
using Karbantarto.Classes.ProjectName_Backend.DTOs;
using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Karbantarto.Windows
{
    /// <summary>
    /// Interaction logic for Csapatepito.xaml
    /// </summary>
    public partial class Csapatepito : Window
    {
        public static List<OsztalyDTO> OsztalyLista { get; set; } = new List<OsztalyDTO>();

        public static List<CsapatepitoKarakterDTO> KarakterLista { get; set; } = new List<CsapatepitoKarakterDTO>();

        private CsapatepitoKarakterDTO? SelectedCharacter;


        Menu MenuAblak;
        Karakterek KarakterAblak;
        Osztalyok OsztalyAblak;
        Targyak TargyAblak;
        Anomaliak AnomaliaAblak;
        Erosites ErositesAblak;
        Csapatepito CsapatepitoAblak;

        public static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://localhost:5166/api/KarakterClass"),
        };

        public Csapatepito()
        {
            InitializeComponent();
            LoadKarakterekAsync(); // pl. saját metódus

            CharacterListBox.ItemsSource = KarakterLista;
        }

        public async Task LoadKarakterekAsync()
        {
            try
            {
                var response = await sharedClient.GetAsync("KarakterClass");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var karakter = JsonConvert.DeserializeObject<List<CsapatepitoKarakterDTO>>(json);
                KarakterLista = karakter;
                CharacterListBox.ItemsSource = KarakterLista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void CharacterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharacterListBox.SelectedItems.Count > 0)
            {
                var selectedCharacters = new List<CsapatepitoKarakterDTO>();
                foreach (var item in CharacterListBox.SelectedItems)
                {
                    if (item is CsapatepitoKarakterDTO character)
                    {
                        selectedCharacters.Add(character);
                    }
                }

                SelectedCharacterItemsControl.ItemsSource = selectedCharacters;
                CharacterDetailBorder.Visibility = Visibility.Visible;
            }
            else
            {
                CharacterDetailBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void KeresesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keresettSzoveg = KeresesTextBox.Text.ToLower();

            var szurtLista = KarakterLista.FindAll(karakter =>
                !string.IsNullOrEmpty(karakter.CharacterName) &&
                karakter.CharacterName.ToLower().Contains(keresettSzoveg));

            CharacterListBox.ItemsSource = szurtLista;
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
            ErositesAblak = new Erosites();
            ErositesAblak.Show();
            this.Close();
        }

        private void CsapatTervezoBTN_Click(object sender, RoutedEventArgs e)
        {
            //Nem kell csinálni semmit, mert már ezen az ablakon vagyunk

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

