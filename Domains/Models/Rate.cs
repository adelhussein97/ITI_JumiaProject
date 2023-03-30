using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Rate
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }

        [ForeignKey("Product")]
        public long? ProductId { get; set; }

        public Product? Product { get; set; }
    }
}