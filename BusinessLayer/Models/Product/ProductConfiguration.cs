using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Models.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            builder.Property(x => x.Name).IsRequired().IsUnicode().
                HasMaxLength(100);
            builder.Property(e => e.BrandId).HasColumnName("BrandID");
            builder.Property(e => e.DiscountPercent).HasDefaultValueSql("((0))");
            builder.Property(e => e.InsertingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.IsFeatured).HasDefaultValueSql("((0))");

           

               



        }
    }

}
