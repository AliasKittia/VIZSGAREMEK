using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace tftwebapi.Services
{
    public class FtpService
    {
        private readonly string host = "ftp.nhely.hu";
        private readonly string user = "AliasKittia";
        private readonly string pass = "Miloka230803";
        private readonly string ftpFolder = "/Characters/"; // Távoli könyvtár

        // 📌 FELTÖLTÉS FTP-re
        public async Task<bool> UploadFileAsync(Stream fileStream, string fileName)
        {
            string remotePath = $"ftp://{host}{ftpFolder}{fileName}";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remotePath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UseBinary = true;

                using (Stream requestStream = await request.GetRequestStreamAsync())
                {
                    await fileStream.CopyToAsync(requestStream);
                }

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    return response.StatusCode == FtpStatusCode.ClosingData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a feltöltés során: {ex.Message}");
                return false;
            }
        }

        // 📌 LETÖLTÉS FTP-ről
        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            string remotePath = $"ftp://{host}{ftpFolder}{fileName}";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remotePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UseBinary = true;
                

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    MemoryStream stream = new MemoryStream();
                    await response.GetResponseStream().CopyToAsync(stream);
                    stream.Position = 0; // Reset stream position
                    return stream;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a letöltés során: {ex.Message}");
                return null;
            }
        }

        // 📌 FÁJLOK LISTÁZÁSA
        public async Task<string[]> ListFilesAsync()
        {
            string remotePath = $"ftp://{host}{ftpFolder}";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remotePath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(user, pass);

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string content = await reader.ReadToEndAsync();
                    return content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a listázás során: {ex.Message}");
                return new string[0];
            }
        }

        // 📌 FÁJL TÖRLÉSE
        public async Task<bool> DeleteFileAsync(string fileName)
        {
            string remotePath = $"ftp://{host}{ftpFolder}{fileName}";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remotePath);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(user, pass);

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    return response.StatusCode == FtpStatusCode.FileActionOK;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a törlés során: {ex.Message}");
                return false;
            }
        }
    }
}