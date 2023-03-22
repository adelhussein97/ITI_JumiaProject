using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.CartItems
{
    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int? Quantity { get; set; }

        public int? Price { get; set; }

        public int? TotalCost { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
