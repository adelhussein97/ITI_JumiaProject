namespace WebApplication1.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Product>? ProductId { get; set; }
    }
}