using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Karbantarto.Windows
{
    public partial class AnomaliaSzerkesztoAblak : Window
    {
        private AnomaliaLekeresDTO anomalia;

        public AnomaliaSzerkesztoAblak(AnomaliaLekeresDTO anomalia)
        {
            InitializeComponent();
            this.anomalia = anomalia;
            NevTBX.Text = anomalia.AnomalyName;
            HatasTBX.Text = anomalia.AnomalyEffect;
        }

        private async void Mentes_Click(object sender, RoutedEventArgs e)
        {
            // Frissítjük a DTO-t a mezők alapján
            anomalia.AnomalyName = NevTBX.Text;
            anomalia.AnomalyEffect = HatasTBX.Text;

            try
            {
                var json = JsonConvert.SerializeObject(anomalia);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5166/api/Anomalies/");
                    var response = await client.PutAsync(anomalia.AnomalyId.ToString(), content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sikeres mentés!", "Mentve", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hiba történt mentés közben: " + response.StatusCode, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message, "Kivétel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
