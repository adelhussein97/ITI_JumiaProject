namespace DomainLayer.Models.PaymentMathods
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<MasterCard> MasterCard { set;  get; } 

        public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
    }
}
