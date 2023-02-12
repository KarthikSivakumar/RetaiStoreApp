using System;

namespace CountryAPI.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public int RegionID { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}