using InvInsightWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InvInsightWebApi.Data
{
    public class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasIndex(product => product.Name)
                .IsUnique();

            builder.Entity<Product>()
                .HasIndex(product => product.Sku)
                .IsUnique();
        }
    }
}
