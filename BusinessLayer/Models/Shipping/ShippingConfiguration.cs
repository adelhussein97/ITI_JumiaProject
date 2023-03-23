using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Models.Shippings
{
    public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id");
            
            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("Date");
            builder.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("Address");
            builder.Property(e => e.Area)
                .HasMaxLength(50)
                .HasColumnName("Area");
            builder.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("City");
        }
    }
}
