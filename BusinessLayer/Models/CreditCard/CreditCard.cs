

namespace DomainLayer.Models.CreditCards
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; } = null!;

        public DateTime? MasterExpDate { get; set; }

        public CardType CardTypeId { get; set; }

        public int CustomerId { get; set; }

        public int? MasterBalance { get; set; }

        public Customer? Customer { set; get; }
    }
}
