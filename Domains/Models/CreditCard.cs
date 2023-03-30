using DomainLayer.Models.Enum;

namespace WebApplication1.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }

        public DateTime? MasterExpDate { get; set; }

        public CardType CardTypeId { get; set; }

        public ApplicationUser? applicationUserId { get; set; }
        public int? MasterBalance { get; set; }
    }
}