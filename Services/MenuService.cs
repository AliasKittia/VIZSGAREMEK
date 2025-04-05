using System;
using Karbantarto.Services;

namespace Karbantarto.Services
{
    public static class MenuService
    {
        // A bejelentkezett felhasználót és a bejelentkezett állapotot kezeljük itt
        public static Karbantarto.Classes.LoggedUser loggedUser { get; private set; }
        public static bool bejelentkezve { get; private set; }

        public static void SetLoggedUser(Karbantarto.Classes.LoggedUser user)
        {
            loggedUser = user;
            bejelentkezve = true;
        }

        public static void LogOut()
        {
            loggedUser = null;
            bejelentkezve = false;
        }

        // A bejelentkezéshez szükséges logika
        public static async Task<Karbantarto.Classes.LoggedUser> LoginAsync(string username, string hashedPassword)
        {
            var serviceUser = await LoginService.LoginAsync(Menu.sharedClient, username, hashedPassword);

            if (serviceUser != null && !string.IsNullOrEmpty(serviceUser.Token))
            {
                return ConvertToClassesLoggedUser(serviceUser);
            }
            else
            {
                return null;
            }
        }

        // Konvertálás a két típus között
        private static Karbantarto.Classes.LoggedUser ConvertToClassesLoggedUser(Karbantarto.Services.LoggedUser serviceUser)
        {
            return new Karbantarto.Classes.LoggedUser
            {
                Name = serviceUser.Name,
                Email = serviceUser.Email,
                Permission = serviceUser.Permission,
                ProfilePicturePath = serviceUser.ProfilePicturePath,
                Token = serviceUser.Token
            };
        }
    }
}
