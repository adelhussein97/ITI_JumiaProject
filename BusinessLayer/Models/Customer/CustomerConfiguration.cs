using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DomainLayer.Models.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("CustID");
            builder.Property(e => e.City).HasMaxLength(50);
            builder.Property(e => e.FullAddress).HasMaxLength(100);
            builder.Property(e => e.GenderId).HasColumnName("GenderID");
            builder.Property(e => e.GovId).HasColumnName("GovID");
           
            
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.RegDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.Tel1)
                .HasMaxLength(11)
                .IsFixedLength();
            builder.Property(e => e.Tel2)
                .HasMaxLength(11)
                .IsFixedLength();
           // builder.HasIndex(e => e.Mail, "IX_Customers").IsUnique();

           // builder.HasIndex(e => e.UserName, "IX_Customers_1").IsUnique();

           // builder.Property(e => e.CustMail).HasMaxLength(50);
            //builder.Property(e => e.Password).HasMaxLength(50);
           // builder.Property(e => e.UserName).HasMaxLength(50);
        }
    }
}
