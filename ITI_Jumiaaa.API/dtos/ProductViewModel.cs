namespace ITI_Jumiaaa.API.dtos
{
    public class ProductViewModel
    {
        public long id { get; set; }
        public string? name { get; set; }

        public string? imageurl { get; set; }

        public byte? discountpercent { get; set; }

        public string? discription { get; set; }

        public int? quantity { get; set; }

        public float? unitprice { get; set; }

        public DateTime? insertingdate { get; set; }
        public int? brandId { get; set; }
        public int? categoryId { get; set; }
    }
}