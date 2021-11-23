using System.Collections.Generic;

namespace salesProject.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Seller> Seller { get; set; }
        
    }
}