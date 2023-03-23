using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer.Models.CreditCards
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.CardNumber)
                 .HasMaxLength(14)
                 .IsFixedLength()
                 .HasColumnName("CardNumber").IsUnicode();
            builder.Property(e => e.MasterExpDate).HasColumnType("date");
        }
    }
}
