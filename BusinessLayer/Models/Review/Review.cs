namespace DomainLayer.Models.Reviews
{
    public class Review
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public Gender? genderId { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public long? ProductId { get; set; }
        public int? CustomerId { get; set; }

        public string? Message { get; set; }

        public Product? Product { get; set; }

        public Customer? CustomerReviews { get; set;}

    }
}
