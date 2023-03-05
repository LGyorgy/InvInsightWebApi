namespace InvInsightWebApi.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(ProductCreateDto productDto)
        {
            Name = productDto.Name;
            Sku = productDto.Sku;
            Description = productDto.Description;
            Category = productDto.Category;
            Price = productDto.Price;
            Cost = productDto.Cost;
            Supplier = productDto.Supplier;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public string Supplier { get; set; }
    }
}
