namespace CurrencyAPI.Models;

public class CurrencyDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CurrencyInfoCollectionName { get; set; } = null!;
}