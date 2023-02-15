using System;

namespace LocationAPI.Models
{
    public class Region
    {
        public int RegionID {get;set;}
        public string RegionCode { get; set; }= null!;
        public string RegionName { get; set; }= null!;
    }
}