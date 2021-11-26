using System;
using System.Collections.Generic;

namespace salesProject.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Seller> Seller { get; set; }

        public void addSeller () {
            // Criar conta de novo vendedor
        }

        public double totalSales (DateTime initialDate, DateTime finalDate) {
            // Passa a quantidade de vendas realizadas no periodo
            return 0;
        }
        
    }
}