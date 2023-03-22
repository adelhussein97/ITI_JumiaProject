using Microsoft.EntityFrameworkCore;

namespace DomainLayer
{
    public static class RelationalMapping
    {
        // Extension Methods To Map Relational Entity
        public static void MapRelation(this ModelBuilder builder)
        {
            // 1. ParentCategory ------- SubCategoryCategory
            //    M    ------- 1
            builder.Entity<Category>().HasOne(a=>a.ParentCategories)
                .WithMany(a=>a.SubCategories).HasForeignKey(a=>a.Id)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            // 2. Products   --------- Product Images
            //    1          --------- M
            builder.Entity<PrdImage>().HasOne(d => d.Product).WithMany(p => p.ImagesProduct)
               .HasForeignKey(d => d.PrdID)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Images_Products");
            // 2. Products   --------- ProductBrand
            //    1          --------- M
            builder.Entity<Product>().HasOne(d => d.Brand).WithMany(p => p.ProductsBrand)
               .HasForeignKey(d => d.BrandId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Brand_Products");


        }
    }
}
