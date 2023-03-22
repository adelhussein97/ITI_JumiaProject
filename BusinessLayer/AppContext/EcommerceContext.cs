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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new PrdImagesConfiguration().Configure(modelBuilder.Entity<PrdImage>());
            new BrandConfiguration().Configure(modelBuilder.Entity<Brand>());
            // Calling RelationShip
            modelBuilder.MapRelation();
        }
    }
}
