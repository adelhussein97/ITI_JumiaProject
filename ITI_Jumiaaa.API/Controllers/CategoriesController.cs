using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync(string? Filter = null)
        {
            var result = await _context.categories.Where(c => Filter == null || c.Name.ToLower().Contains(Filter.ToLower())).ToListAsync();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int? id)
        {
            var result = await _context.categories.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}

