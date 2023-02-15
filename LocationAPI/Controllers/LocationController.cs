using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using LocationAPI.Models;
using Newtonsoft.Json;

namespace LocationAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILogger<LocationController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;
    public LocationController(ILogger<LocationController> logger, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _hostingEnvironment = hostEnvironment;
    }

    [HttpGet(Name = "GetLocation")]
    public IEnumerable<Location> Get()
    {
        List<Location>? locations = new List<Location>();
        string rootPath = _hostingEnvironment.ContentRootPath;
        string absolutePath = Path.Combine(rootPath, "Data/Location.json");
        try
        {
            if (System.IO.File.Exists(absolutePath))
            {
                locations = JsonConvert.DeserializeObject<List<Location>>(System.IO.File.ReadAllText(absolutePath));
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, null, Array.Empty<object>());
        }
        locations =  locations == null ? new List<Location>() : locations;
        return locations ;
    }
}
