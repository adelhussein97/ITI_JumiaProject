using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public byte? DiscountPercent { get; set; }

        public string? Discription { get; set; }

        public bool? IsFeatured { get; set; }

        public int Quantity { get; set; }

        public float UnitPrice { get; set; }

        public DateTime? InsertingDate { get; set; }

        [ForeignKey("Brand")]
        public int? BrandId { get; set; }

        public Brand? Brand { get; set; }

       

        public IEnumerable<PrdImage>? PrdImages { get; set; }

        public IEnumerable<Review>? ReviewId { get; set; }
        public IEnumerable<Rate>? RateId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}