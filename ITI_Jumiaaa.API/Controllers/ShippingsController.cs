using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_Jumiaaa.DbContext;
using WebApplication1.Models;
using DomainLayer.Models.Enum;

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly APIContext _context;

        public ShippingsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Shippings
        [HttpGet]
        public async Task<IActionResult> Getshippings()
        {
          if (_context.shippings == null)
          {
              return NotFound();
          }
          var result= await _context.shippings.ToListAsync();
            return Ok(result);
        }

        // GET: api/Shippings
        [HttpGet]
        public async Task<IActionResult> GetGovernates()
        {
            var _statusList = from Governorate d in Enum.GetValues(typeof(Governorate))
                              select new { Id = (int)d, Name = d.ToString() };
           
            return Ok(_statusList);
        }

        // GET: api/Shippings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipping([FromRoute] int id)
        {
          if (_context.shippings == null)
          {
              return NotFound();
          }
            var shipping = await _context.shippings.FindAsync(id);

            if (shipping == null)
            {
                return NotFound();
            }

            return Ok(shipping);
        }

        // PUT: api/Shippings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping([FromRoute] int id, Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
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

        // POST: api/Shippings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddShipping([FromBody]Shipping shipping)
        {
          if (_context.shippings == null)
          {
              return Problem("Entity set 'APIContext.shippings'  is null.");
          }
            _context.shippings.Add(shipping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipping", new { id = shipping.Id }, shipping);
        }

        // DELETE: api/Shippings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping([FromRoute] int id)
        {
            if (_context.shippings == null)
            {
                return NotFound();
            }
            var shipping = await _context.shippings.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }

            _context.shippings.Remove(shipping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShippingExists([FromRoute] int id)
        {
            return (_context.shippings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
