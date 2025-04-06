using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Karbantarto.Windows
{
    public partial class FelTargyModositasWindow : Window
    {
        private FelTargyLekeresDTO aktualisFelTargy;

        public FelTargyModositasWindow(FelTargyLekeresDTO felTargy)
        {
            InitializeComponent();
            aktualisFelTargy = new FelTargyLekeresDTO
            {
                PartialItemId = felTargy.PartialItemId,
                Name = felTargy.Name,
                Effect = felTargy.Effect,
                HalfItemimageblob = felTargy.HalfItemimageblob
            };
            DataContext = aktualisFelTargy;
        }

        private async void MentesBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var json = JsonConvert.SerializeObject(aktualisFelTargy);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await Targyak.sharedsClient.PutAsync($"Partialitems/{aktualisFelTargy.PartialItemId}", content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Sikeres mentés!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt mentés közben: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
