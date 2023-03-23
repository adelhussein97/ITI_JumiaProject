using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Models
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())"); 
            builder.Property(e => e.CustId).HasColumnName("CustID");
            builder.Property(e => e.PaymentDate).HasColumnType("datetime");
            builder.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
          
            builder.Property(e => e.StatusId).HasColumnName("StatusID");
        }
    }
}
