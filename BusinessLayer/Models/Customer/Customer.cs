namespace DomainLayer.Models.Customers
{
    public class Customer
    {
        public int  Id { get; set; }

        public string?  Name { get; set; }

        //public string?  Mail { get; set; }

        //public string?  UserName { get; set; }

        //public string?  Password { get; set; }

        public Gender?  GenderId { get; set; } // 0 , 1 

        public Governorate?  GovId { get; set; }

        public string?  City { get; set; }

        public string?  FullAddress { get; set; }

        public string?  Tel1 { get; set; }

        public string?  Tel2 { get; set; }

        public int? MasterId { get; set; }

        public DateTime?  RegDate { get; set; }

        public  IEnumerable<Cart>? Carts { set;  get; }

        public Gender? Gender { get; set; }

        public IEnumerable<CreditCard>? CreditCardList { get; set; }

        public Governorate?  Gov { get; set; }

        public IEnumerable<Review>? ReviewsList { get; set; }

        public IEnumerable<Wishlist> Wishlists { get; } = new List<Wishlist>();

        public IEnumerable<Rate>? RateLists { get; set; }

    }
}
