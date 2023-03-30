using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace DomainLayer.Models.Wishlists
{
    public class Wishlist
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        public Product? Product { get; set; }

        public IEnumerable<Product>? Products { get; set; }
    }
}