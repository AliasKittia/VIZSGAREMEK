using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Karbantarto.Windows
{
    public partial class TeljesTargyModositasWindow : Window
    {
        private TeljesTargyLekeresDTO aktualisTeljesTargy;

        public TeljesTargyModositasWindow(TeljesTargyLekeresDTO teljesTargy)
        {
            InitializeComponent();
            aktualisTeljesTargy = new TeljesTargyLekeresDTO
            {
                Id = teljesTargy.Id,
                Name = teljesTargy.Name,
                Halfitemeffect1 = teljesTargy.Halfitemeffect1,
                Halfitemeffect2 = teljesTargy.Halfitemeffect2,
                Bonuseffect = teljesTargy.Bonuseffect,
                Bonuseffect1 = teljesTargy.Bonuseffect1,
                Bonuseffect2 = teljesTargy.Bonuseffect2,
                ActiveEffect = teljesTargy.ActiveEffect,
                Fullitemimageblob = teljesTargy.Fullitemimageblob
            };
            DataContext = aktualisTeljesTargy;
        }

        private async void MentesBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var json = JsonConvert.SerializeObject(aktualisTeljesTargy);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await Targyak.sharedClient.PutAsync($"Fullitems/{aktualisTeljesTargy.Id}", content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Sikeresen módosítva!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
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
