using Microsoft.AspNetCore.Mvc;
using CurrencyAPI.Models;

namespace CurrencyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<CurrencyController> _logger;

    public CurrencyController(ILogger<CurrencyController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCurrency")]
    public IEnumerable<Currency> Get()
    {
        return new List<Currency>();
    }
}
