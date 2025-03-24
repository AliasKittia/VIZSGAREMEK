using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Services; // Update this line to include the correct namespace for FtpService
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tftwebapi.Models;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

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
            mail.From = new MailAddress("ide az email cimük");
            mail.To.Add(mailAddressTo);
            mail.Subject = subject;
            mail.Body = body;

            /*System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("");
            mail.Attachments.Add(attachment);*/

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ide az email cimük", "ide a 16 karakteres jelszó");

            SmtpServer.EnableSsl = true;

            await SmtpServer.SendMailAsync(mail);
        }

        public static string GenerateSalt()
        {
            Random random = new Random();
            string karakterek = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string salt = "";
            for (int i = 0; i < SaltLength; i++)
            {
                salt += karakterek[random.Next(karakterek.Length)];
            }
            return salt;
        }

        public static string CreateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
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

            // Register FtpService
            builder.Services.AddScoped<FtpService>(); // Add this line to register FtpService

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
