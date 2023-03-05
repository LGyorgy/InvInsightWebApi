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

        public async Task<IEnumerable<ProductOutputDto>> GetAllProductDtosAsync()
        {
            var products = await _inventoryContext.Products.ToListAsync();

            var productDtos = new List<ProductOutputDto>();
            foreach (var product in products)
            {
                var productDto = new ProductOutputDto(product);
                productDtos.Add(productDto);
            }

            return productDtos;
        }
    }
}
