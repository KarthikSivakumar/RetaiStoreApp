using System;

namespace StoreAPI.Models
{
    public class Store
    {
        public int StoreID { get; set; }
        public int LocationID { get; set; }
        public string StoreName { get; set; }= null!;
    }
}