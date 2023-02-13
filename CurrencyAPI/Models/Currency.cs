using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CurrencyAPI.Models;

public class Currency
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public int CurrencyID { get; set; }
    public string CurrencyCode { get; set; } = null!;
    public string CurrencyName { get; set; } = null!;
    public IEnumerable<int> CountryIDs { get; set; } = null!;

}
