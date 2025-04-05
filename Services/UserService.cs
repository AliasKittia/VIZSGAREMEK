using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Karbantarto.Models;

namespace Karbantarto.Services
{
    internal static class UserService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = false
        };

        public static async Task<List<User>?> GetAll(HttpClient httpClient)
        {
            try
            {
                // Helyes API végpont URL
                return await httpClient.GetFromJsonAsync<List<User>>(
                    $"User/{Menu.loggedUser.Token}",  // Eltávolítva a szóköz
                    _jsonOptions);
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Network error: {httpEx.Message}");
                return null;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON parsing error: {jsonEx.Message}");
                return null;
            }
        }

        public static async Task<string> Post(HttpClient httpClient, User user)
        {
            try
            {
                // Helyes API végpont URL
                var response = await httpClient.PostAsJsonAsync(
                    $"User/{Menu.loggedUser.Token}",  // Eltávolítva a szóköz
                    user,
                    _jsonOptions);

                return await HandleResponse(response);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public static async Task<string> Put(HttpClient httpClient, User user)
        {
            try
            {
                // Helyes API végpont URL
                var response = await httpClient.PutAsJsonAsync(
                    $"User/{Menu.loggedUser.Token}",  // Eltávolítva a szóköz
                    user,
                    _jsonOptions);

                return await HandleResponse(response);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public static async Task<string> Delete(HttpClient httpClient, int id)
        {
            try
            {
                // Helyes API végpont URL
                var response = await httpClient.DeleteAsync(
                    $"User/{Menu.loggedUser.Token}/{id}");  // Helyes URL

                return await HandleResponse(response);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static async Task<string> HandleResponse(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode
                ? content
                : $"Error: {response.StatusCode}\n{content}";
        }
    }
}
