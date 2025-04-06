using Karbantarto.Classes.ProjectName_Backend.DTOs;
using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Karbantarto.Windows
{
    public partial class OsztalySzerkesztoAblak : Window
    {
        private OsztalyDTO osztaly;

        public OsztalySzerkesztoAblak(OsztalyDTO szerkesztendoOsztaly)
        {
            InitializeComponent();
            osztaly = new OsztalyDTO
            {
                ClassID = szerkesztendoOsztaly.ClassID,
                ClassName = szerkesztendoOsztaly.ClassName,
                BasicEffect = szerkesztendoOsztaly.BasicEffect,
                Classimageblob = szerkesztendoOsztaly.Classimageblob,
                Szintek = new List<SzintDTO>(szerkesztendoOsztaly.Szintek),
                Karakterek = new List<KarakterDTO>(szerkesztendoOsztaly.Karakterek)
            };

            // Mezők betöltése
            ClassNameTBX.Text = osztaly.ClassName;
            BasicEffectTBX.Text = osztaly.BasicEffect;

            SzintGrid.ItemsSource = osztaly.Szintek;
            KarakterGrid.ItemsSource = osztaly.Karakterek;
        }

        private async void Mentes_Click(object sender, RoutedEventArgs e)
        {
            // Frissítjük a mezők értékét
            osztaly.ClassName = ClassNameTBX.Text;
            osztaly.BasicEffect = BasicEffectTBX.Text;

            try
            {
                string json = JsonConvert.SerializeObject(osztaly);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5166/api/OsztalySzintEsKarakter/");
                    var response = await client.PutAsync(osztaly.ClassID.ToString(), content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sikeresen mentve!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hiba a mentés során: " + response.StatusCode, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message, "Kivétel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
