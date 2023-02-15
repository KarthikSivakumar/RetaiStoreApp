using System;

namespace LocationAPI.Models
{
    public class City
    {
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string CityName { get; set; } = null!;
    }
}