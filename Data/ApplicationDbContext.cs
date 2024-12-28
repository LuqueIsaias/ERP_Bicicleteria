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
    }
}