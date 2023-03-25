namespace DomainLayer.Models.PrdImages
{
    public class PrdImage
    {
        public Guid Id { get; set; }
        public string Url { get; private set; }
        public long PrdID { get; set; }
        public Product Product { get; private set; } // Asocsiation Relation
        public PrdImage(string url, Product product)
        {
            Url = url;
            Product = product;

        }
        // Using Private Constructor For EF Only because the EF not understand objects when create DB 
        private PrdImage() : this(null!, null!)
        {

        }
    }
}
