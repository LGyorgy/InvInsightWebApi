namespace InvInsightWebApi.Models
{
    public class ProductUpdateDto
    {
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
