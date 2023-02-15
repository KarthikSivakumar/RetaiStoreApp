using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreAPI.Models;

namespace StoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly ILogger<StoreController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;
    public StoreController(ILogger<StoreController> logger, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _hostingEnvironment = hostEnvironment;
    }

    [HttpGet(Name = "GetStores")]
    public IEnumerable<Store> Get()
    {
         List<Store>? stores = new List<Store>();
        string rootPath = _hostingEnvironment.ContentRootPath;
        string absolutePath = Path.Combine(rootPath, "Data/Stores.json");
        try
        {
            if (System.IO.File.Exists(absolutePath))
            {
                stores = JsonConvert.DeserializeObject<List<Store>>(System.IO.File.ReadAllText(absolutePath));
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex, null, Array.Empty<object>());
        }
        stores =  stores == null ? new List<Store>() : stores;
        return stores ;
    }
}
