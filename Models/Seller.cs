using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public void addSales(SalesRecord sr) {

            // Criar nova venda passando o valor do vendedor
        }

        public void removeSales(SalesRecord sr) {
            // Remover venda realizada pelo vendedor
        }
        
        
        public void totalSales(DateTime initialDate, DateTime finalDate) {}

            
        
    }
}