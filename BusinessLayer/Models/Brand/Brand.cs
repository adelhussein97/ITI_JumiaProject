namespace DomainLayer.Models.Brands
{

    // brand

    public class Brand
    {
        //Esmael Helal
        public int Id { get; set; }
       
        public string Name { get; set; }

        private readonly IList<Product> products;
        public IEnumerable<Product> ProductsBrand { get { return products; } } // Relation 1-M 

        public Brand(string name)
        {
            Name = name;
            products = new List<Product>();
        }
        public bool AddBrandProduct(Product product)
        {
            var productItem = ProductsBrand.FirstOrDefault(p => p.Name == product.Name);
            if (productItem == null)
            {

                products.Add(product);
                return true;
            }
            else
                return false;
        }
    }
}
