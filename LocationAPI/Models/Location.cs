using System;

namespace LocationAPI.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public int CountryID { get; set; }  
        public int RegionID { get; set; }  
        public int StateID { get; set; }  
        public int CityID { get; set; }  
        public string LocationName { get; set; }=null!;

    }
}