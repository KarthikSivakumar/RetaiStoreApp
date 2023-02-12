using System;

namespace ProductAPI.Models
{
    public class Product
    {
        public Guid SKU { get; set; }
        public int StoreID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool Active { get; set; }

    }
}