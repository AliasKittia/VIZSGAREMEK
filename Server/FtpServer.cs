using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace tftwebapi.Services
{
    public class FtpService
    {
        private readonly string host = "ftp.nhely.hu";
        private readonly string user = "AliasKittia";
        private readonly string pass = "Miloka230803";
        
        // Távoli könyvtárak
        private const string CharactersFolder = "/Characters/";
        private const string ClassesFolder = "/Classes/";
        private const string HalfItemFolder = "/halfitem/";
        private const string FullItemFolder = "/fullitem/";

        // 📌 FELTÖLTÉS FTP-re (több könyvtár támogatással)
        public async Task<bool> UploadFileAsync(Stream fileStream, string fileName, RemoteFolderType folderType)
        {
            string remotePath = $"ftp://{host}{GetFolderPath(folderType)}{fileName}";

            try
            {
#pragma warning disable SYSLIB0014
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remotePath);
#pragma warning restore SYSLIB0014
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
                Console.WriteLine($"Hiba a feltöltés során ({folderType}): {ex.Message}");
                return false;
            }
        }

        // 📌 LETÖLTÉS FTP-ről (több könyvtár támogatással)
        public async Task<Stream?> DownloadFileAsync(string fileName, RemoteFolderType folderType)
        {
            string remotePath = $"ftp://{host}{GetFolderPath(folderType)}{fileName}";

            try
            {
                using HttpClient client = new HttpClient(new HttpClientHandler
                {
                    Credentials = new NetworkCredential(user, pass)
                });

                HttpResponseMessage response = await client.GetAsync(remotePath);
                response.EnsureSuccessStatusCode();

                MemoryStream stream = new MemoryStream();
                await response.Content.CopyToAsync(stream);
                stream.Position = 0;
                return stream;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a letöltés során ({folderType}): {ex.Message}");
                return null;
            }
        }

        // 📌 FÁJLOK LISTÁZÁSA (több könyvtár támogatással)
        public async Task<string[]> ListFilesAsync(RemoteFolderType folderType)
        {
            string remotePath = $"ftp://{host}{GetFolderPath(folderType)}";

            try
            {
#pragma warning disable SYSLIB0014
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remotePath);
#pragma warning restore SYSLIB0014
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
                Console.WriteLine($"Hiba a listázás során ({folderType}): {ex.Message}");
                return Array.Empty<string>();
            }
        }

        // 📌 FÁJL TÖRLÉSE (több könyvtár támogatással)
        public async Task<bool> DeleteFileAsync(string fileName, RemoteFolderType folderType)
        {
            string remotePath = $"ftp://{host}{GetFolderPath(folderType)}{fileName}";

            try
            {
#pragma warning disable SYSLIB0014
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remotePath);
#pragma warning restore SYSLIB0014
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(user, pass);

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    return response.StatusCode == FtpStatusCode.FileActionOK;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a törlés során ({folderType}): {ex.Message}");
                return false;
            }
        }

        // Segédfüggvény a könyvtár útvonal lekéréséhez
        private string GetFolderPath(RemoteFolderType folderType)
        {
            return folderType switch
            {
                RemoteFolderType.Characters => CharactersFolder,
                RemoteFolderType.Classes => ClassesFolder,
                RemoteFolderType.halfitem => HalfItemFolder,
                RemoteFolderType.fullitem => FullItemFolder,
                _ => CharactersFolder // alapértelmezett
            };
        }
    }

    // Könyvtártípusok enumja
    public enum RemoteFolderType
    {
        Characters,
        Classes,
        halfitem,
        fullitem
    }
}