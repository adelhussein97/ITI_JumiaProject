using Microsoft.EntityFrameworkCore;

namespace DomainLayer
{
    public static class RelationalMapping
    {
        // Extension Methods To Map Relational Entity
        public static void MapRelation(this ModelBuilder builder)
        {
            // 1. Products   --------- Product Images
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
            // 3. Cart   ---------     Customer
            //    M      ---------     1
            builder.Entity<Cart>().HasOne(d => d.CustCart).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Cart_Customers");
            
            // 4. Cart Items  ---------     Cart
            //    M         ---------     1
            builder.Entity<CartItem>().HasOne(d => d.Cart).WithMany(p => p.CartItems)
               .HasForeignKey(d => d.CartId)
               .HasConstraintName("FK_CartItems_Cart");
            // 5. Customer  ---------     CreditCard
            //    1        ---------      M
            builder.Entity<CreditCard>().HasOne(d => d.Customer).WithMany(p => p.CreditCardList)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Customers_CreditCard");
            // 6. Customer  ---------     Wishlist
            //    1        ---------      M
            builder.Entity<Wishlist>().HasOne(d => d.Customer).WithMany(p => p.Wishlists)
               .HasForeignKey(d => d.CustomerId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Wishlist_Customers");
            // 7. Customer  ---------     Review
            //    1        ---------      M
            builder.Entity<Review>().HasOne(d => d.CustomerReviews).WithMany(p => p.ReviewsList)
               .HasForeignKey(d => d.CustomerId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Review_Customers");
            // 8. Product  ---------     Review
            //    1        ---------      M
            builder.Entity<Review>().HasOne(d => d.Product).WithMany(p => p.ProductReviews)
               .HasForeignKey(d => d.ProductId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Review_Products");

            // 9. Product  ---------     Rate
            //    1        ---------      M
            builder.Entity<Rate>().HasOne(d => d.Product).WithMany(p => p.RateList)
               .HasForeignKey(d => d.ProductId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Rate_Products");
            // 10. Customer  ---------     Rate
            //    1        ---------      M
            builder.Entity<Rate>().HasOne(d => d.Customer).WithMany(p => p.RateLists)
               .HasForeignKey(d => d.CustomerId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Rate_Customer");
        }
    }
}
