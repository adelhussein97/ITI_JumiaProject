namespace DomainLayer.Models.Carts
{
    // Cart Model
    public class Cart
    {
        public int Id { get; set; }

        public int? CustId { get; set; }

        public DateTime? CreationDate { get; set; }

        public float Discount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? TotalCost { get; set; }

        public int? StatusId { get; set; }

        public CardType? PaymentMethodId { get; set; }

        public Customer? CustCart { get; set; }

        public CartStatus? Status { get; set; }

        public Shipping? Shipping { get; set; }

        public IEnumerable<CartItem>? CartItems { get; set; }
    }
}
