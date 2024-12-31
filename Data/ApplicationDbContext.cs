using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ERP_Bicicleteria.Models;

namespace ERP_Bicicleteria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ERP_Bicicleteria.Models.Client> Client { get; set; } = default!;
        public DbSet<ERP_Bicicleteria.Models.Employee> Employee { get; set; } = default!;
        public DbSet<ERP_Bicicleteria.Models.Order> Order { get; set; } = default!;
        public DbSet<ERP_Bicicleteria.Models.OrderDetail> OrderDetail { get; set; } = default!;
    }
}