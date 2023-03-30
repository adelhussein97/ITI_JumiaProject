using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public long productId { get; set; }

        public Product? Product { get; set; }

        public int? Quantity { get; set; }

        public int? Price { get; set; }

        public int? TotalCost { get; set; }

        [ForeignKey("Cart")]
        public int cartId { get; set; }

        public Cart? Cart { get; set; }
    }
}