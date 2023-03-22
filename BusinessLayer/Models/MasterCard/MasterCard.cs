namespace DomainLayer.Models.MasterCards
{
    public class MasterCard
    {
        public int Id { get; set; }
        public string MasterCardId { get; set; } = null!;

        public DateTime? MasterExpDate { get; set; }

        public int? MasterBalance { get; set; }

        public IEnumerable<Customer> Customers { set;  get; } 
    }
}
