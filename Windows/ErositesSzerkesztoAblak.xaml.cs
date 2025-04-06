using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Karbantarto.Windows
{
    public partial class ErositesSzerkesztoAblak : Window
    {
        private ErositesLekeresDTO erosites;

        public ErositesSzerkesztoAblak(ErositesLekeresDTO erosites)
        {
            InitializeComponent();
            this.erosites = erosites;

            // Mezők feltöltése
            NevTBX.Text = erosites.AugmentName;
            HatasTBX.Text = erosites.AugmentEffect;

            // ComboBox kiválasztás beállítása
            foreach (ComboBoxItem item in RitkasagCBX.Items)
            {
                if ((string)item.Content == erosites.AugmentRarity)
                {
                    RitkasagCBX.SelectedItem = item;
                    break;
                }
            }
        }

        private async void Mentes_Click(object sender, RoutedEventArgs e)
        {
            erosites.AugmentName = NevTBX.Text;
            erosites.AugmentEffect = HatasTBX.Text;
            erosites.AugmentRarity = (RitkasagCBX.SelectedItem as ComboBoxItem)?.Content.ToString();

            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5166/");

                string json = JsonConvert.SerializeObject(erosites);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/Augment/{erosites.AugmentId}", content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Sikeres mentés!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt mentés közben: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
