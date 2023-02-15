using System;

namespace LocationAPI.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public int RegionID { get; set; }
        public string CountryCode { get; set; } = null!;
        public string CountryName { get; set; }= null!;
    }
}