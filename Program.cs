using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Services; // Ensure this namespace contains FtpService
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tftwebapi.Models;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;

namespace tftwebapi
{
    public class Program
    {
        public static string ftpUrl = "";
        public static string ftpUserName = "";
        public static string ftpPassword = "";

        public static int SaltLength = 64;

        public static Dictionary<string, PostUser> LoggedInUsers = new Dictionary<string, PostUser>();

        public static async Task SendEmail(string mailAddressTo, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("ide az email címed");
            mail.To.Add(mailAddressTo);
            mail.Subject = subject;
            mail.Body = body;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ide az email címed", "ide a 16 karakteres jelszó");
            SmtpServer.EnableSsl = true;

            await SmtpServer.SendMailAsync(mail);
        }

        public static string GenerateSalt()
        {
            Random random = new Random();
            const string karakterek = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder salt = new StringBuilder();
            for (int i = 0; i < SaltLength; i++)
            {
                salt.Append(karakterek[random.Next(karakterek.Length)]);
            }
            return salt.ToString();
        }

        public static string CreateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                foreach (byte b in data)
                {
                    sBuilder.Append(b.ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register HttpClient for FtpService
            builder.Services.AddHttpClient<FtpService>(); // Módosítva, hogy az FtpService helyesen kapjon HttpClient-et

            // Configure DbContext with dependency injection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
                new MySqlServerVersion(new Version(8, 0, 21))));

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Enable Swagger UI for development environment
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable serving static files (e.g., images)
            app.UseStaticFiles();

            // Apply the CORS policy globally
            app.UseCors("ReactPolicy");

            app.UseHttpsRedirection();
            app.MapControllers(); // Map controller routes

            app.Run();
        }
    }
}
