using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CurrencyAPI.Models;
using RestSharp;
using CurrencyAPI.Services;

namespace CurrencyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;
    private readonly CurrencyService _currencyService;
    //private readonly IWebHostEnvironment _hostingEnvironment;

    public CurrencyController(ILogger<CurrencyController> logger, CurrencyService currencyService)//, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        // _hostingEnvironment = hostEnvironment;
        _currencyService = currencyService;
    }

    // [HttpGet(Name = "GetCurrency")]
    // public IEnumerable<Currency> Get()
    // {
    //     List<Currency> currencies = new List<Currency>();
    //     string rootPath = _hostingEnvironment.ContentRootPath;
    //     string absolutePath = Path.Combine(rootPath, "Data/Currencies.json");
    //     try
    //     {
    //         if (System.IO.File.Exists(absolutePath))
    //         {
    //             currencies = JsonConvert.DeserializeObject<List<Currency>>(System.IO.File.ReadAllText(absolutePath));
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.Log(LogLevel.Error, ex, null, Array.Empty<object>());
    //     }

    //     return currencies;
    // }

    [HttpGet]
    public async Task<List<Currency>> Get() =>
        await _currencyService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Currency>> Get(string id)
    {
        var currency = await _currencyService.GetAsync(id);

        if (currency is null)
        {
            return NotFound();
        }

        return currency;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Currency newCurrency)
    {
        await _currencyService.CreateAsync(newCurrency);

        return CreatedAtAction(nameof(Get), new { id = newCurrency.Id }, newCurrency);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Currency updatedCurrency)
    {
        var currency = await _currencyService.GetAsync(id);

        if (currency is null)
        {
            return NotFound();
        }

        updatedCurrency.Id = currency.Id;

        await _currencyService.UpdateAsync(id, updatedCurrency);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var currency = await _currencyService.GetAsync(id);

        if (currency is null)
        {
            return NotFound();
        }

        await _currencyService.RemoveAsync(id);

        return NoContent();
    }
}
