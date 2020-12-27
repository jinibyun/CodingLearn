using Microsoft.EntityFrameworkCore;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MovieV1> Movie1 { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Table_1> Table_1 { get; set; }
    }
}
