using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CurrencyAPI.Models;

namespace CurrencyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public CurrencyController(ILogger<CurrencyController> logger,IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _hostingEnvironment = hostEnvironment;
    }

    [HttpGet(Name = "GetCurrency")]
    public IEnumerable<Currency> Get()
    {
        List<Currency> currencies= new List<Currency>();
        string rootPath = _hostingEnvironment.ContentRootPath;
        string absolutePath = Path.Combine(rootPath, "Data/Currencies.json");
        try
        {
            if (System.IO.File.Exists(absolutePath))
            {
                currencies = JsonConvert.DeserializeObject<List<Currency>>(System.IO.File.ReadAllText(absolutePath));
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, null, Array.Empty<object>());
        }
        return currencies;
    }
}
