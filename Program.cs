using Microsoft.EntityFrameworkCore;
using tftwebapi.Data;
using tftwebapi.Services; // Update this line to include the correct namespace for FtpService
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
