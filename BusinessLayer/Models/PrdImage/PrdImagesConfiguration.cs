using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DomainLayer.Models.PrdImages
{
    public class PrdImagesConfiguration : IEntityTypeConfiguration<PrdImage>
    {
        public void Configure(EntityTypeBuilder<PrdImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
            builder.Property(x => x.Url).IsRequired().IsUnicode().
                HasMaxLength(500).HasDefaultValueSql("(N'~/images/no.png')");
            

        }
    }
}
