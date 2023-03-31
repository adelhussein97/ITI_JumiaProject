
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class PrdImage
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }

        [ForeignKey("Product")]
        public long? ProductId { get; set; } // Asocsiation Relation

        public Product? Product { get; set; } // Asocsiation Relation
    }
}