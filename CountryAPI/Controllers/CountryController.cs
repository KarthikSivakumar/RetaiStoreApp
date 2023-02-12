using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using CountryAPI.Models;
using Newtonsoft.Json;

namespace CountryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{
    private readonly ILogger<CountryController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;
    public CountryController(ILogger<CountryController> logger, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _hostingEnvironment = hostEnvironment;
    }

    [HttpGet(Name = "GetCountry")]
    public IEnumerable<CountryRegion> Get()
    {
        List<CountryRegion> countryRegion = new List<CountryRegion>();
        string rootPath = _hostingEnvironment.ContentRootPath;
        string absolutePath = Path.Combine(rootPath, "Data/CountryRegion.json");
        try
        {
            if (System.IO.File.Exists(absolutePath))
            {
                countryRegion = JsonConvert.DeserializeObject<List<CountryRegion>>(System.IO.File.ReadAllText(absolutePath));
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, null, Array.Empty<object>());
        }
        return countryRegion;
    }
}
