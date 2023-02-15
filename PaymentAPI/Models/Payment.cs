using System;

namespace PaymentAPI.Models
{
    public class Payment
    {
        public int StoreID { get; set; }
        public int BillNumber { get; set; }
        public string TransactionID { get; set; } = null!;
    }
}