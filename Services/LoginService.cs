using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Karbantarto.Services
{
    public static class LoginService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        public static async Task<string> GetSaltAsync(HttpClient httpClient, string loginName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginName))
                {
                    throw new ArgumentException("Login name cannot be empty", nameof(loginName));
                }

                string uri = $"api/Login/SaltRequest/{Uri.EscapeDataString(loginName)}";
                Debug.WriteLine($"[LoginService] Requesting salt for user: {loginName}");

                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var salt = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[LoginService] Received salt: {salt}");
                    return salt;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[LoginService] Salt request failed: {response.StatusCode} - {errorContent}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("User not found");
                }

                throw new Exception($"Salt request failed: {errorContent}");
            }
            catch (HttpRequestException httpEx) when (httpEx.StatusCode == null)
            {
                Debug.WriteLine($"[LoginService] Network error: {httpEx.Message}");
                throw new Exception("Network error. Please check your connection.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[LoginService] General error: {ex.Message}");
                throw;
            }
        }

        public static async Task<LoggedUser> LoginAsync(HttpClient httpClient, string loginName, string password)
        {
            if (string.IsNullOrWhiteSpace(loginName))
                throw new ArgumentException("Login name cannot be empty", nameof(loginName));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty", nameof(password));

            try
            {
                Debug.WriteLine($"[LoginService] Starting login process for: {loginName}");
                string salt = await GetSaltAsync(httpClient, loginName);

                if (string.IsNullOrEmpty(salt))
                {
                    throw new Exception("Invalid salt received from server");
                }

                // Töröltük a hash-elést itt, hogy a backend végezze el!
                var loginDto = new LoginDTO
                {
                    LoginName = loginName,
                    Password = password // Csak a sima jelszó, nem hash-elve
                };

                string json = JsonSerializer.Serialize(loginDto, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Debug.WriteLine($"[LoginService] Sending login request...");
                var response = await httpClient.PostAsync("api/Login/Login", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"[LoginService] Login failed: {response.StatusCode} - {errorContent}");

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new Exception("Invalid username or password");
                    }

                    throw new Exception($"Login failed: {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[LoginService] Login successful. Response: {responseContent}");

                var loggedUser = JsonSerializer.Deserialize<LoggedUser>(responseContent, _jsonOptions);
                return loggedUser ?? throw new Exception("Invalid server response");
            }
            catch (HttpRequestException httpEx) when (httpEx.StatusCode == null)
            {
                Debug.WriteLine($"[LoginService] Network error during login: {httpEx.Message}");
                throw new Exception("Network error during login. Please try again.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[LoginService] Login error: {ex.Message}");
                throw new Exception($"Login failed: {ex.Message}");
            }
        }

        private static string ComputeSha256Hash(string rawData)
        {
            if (string.IsNullOrEmpty(rawData))
                throw new ArgumentException("Input data cannot be empty", nameof(rawData));

            try
            {
                using SHA256 sha256 = SHA256.Create();
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                var builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[LoginService] Hash computation failed: {ex.Message}");
                throw new Exception("Password hashing failed", ex);
            }
        }
    }

    public class LoginDTO
    {
        public string LoginName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoggedUser
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Permission { get; set; }
        public string ProfilePicturePath { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
