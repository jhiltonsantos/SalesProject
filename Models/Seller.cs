using System;
using System.Collections.Generic;

namespace salesProject.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public double BaseSalary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<SalesRecord> SalesRecord { get; set; }

        public double totalSeller(DateTime initialDate, DateTime finalDate) {
            return 0;
        }
    }
}