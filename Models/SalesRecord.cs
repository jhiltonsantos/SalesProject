using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus? status { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }


    }
}