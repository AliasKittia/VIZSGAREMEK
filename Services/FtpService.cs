using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace tftwebapi.Services
{
    public class FtpService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string host = "ftp.nhely.hu";
        private readonly string user = "AliasKittia";
        private readonly string pass = "Miloka230803";
        private readonly string ftpFolder = "/Characters/"; 
        

        public FtpService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        // 📌 FELTÖLTÉS FTP-re
        public async Task<string> UploadFileAsync(string ftpUrl, string filePath, string username, string password)
        {
            var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
            var request = new HttpRequestMessage(HttpMethod.Put, ftpUrl)
            {
                Content = fileContent
            };
            var byteArray = new UTF8Encoding().GetBytes($"{username}:{password}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // 📌 LETÖLTÉS FTP-ről
        public async Task<string> DownloadFileAsync(string ftpUrl, string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ftpUrl);
            var byteArray = new UTF8Encoding().GetBytes($"{username}:{password}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // 📌 FÁJLOK LISTÁZÁSA
        public async Task<string[]> ListFilesAsync()
        {
            string remotePath = $"ftp://{host}{ftpFolder}";

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, remotePath);
                var byteArray = new UTF8Encoding().GetBytes($"{user}:{pass}");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a listázás során: {ex.Message}");
                return new string[0];
            }
        }

        // 📌 FÁJL TÖRLÉSE
        public async Task DeleteFileAsync(string ftpUrl, string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, ftpUrl);
            var byteArray = new UTF8Encoding().GetBytes($"{username}:{password}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}