using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Shipping
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

        public string? Area { get; set; }

        public string? Address { get; set; }

        [ForeignKey("Cart")]
        public int? CartId { get; set; }

        public Cart? Cart { get; set; }
    }
}