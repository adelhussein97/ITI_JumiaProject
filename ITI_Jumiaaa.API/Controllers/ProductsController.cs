using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public ProductsController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync(string? Filter = null)
        {
            var result = await _context.products.Where(c => Filter == null || c.Name.ToLower().Contains(Filter.ToLower())).ToListAsync();

            return Ok(result);

        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(long? id)
        {
            var result = await _context.products.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
