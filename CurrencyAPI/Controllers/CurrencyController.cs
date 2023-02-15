using Microsoft.AspNetCore.Mvc;
using CurrencyAPI.Models;
using CurrencyAPI.Services;

namespace CurrencyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;
    private readonly CurrencyService _currencyService;
    
    public CurrencyController(ILogger<CurrencyController> logger, CurrencyService currencyService)//, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        // _hostingEnvironment = hostEnvironment;
        _currencyService = currencyService;
    }

    [HttpGet(Name = "GetCurrency")]
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
