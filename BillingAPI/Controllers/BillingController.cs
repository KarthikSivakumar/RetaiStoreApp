using Microsoft.AspNetCore.Mvc;
using BillingAPI.Models;

namespace BillingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillingController : ControllerBase
{
    private readonly ILogger<BillingController> _logger;

    public BillingController(ILogger<BillingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBillDetails")]
    public IEnumerable<BillDetails> Get()
    {
       return new List<BillDetails>();
    }
}
