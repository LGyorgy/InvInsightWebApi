using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Sku { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Category { get; set; } = null!;
        [Required]
        public double Price { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public string Supplier { get; set; } = null!;
    }
}
