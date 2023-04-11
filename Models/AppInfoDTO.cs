namespace dotnet_boiler_api.Models;

public class AppInfoDTO
{
    public string? App { get; set; }

    public string? Version { get; set; }

    public string? Env { get; set; }

    public DateTime Date { get; set; }

    public string? HostUrl { get; set; }

    public AppInfoDTO(string? app, string version, string env, DateTime date, string? hostUrl)
    {
        App = app;
        Version = version;
        Env = env;
        Date = date;
        HostUrl = hostUrl;
    }
}