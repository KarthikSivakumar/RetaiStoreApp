using Microsoft.AspNetCore.Mvc;
using CountryAPI.Models;

namespace CountryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{
    private readonly ILogger<CountryController> _logger;

    public CountryController(ILogger<CountryController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCountry")]
    public IEnumerable<CountryRegion> Get()
    {
        return new List<CountryRegion>();
    }
}
