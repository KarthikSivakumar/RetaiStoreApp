using System;

namespace BillingAPI.Models
{
    public class BillDetails
    {
        public int BillNumber { get; set; }
        public DateTime BillDate {get;set;}
        public double BillTotal { get; set; }
        public int ItemCount { get; set; }
        public IEnumerable<Guid> ProductIDs { get; set; }
    }
}