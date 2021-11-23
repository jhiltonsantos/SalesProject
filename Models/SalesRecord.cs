using System;

public enum SaleStatus {
    PENDING,
    BILLED,
    CANCELED
}

namespace salesProject.Models
{
    public class SalesRecord
    {
        public int SalesRecordId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus? status { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }


    }
}