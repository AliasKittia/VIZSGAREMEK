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
            loginWindow.ShowDialog();

            // Ha sikeres volt a bejelentkezés
            if (Menu.bejelentkezve && Menu.loggedUser != null)
            {
                var mainMenu = new Menu();

                // Menüelemek beállítása a jogosultságtól függően
                // Megjegyzés: Ha nem kell külön kezelni, ezek a sorok törölhetők
                /*
                if (Menu.loggedUser.Permission == 9) // Admin jogosultság
                {
                    mainMenu.mnu_dat_Felh.IsEnabled = true;
                    mainMenu.mnu_dat_Felh.Visibility = Visibility.Visible;
                }
                else
                {
                    mainMenu.mnu_dat_Felh.IsEnabled = false;
                    mainMenu.mnu_dat_Felh.Visibility = Visibility.Collapsed;
                }
                */

                // Főmenü címsorának beállítása
                mainMenu.fomenu.Title = $"Karbantartó rendszer\t\tBejelentkezve: {Menu.loggedUser.name}";

                Current.MainWindow = mainMenu;
                mainMenu.Show();
            }
            else
            {
                // Ha nem sikerült a bejelentkezés, az alkalmazás bezárul
                Current.Shutdown();
            }
        }
    }
}