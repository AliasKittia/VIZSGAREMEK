using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Karbantarto.Windows
{
    public partial class Register : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public Register()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string loginName = UsernameBox.Text.Trim();
            string fullName = FullNameBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string password = PasswordBox.Password;

            // Egyszerű validálás
            if (string.IsNullOrWhiteSpace(loginName) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Kérlek, tölts ki minden mezőt!", "Hiányzó adatok", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // DTO objektum
            var newUser = new
            {
                LoginName = loginName,
                Password = password,
                Name = fullName,
                Email = email
            };

            try
            {
                string json = JsonSerializer.Serialize(newUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // API hívás
                HttpResponseMessage response = await client.PostAsync("http://localhost:5166/api/Registry/Register", content); // ← módosítsd a portot ha nem ez

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres regisztráció!", "Kész", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close(); // vagy: Navigate vissza login-hoz
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Hiba: {error}", "Sikertelen regisztráció", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hálózati hiba történt: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
