using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.CartItems
{
    public class CartItemsConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            // Composit PK 
            builder.HasKey(e => new { e.CartId, e.ProductId }).HasName("PK_CartItems");

            builder.Property(e => e.CartId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ItemCartID");
            builder.Property(e => e.ProductId).HasColumnName("ProductID");
        }
    }
    
}
