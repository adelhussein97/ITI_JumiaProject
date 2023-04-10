using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_Jumiaaa.DbContext;
using WebApplication1.Models;

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly APIContext _context;

        public CategoriesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> Getcategories([FromQuery] string? Filter = null)
        {
          if (_context.categories == null)
          {
              return NotFound();
          }
            var result = await _context.categories.Where(c => Filter == null ||
              c.Name.ToLower().Contains(Filter.ToLower())).ToListAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        


        // GET: api/Categories/5
        [HttpGet("{/id}")]
        public async Task<IActionResult> GetProductsByCategoryId([FromRoute] int id)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var products = await _context.products.Where(p=>p.CategoryId==id).ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }


        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody]Category category)
        {
          if (_context.categories == null)
          {
              return Problem("Entity set 'APIContext.categories'  is null.");
          }
            _context.categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (_context.categories == null)
            {
                return NotFound();
            }
            var category = await _context.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists([FromRoute] int id)
        {
            return (_context.categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
