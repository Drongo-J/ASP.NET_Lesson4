using ASPLesson4.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPLesson4.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> opt)
            : base(opt)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
