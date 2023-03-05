namespace InvInsightWebApi.Models
{
    public class ProductOutputDto
    {
        public ProductOutputDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Sku = product.Sku;
            Description = product.Description;
            Category = product.Category;
            Price = product.Price;
            Cost = product.Cost;
            Supplier = product.Supplier;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public double Price { get; set; }
        public double Cost { get; set; }
        public string Supplier { get; set; } = null!;
    }
}
