namespace DomainLayer.Models.Products
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

        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        private readonly IList<PrdImage> Images; // For Set intenal and prevent set from external

        private readonly IList<Category> categories;

        public IEnumerable<PrdImage> ImagesProduct { get { return Images; } }

        public IEnumerable<Category> Categories { get { return categories; } }

        public IEnumerable<Review>? ProductReviews { get; set; }

        public IEnumerable<Rate>? RateList { get; set; }

        public Product(string name, float unitPrice, bool isValid, int quantity,
            Category category, Brand brand, string? discription = null, byte? discountPercent = null)
        {
            Name = name;
            Discription = discription;
            UnitPrice = unitPrice;
            DiscountPercent = discountPercent;
            Quantity = quantity;
            Images = new List<PrdImage>();
            categories = new List<Category>
            {
                category
            };

            Brand = brand;
        }
        // Using Private Constructor For EF Only because the EF not understand objects when create DB 
        private Product() : this(null!, 0!, true!, 0!, null!, null!, null, null)
        {

        }

        public bool AddImage(PrdImage image)
        {
            // Check sub category name exist or not
            var imageItem = Images.FirstOrDefault(i => i.Url == image.Url);
            if (imageItem == null)
            {
                Images.Add(image);
                return true;
            }
            else
                return false;
        }
        public bool Addcategory(Category category)
        {
            var categoryItem = Categories.FirstOrDefault(c => c.Name == category.Name);
            if (categoryItem == null)
            {
                categories.Add(category);

                return true;
            }
            else
                return false;

        }


    }
}
