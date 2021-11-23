using Microsoft.EntityFrameworkCore;

namespace salesProject.Models
{
    public class SaleDbContext : DbContext
    {
        public SaleDbContext(DbContextOptions<SaleDbContext> options) : base(options) {}
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }

    }
}