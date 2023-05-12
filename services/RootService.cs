using dotnet_boiler_api.Models;
using Microsoft.Extensions.Options;

namespace dotnet_boiler_api.Services;

public class RootService
{
    private readonly ILogger<RootService> _logger;
    private readonly AppSettings _appSettings;

    public RootService(ILogger<RootService> logger, IOptions<AppSettings> appSettings)
    {
        _logger = logger;
        _appSettings = appSettings.Value;
    }

    public string GetHealth()
    {
        // logger
        _logger.LogInformation("Health Check at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        // Return 'OK' text
        return "OK";
    }

    public AppInfoDTO GetApp()
    {

        // logger
        _logger.LogInformation("App at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        // Get appSettings values
        string? appName = _appSettings.AppName;
        string? urls = _appSettings.Urls;
        string version = "1.0.0";
        string env = "Development";

        AppInfoDTO appInfo = new AppInfoDTO(appName, version, env, DateTime.Now, urls);

        // Return AppInfo
        return appInfo;
    }
}