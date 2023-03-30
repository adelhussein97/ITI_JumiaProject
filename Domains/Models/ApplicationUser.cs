using DomainLayer.Models.Enum;
using DomainLayer.Models.Wishlists;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(100)]
        public string? FirstName { get; set; }

        [Required, MaxLength(100)]
        public string? LastName { get; set; }

        public byte[]? ProfilePicture { get; set; }

        public string? City { get; set; }

        public string? FullAddress { get; set; }
        public Gender? GenderId { get; set; }
        public Governorate? GovernorateId { get; set; }
        public DateTime? RegDate { get; set; }
        public IEnumerable<Cart>? CartId { set; get; }
        public IEnumerable<CreditCard>? CreditCardId { get; set; }
        public IEnumerable<Review>? ReviewId { get; set; }
        public IEnumerable<Wishlist>? WishlistId { get; set; }
        public IEnumerable<Rate>? RateId { get; set; }
    }
}