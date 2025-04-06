using System.Windows;
using Karbantarto.Windows;

namespace Karbantarto
{
    public partial class App : Application
    {
        private async void Login(object sender, StartupEventArgs e)
        {
            // Alkalmazás indításakor megjelenítjük a bejelentkező ablakot
            var loginWindow = new Login();
            Current.MainWindow = loginWindow;
            loginWindow.Show(); // ShowDialog helyett Show() a bejelentkezés után

            // Várakozás a bejelentkezés eredményére
            loginWindow.Closed += async (s, args) =>
            {
                // Ha sikeres volt a bejelentkezés
                if (Menu.bejelentkezve && Menu.loggedUser != null)
                {
                    var mainMenu = new Menu();

                    // Főmenü címsorának beállítása
                    mainMenu.fomenu.Title = $"Karbantartó rendszer\t\tBejelentkezve: {Menu.loggedUser.Name}";

                    // Főmenü megjelenítése
                    Current.MainWindow = mainMenu;
                    mainMenu.Show();
                }
                else
                {
                    // Ha nem sikerült a bejelentkezés, az alkalmazás bezárul
                    Current.Shutdown();
                }
            };
        }
    }
}