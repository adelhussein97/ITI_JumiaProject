using DomainLayer.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public Gender? genderId { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        public string? Message { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        [ForeignKey("Product")]
        public long? ProductId { get; set; }

        public Product? Product { get; set; }
    }
}