global using WebApplication1.Models;
using Dashboard.MVC;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;
using WebApplication1.Data;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddLocalization();
            builder.Services.AddSingleton<IStringLocalizerFactory, IstringLocalizerfactory>();
            builder.Services.AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(
                options => options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(IstringLocalizerfactory))
                );

            builder.Services.Configure<RequestLocalizationOptions>(option =>
            {
                var culture = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG"),
                };
                option.DefaultRequestCulture = new RequestCulture(culture: culture[0], uiCulture: culture[0]);
                option.SupportedCultures = culture;
                option.SupportedUICultures = culture;
            });

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ITIConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultUI()
              .AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            var culture = new[]
            {
                "en-US",
                "ar-EG"
            };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(culture[0])
                .AddSupportedCultures(culture)
                .AddSupportedUICultures(culture);

            app.UseRequestLocalization(localizationOptions);
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}