using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Karbantarto.Classes;

namespace Karbantarto.Services
{
    internal class LoginService
    {
        public static async Task<string> GetSaltAsync(HttpClient httpClient, string loginName)
        {
            try
            {
                string uri = $"{httpClient.BaseAddress}api/Login/SaltRequest/{loginName}";
                var response = await httpClient.GetAsync(uri); // GET kérés lett

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception("Felhasználó nem található");
                }
                else
                {
                    throw new Exception($"Hiba a só lekérésekor: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Hálózati hiba: {ex.Message}");
            }
        }

        public static async Task<string> LoginAsync(HttpClient httpClient, string loginName, string password, string salt)
        {
            try
            {
                string url = $"{httpClient.BaseAddress}api/Login/Login"; // Új endpoint

                // Hash generálása
                string hash = GenerateSHA256Hash(password + salt);

                LoginDTO loginUser = new LoginDTO
                {
                    LoginName = loginName,
                    Password = hash // Most már a hash-t küldjük
                };

                string json = JsonSerializer.Serialize(loginUser);
                var request = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, request);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new Exception("Hibás név vagy jelszó / inaktív felhasználó!");
                    }
                    throw new Exception($"HTTP hiba: {response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Bejelentkezési hiba: {ex.Message}");
            }
        }

        private static string GenerateSHA256Hash(string input)
        {
            using (SHA512 sha256Hash = SHA512.Create())
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
    }

}
