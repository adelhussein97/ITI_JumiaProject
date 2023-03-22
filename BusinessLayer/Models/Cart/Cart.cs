namespace DomainLayer.Models.Carts
{
    public class Cart
    {
        public int Id { get; set; }

        public int? CustId { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ShipDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? TotalCost { get; set; }

        public CartStatus? StatusId { get; set; }

        public int? PaymentMethodId { get; set; }

        public Customer? Cust { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public CartStatus? Status { get; set; }
    }
}
