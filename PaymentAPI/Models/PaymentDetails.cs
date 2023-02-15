using System;

namespace PaymentAPI.Models
{
    public class PaymentDetails
    {
        public int BillNumber { get; set; }
        public DateTime BillDate {get;set;}
        public double BillTotal { get; set; }
        public int ItemCount { get; set; }
        public string TransactionID { get; set; }= null!;
        public IEnumerable<Guid> ProductIDs { get; set; }= null!;
    }
}