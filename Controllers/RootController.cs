using Microsoft.AspNetCore.Mvc;
using dotnet_boiler_api.Models;
using dotnet_boiler_api.Services;
using Microsoft.Extensions.Options;

namespace dotnet_boiler_api.Controllers;

[ApiController]
[Route("/")]
public class RootController : ControllerBase
{
    private readonly ILogger<RootController> _logger;
    private readonly RootService _rootService;

    public RootController(ILogger<RootController> logger, IOptions<AppSettings> appSettings, RootService rootService)
    {
        _logger = logger;
        _rootService = rootService;
    }

    [HttpGet]
    [Route("health")]
    public String GetHealth()
    {

        // logger
        _logger.LogInformation("Health Check at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        // Return 'OK' text
        return _rootService.GetHealth();
    }

    [HttpGet]
    [Route("")]
    public AppInfoDTO GetApp()
    {

        // logger
        _logger.LogInformation("App at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        // Return AppInfo
        return _rootService.GetApp();
    }

        [HttpGet]
    [Route("debug")]
    public AppInfoDTO Debug()
    {

        // logger
        _logger.LogInformation("Debug at {DT}",
            DateTime.UtcNow.ToLongTimeString());

             throw new Exception("Sample exception.");
             
        // Return AppInfo
        return _rootService.GetApp();
    }

}
