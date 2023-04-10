using ITI_Jumiaaa.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        private readonly APIContext _context;

        public BrandsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/<BrandsController>
       
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            if (_context.brands == null)
            {
                return NotFound();
            }
            var result = await _context.brands.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByBrandId([FromRoute] int id)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var products = await _context.products.Where(p=>p.BrandId==id).ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}
