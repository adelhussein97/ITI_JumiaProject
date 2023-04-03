using DomainLayer.Models.Wishlists;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace ITI_Jumiaaa.DbContext
{
    public class APIContext : IdentityDbContext<ApplicationUser>
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> carts { get; set; }
       
        public DbSet<Review> reviews { get; set; }
        public DbSet<Wishlist> wishlists { get; set; }
        public DbSet<Rate> rates { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Shipping> shippings { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<PrdImage> prdImages { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<ApplicationUser>().ToTable("users");
        //    builder.Entity<IdentityRole>().ToTable("Roles");
        //    builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        //    builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        //    builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        //    builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        //    builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        //}
    }
}