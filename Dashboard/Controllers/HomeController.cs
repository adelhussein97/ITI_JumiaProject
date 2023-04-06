using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Data;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;


        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger, IStringLocalizer<HomeController> stringLocalizer)
        {
            this.context = context;
            _logger = logger;
            this._stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            ViewBag.name = _stringLocalizer["welcome"];
            ViewBag.Details = context.categories.ToList();
            ViewBag.Count = context.categories.Count();

            ViewBag.Details = context.products.ToList();
            ViewBag.Product = context.products.Count();

            ViewBag.Details = context.brands.ToList();
            ViewBag.Brand = context.brands.Count();

            ViewBag.Details = context.Users.ToList();
            ViewBag.User = context.Users.Count();
            return View();
        }
     

        [HttpPost]
        [AllowAnonymous]
        public IActionResult setLanguge(string languge, string ReturnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(languge)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return LocalRedirect(ReturnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
}