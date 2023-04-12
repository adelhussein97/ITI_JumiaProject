using DomainLayer.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    // Cart Model
    public class Cart
    {
        //properties
        public int Id { get; set; }

        public DateTime? CreationDate { get; set; }

        public float Discount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? TotalCost { get; set; }

        public int? StatusId { get; set; }
        public int? ApplicationUserId { get; set; }

        public CardType? CardTypeId { get; set; }

        public CartStatus? CartStatusId { get; set; }

        public IEnumerable<CartItem>? CartItemId { get; set; }
    }
}