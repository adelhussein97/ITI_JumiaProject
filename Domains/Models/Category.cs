namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        private IEnumerable<Category>? subcategories { get; set; }

        private IEnumerable<Product>? products { get; set; } // Prevent Add External

        public Category? ParentCategories { get; set; }
    }
}