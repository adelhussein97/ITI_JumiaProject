namespace DomainLayer.Models.Wishlists
{
    public class Wishlist
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        public IEnumerable<Product>? Product { get; set; }

        public Customer? Customer { get; set; }
    }
}
