using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer
{
    public class EcommerceDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        // Dependancy Injection call base 
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PrdImage> Product_Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Wishlist> Wishlists { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Shipping> Shippings { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Rate> Rates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // All Model Configurations
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new PrdImagesConfiguration().Configure(modelBuilder.Entity<PrdImage>());
            new BrandConfiguration().Configure(modelBuilder.Entity<Brand>());

            new CartConfiguration().Configure(modelBuilder.Entity<Cart>());
            new CartItemsConfiguration().Configure(modelBuilder.Entity<CartItem>());
            new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
            new CreditCardConfiguration().Configure(modelBuilder.Entity<CreditCard>());

            new ReviewConfiguration().Configure(modelBuilder.Entity<Review>());
            new WishlistConfiguration().Configure(modelBuilder.Entity<Wishlist>());
            new ShippingConfiguration().Configure(modelBuilder.Entity<Shipping>());
            new RateConfiguration().Configure(modelBuilder.Entity<Rate>());


            // Calling Identity
            base.OnModelCreating(modelBuilder);

            // Reflection of Configuration
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BrandConfiguration).Assembly);
            // Calling RelationShip
            modelBuilder.MapRelation();
        }
    }
}
