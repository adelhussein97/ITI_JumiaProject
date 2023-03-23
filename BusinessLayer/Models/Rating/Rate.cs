namespace DomainLayer.Models.Rating
{
    public class Rate
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public long ProductId { get; set; }

        public Customer? Customer { get; set; }

        public Product? Product { get; set; }
    }
}
