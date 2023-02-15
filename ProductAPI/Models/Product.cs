using System;

namespace ProductAPI.Models
{
    public class Product
    {
        public Guid SKU { get; set; }
        public int StoreID { get; set; }
        public string ProductName { get; set; } = null!;
        public double Price { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public bool Active { get; set; }

    }
}