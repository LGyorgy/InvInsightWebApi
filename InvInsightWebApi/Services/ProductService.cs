using InvInsightWebApi.Data;
using InvInsightWebApi.Models;
using InvInsightWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvInsightWebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly InventoryContext _inventoryContext;
        public ProductService(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _inventoryContext.Products.ToListAsync();

            return products;
        }
    }
}
