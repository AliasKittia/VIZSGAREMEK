using Karbantarto.Classes;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Karbantarto.Windows
{
    public partial class Login : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string loginNev = "";
        private string jelszo = "";

        Menu MenuAblak;
        Register RegiszterAblak;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginNev_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            loginNev = LoginNev.Text;
        }

        private void Jelszo_PasswordChanged(object sender, RoutedEventArgs e)
        {
            jelszo = Jelszo.Password;
        }

        private async void Bejelentkezes_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginNev) || string.IsNullOrWhiteSpace(jelszo))
            {
                MessageBox.Show("Kérlek töltsd ki a felhasználónevet és jelszót.");
                return;
            }

            try
            {
                // 1. Só lekérése
                string saltUrl = $"http://localhost:5166/api/Login/SaltRequest/{loginNev}";
                var saltResponse = await _httpClient.GetAsync(saltUrl);

                if (!saltResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Hibás felhasználónév vagy nem található.");
                    return;
                }

                string salt = await saltResponse.Content.ReadAsStringAsync();

                // 2. Hash létrehozása jelszó + só alapján
                string combined = jelszo + salt;
                string hash = CreateSHA256(combined);

                // 3. Login DTO elküldése
                var loginDto = new LoginDTO
                {
                    LoginName = loginNev,
                    Password = jelszo // Backend újrahasheli
                };

                var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
                var loginResponse = await _httpClient.PostAsync("http://localhost:5166/api/Login/Login", content);

                if (!loginResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikertelen bejelentkezés.");
                    return;
                }

                string result = await loginResponse.Content.ReadAsStringAsync();
                var loggedUser = JsonConvert.DeserializeObject<LoggedUser>(result);

                MessageBox.Show($"Sikeres bejelentkezés! Üdv, {loggedUser.Name}");

                // 👉 Menu ablak megnyitása
                Menu MenuAblak = new Menu();  // vagy: new Menu(loggedUser) ha át akarod adni az adatokat
                MenuAblak.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }


        private void RegistryBTN_Click(object sender, RoutedEventArgs e)
        {
            Register regiszterAblak = new Register();
            regiszterAblak.Show();
        }

        private void GyorsBTN_Click(object sender, RoutedEventArgs e)
        {
            // Teszt belépés adatok nélkül
            MessageBox.Show("Gyors belépés (fejlesztési célra)");
        }

        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private string CreateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
