// Program.cs - Program

using System.Net;
using System.Net.Sockets;

// Create the builder
var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// The app
var app = builder.Build();

// Get the logger
var logger = app.Services.GetService<ILogger<Program>>();

// Get config 
var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

// Parse Configs
var AppName = config.GetValue<string>("AppName");
var Urls = config.GetValue<string>("Urls");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // Logging
    logger?.LogInformation($"{AppName} Development server started on: {Urls}");
    logger?.LogInformation($"Api Docs: {Urls}/swagger");

    app.UseExceptionHandler("/error-local-development");

} else {
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Start the server
app.Run();

// public static string GetAddressIP()
//     {
//         return Dns.GetHostAddresses(Dns.GetHostName())
//             .FirstOrDefault(ha => ha.AddressFamily == AddressFamily.InterNetwork)
//             .ToString();
//     }
