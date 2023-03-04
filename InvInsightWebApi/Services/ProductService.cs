using InvInsightWebApi.Services.Interfaces;

namespace InvInsightWebApi.Services
{
    public class ProductService : IProductService
    {
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var dummyProductList = new List<Product>() {
                new()
                {
                    Id = 1,
                    Name = "Dummy Product 1",
                    Sku = "DMMY-PRDCT-1",
                    Description = "Dummy Product 1 description.",
                    Category = "Dummies",
                    Price = 1.99,
                    Cost = 0.99,
                    Supplier = "DummySupplier"
                },
                new()
                {
                    Id = 2,
                    Name = "Dummy Product 2",
                    Description = "Dummy Product 2 description.",
                    Sku = "DMMY-PRDCT-2",
                    Category = "Dummies",
                    Price = 2.99,
                    Cost = 1.49,
                    Supplier = "DummySupplier"
                },
            };

            return dummyProductList;
        }
    }
}
