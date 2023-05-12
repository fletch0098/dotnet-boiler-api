// Program.cs - Program

using dotnet_boiler_api.Models;
using dotnet_boiler_api.Services;

// Create the builder
var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Register Root Service to use it with Dependency Injection in Controllers
builder.Services.AddSingleton<RootService>();

// Add services to the container.
builder.Services.AddControllers();

// Options for appSettingd
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

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
AppSettings? appSettings = config.GetSection("AppSettings").Get<AppSettings>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Dev mode

    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // Logging
    logger?.LogInformation($"{appSettings?.AppName} Development server started on: {appSettings?.Urls}");
    logger?.LogInformation($"Api Docs: {appSettings?.Urls}/swagger");

    app.UseExceptionHandler("/error-local-development");

}
// Production 
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Start the server
app.Run();
