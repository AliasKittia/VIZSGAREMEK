using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Karbantarto.Windows
{
    public partial class KarakterSzerkesztoAblak : Window
    {
        private KarakterLekeresDTO karakter;

        public KarakterSzerkesztoAblak(KarakterLekeresDTO karakter)
        {
            InitializeComponent();
            this.karakter = karakter;
            KitoltMezoket();
        }

        private void KitoltMezoket()
        {
            CharacterNameTBX.Text = karakter.CharacterName;
            ImageTBX.Text = karakter.Characterimageblob;
            AbilityNameTBX.Text = karakter.AbilityName;
            AbilityTBX.Text = karakter.Ability;
            CostTBX.Text = karakter.Cost?.ToString();

            HealthTBX.Text = karakter.Health?.ToString();
            Health1TBX.Text = karakter.Health1?.ToString();
            Health2TBX.Text = karakter.Health2?.ToString();

            DamageTBX.Text = karakter.Damage?.ToString();
            Damage1TBX.Text = karakter.Damage1?.ToString();
            Damage2TBX.Text = karakter.Damage2?.ToString();

            AttackSpeedTBX.Text = karakter.AttackSpeed?.ToString();
            AbilityPowerTBX.Text = karakter.AbilityPower?.ToString();

            ManaStartTBX.Text = karakter.ManaStart?.ToString();
            ManaMaxTBX.Text = karakter.ManaMax?.ToString();

            ArmorTBX.Text = karakter.Armor?.ToString();
            MagicResistTBX.Text = karakter.MagicResist?.ToString();
            RangeTBX.Text = karakter.Range?.ToString();
        }

        private async void Mentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                karakter.CharacterName = CharacterNameTBX.Text;
                karakter.Characterimageblob = ImageTBX.Text;
                karakter.AbilityName = AbilityNameTBX.Text;
                karakter.Ability = AbilityTBX.Text;
                karakter.Cost = TryParseNullableInt(CostTBX.Text);

                karakter.Health = TryParseNullableInt(HealthTBX.Text);
                karakter.Health1 = TryParseNullableInt(Health1TBX.Text);
                karakter.Health2 = TryParseNullableInt(Health2TBX.Text);

                karakter.Damage = TryParseNullableInt(DamageTBX.Text);
                karakter.Damage1 = TryParseNullableInt(Damage1TBX.Text);
                karakter.Damage2 = TryParseNullableInt(Damage2TBX.Text);

                karakter.AttackSpeed = TryParseNullableDouble(AttackSpeedTBX.Text);
                karakter.AbilityPower = TryParseNullableInt(AbilityPowerTBX.Text);

                karakter.ManaStart = TryParseNullableInt(ManaStartTBX.Text);
                karakter.ManaMax = TryParseNullableInt(ManaMaxTBX.Text);

                karakter.Armor = TryParseNullableInt(ArmorTBX.Text);
                karakter.MagicResist = TryParseNullableInt(MagicResistTBX.Text);
                karakter.Range = TryParseNullableInt(RangeTBX.Text);

                var json = JsonConvert.SerializeObject(karakter);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5166/api/Character/");
                var response = await client.PutAsync(karakter.CharacterId.ToString(), content);

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
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message, "Kivétel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int? TryParseNullableInt(string input)
        {
            return int.TryParse(input, out var value) ? value : (int?)null;
        }

        private double? TryParseNullableDouble(string input)
        {
            return double.TryParse(input, out var value) ? value : (double?)null;
        }
    }
}
