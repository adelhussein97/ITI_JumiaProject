using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DomainLayer.AppContext
{
    public class EcommerceContextFactory : IDesignTimeDbContextFactory<EcommerceDbContext>
    {
        public EcommerceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EcommerceDbContext>();
            optionsBuilder.UseSqlServer("Data Source = SQL5110.site4now.net; Initial Catalog = db_a96873_itidbsecommerce; User Id = db_a96873_itidbsecommerce_admin; Password = ITI@12345.");

            return new EcommerceDbContext(optionsBuilder.Options);
        }
    }
}
