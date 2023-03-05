namespace InvInsightWebApi.Models
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public string Supplier { get; set; }
    }
}
