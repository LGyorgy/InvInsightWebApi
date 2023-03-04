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
    }
}
