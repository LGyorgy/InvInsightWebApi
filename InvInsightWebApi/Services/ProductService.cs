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

        public async Task<Product> CreateProductFromDto(ProductCreateDto productInputDto)
        {
            var product = new Product(productInputDto);

            await _inventoryContext.Products.AddAsync(product);
            await _inventoryContext.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = _inventoryContext.Products.FirstOrDefault(product => product.Id == id);

            if (product is null)
            {
                throw new ArgumentException($"Product with an ID of {id} cannot be found.");
            }

            _inventoryContext.Products.Remove(product);
            await _inventoryContext.SaveChangesAsync();
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

        public async Task<Product> UpdateProductFromDto(ProductUpdateDto productUpdateDto)
        {
            var product = _inventoryContext.Products.FirstOrDefault(product => product.Id == productUpdateDto.Id);

            if (product is null)
            {
                throw new ArgumentException($"Product with an ID of {productUpdateDto.Id} cannot be found.");
            }

            product.Name = productUpdateDto.Name;
            product.Sku = productUpdateDto.Sku;
            product.Description = productUpdateDto.Description;
            product.Category = productUpdateDto.Category;
            product.Price = productUpdateDto.Price;
            product.Cost = productUpdateDto.Cost;
            product.Supplier = productUpdateDto.Supplier;

            await _inventoryContext.SaveChangesAsync();

            return product;
        }
    }
}
