using System;

namespace CurrencyAPI.Models
{
    public class Currency
    {
        public int CurrencyID { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public IEnumerable<int> CountryIDs {get; set;}
        
    }
}