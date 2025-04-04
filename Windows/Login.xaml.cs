using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Karbantarto.Services;
using Karbantarto.Classes;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Karbantarto.Windows
{
    public partial class Login : Window
    {
        private Registry RegistracioAblak;
        private Menu MenuAblak;
        private int probalkozasokSzama = 0;

        public Login()
        {
            InitializeComponent();
        }

        void CloseWindow(object sender, CancelEventArgs e)
        {
            if (!Menu.bejelentkezve)
            {
                Application.Current.Shutdown();
            }
        }

        private async void Bejelentkezes_Click(object sender, RoutedEventArgs e)
        {
            probalkozasokSzama++;
            Bejelentkezes.IsEnabled = false; // Gomb letiltása többszori kattintás ellen
            Mouse.OverrideCursor = Cursors.Wait; // Várakozási kurzor

            try
            {
                // 1. Só lekérése
                string salt = await LoginService.GetSaltAsync(Karbantarto.Menu.sharedClient, LoginNev.Text);

                // 2. Hash generálása a jelszóból és a sóból
                string hash = GenerateSHA256Hash(Jelszo.Password + salt);

                // 3. Bejelentkezési kérés
                string response = await LoginService.LoginAsync(Karbantarto.Menu.sharedClient, LoginNev.Text, Jelszo.Password, salt);

                // 4. Válasz feldolgozása
                Menu.loggedUser = JsonSerializer.Deserialize<LoggedUser>(response);

                if (Menu.loggedUser != null && !string.IsNullOrEmpty(Menu.loggedUser.token))
                {
                    Menu.bejelentkezve = true;
                    this.Close();
                    MessageBox.Show($"Bejelentkezve: {Menu.loggedUser.name}", "Sikeres bejelentkezés", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bejelentkezési hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Bejelentkezes.IsEnabled = true;
                Mouse.OverrideCursor = null;
            }

            // Sikertelen bejelentkezés kezelése
            if (probalkozasokSzama >= 3)
            {
                MessageBox.Show("Túl sok sikertelen próbálkozás!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show("Hibás név vagy jelszó!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private static string GenerateSHA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void RegistryBTN_Click(object sender, RoutedEventArgs e)
        {
            RegistracioAblak = new Registry();
            RegistracioAblak.Show();
        }

        private void GyorsBTN_Click(object sender, RoutedEventArgs e)
        {
            MenuAblak = new Menu();
            MenuAblak.Show();
        }

        // UI eseménykezelők maradnak változatlanok
        private void LoginNev_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoginNev.Background == null)
            {
                LoginNev.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"Images\fn.jpg", UriKind.Relative)),
                    AlignmentX = AlignmentX.Left,
                    AlignmentY = AlignmentY.Center,
                    Stretch = Stretch.None
                };
            }
        }

        private void Jelszo_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Jelszo.Password == "")
            {
                Jelszo.Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"Images\pw.jpg", UriKind.Relative)),
                    AlignmentX = AlignmentX.Left,
                    AlignmentY = AlignmentY.Center,
                    Stretch = Stretch.None
                };
            }
        }
    }
}