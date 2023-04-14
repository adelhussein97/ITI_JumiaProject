using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_Jumiaaa.DbContext;
using WebApplication1.Models;
using ITI_Jumiaaa.API.dtos;

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly APIContext _context;

        public ProductsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] string? Filter = null)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var result = await _context.products.Where(c => Filter == null ||
                                       c.Name.ToLower().Contains(Filter.ToLower())).ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllProductsWithImgs")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.products.Include(c => c.PrdImages).Include(b => b.Brand).Include(cat => cat.Category)
                .Select(c => new ProductViewModel()
                {
                    id = c.Id,
                    name = c.Name,
                    imageurl = c.PrdImages.FirstOrDefault().Url,
                    discountpercent = c.DiscountPercent,
                    discription = c.Discription,
                    quantity = c.Quantity,
                    unitprice = c.UnitPrice,
                    insertingdate = c.InsertingDate,
                    brandId = c.BrandId,
                    categoryId = c.CategoryId
                }).ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetAllProductsWithImgs/{id}")]
        public async Task<IActionResult> GetAllProducts(long id)
        {
            var products = await _context.products.Include(c => c.PrdImages).Include(b => b.Brand).Include(cat => cat.Category)
                .Select(c => new ProductViewModel()
                {
                    id = c.Id,
                    name = c.Name,
                    imageurl = c.PrdImages.FirstOrDefault().Url,
                    discountpercent = c.DiscountPercent,
                    discription = c.Discription,
                    quantity = c.Quantity,
                    unitprice = c.UnitPrice,
                    insertingdate = c.InsertingDate,
                    brandId = c.BrandId,
                    categoryId = c.CategoryId
                }).FirstOrDefaultAsync(c => c.id == id);
            return Ok(products);
        }

        // GET: api/ProductsImages
        [HttpGet]
        public async Task<IActionResult> GetAllProductsImagesAsync([FromQuery] long? Filter = null)
        {
            if (_context.prdImages == null)
            {
                return NotFound();
            }
            var result = await _context.prdImages.Where(c => Filter == null ||
                                       c.ProductId == Filter).ToListAsync();

            return Ok(result);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] long id)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var product = await _context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] long id)
        {
            if (_context.prdImages == null)
            {
                return NotFound();
            }
            var productImages = await _context.prdImages.Where(c => c.ProductId == id).ToListAsync();

            if (productImages == null)
            {
                return NotFound();
            }

            return Ok(productImages);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'APIContext.products'  is null.");
            }
            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists([FromRoute] long id)
        {
            return (_context.products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}