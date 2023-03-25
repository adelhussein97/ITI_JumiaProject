using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Models.Wishlists
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("Wishlist");

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            builder.Property(e => e.ProductId).HasColumnName("Product_ID");
        }
    }
}
