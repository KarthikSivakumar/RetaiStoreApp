using System;

namespace CurrencyAPI.Models
{
    public class Currency
    {
        public int CurrencyID { get; set; }
        public IEnumerable<int> CountryIDs {get; set;}
        public string CurrencyName { get; set; }
        
    }
}