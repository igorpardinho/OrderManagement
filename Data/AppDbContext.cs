using Microsoft.EntityFrameworkCore;
using OrderManagement.Entities;
using System.Security.Cryptography.X509Certificates;

namespace OrderManagement.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }

}


