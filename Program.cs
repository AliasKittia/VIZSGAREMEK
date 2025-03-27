using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tftwebapi.Models;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;
using MySql.EntityFrameworkCore.Extensions;

namespace tftwebapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register HttpClient for FtpService
            builder.Services.AddHttpClient<FtpService>();

            // Get connection string with null check
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // Configure DbContext with dependency injection for MySQL
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(connectionString));

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
            app.MapControllers();

            app.Run();
        }
    }
}