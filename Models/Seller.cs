using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace salesProject.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        [StringLength(50, ErrorMessage = "Nome não pode ter mais que 50 caracteres.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public double BaseSalary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<SalesRecord> SalesRecord { get; set; }
        public double totalSales(DateTime initialDate, DateTime finalDate) {
            return 0;
        }

    }
}