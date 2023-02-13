using CurrencyAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CurrencyAPI.Services;

public class CurrencyService
{
    private readonly IMongoCollection<Currency> _currenciesCollection;

    public CurrencyService(
        IOptions<CurrencyDatabaseSettings> currencyDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            currencyDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            currencyDatabaseSettings.Value.DatabaseName);

        _currenciesCollection = mongoDatabase.GetCollection<Currency>(
            currencyDatabaseSettings.Value.CurrencyInfoCollectionName);
    }

    public async Task<List<Currency>> GetAsync() =>
        await _currenciesCollection.Find(_ => true).ToListAsync();

    public async Task<Currency?> GetAsync(string id) =>
        await _currenciesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Currency newCurrency) =>
        await _currenciesCollection.InsertOneAsync(newCurrency);

    public async Task UpdateAsync(string id, Currency updatedBook) =>
        await _currenciesCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _currenciesCollection.DeleteOneAsync(x => x.Id == id);
}