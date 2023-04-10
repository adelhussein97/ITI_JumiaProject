using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_Jumiaaa.DbContext;
using WebApplication1.Models;

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly APIContext _context;

        public RatesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Rates
        [HttpGet]
        public async Task<IActionResult> Getrates()
        {
          if (_context.rates == null)
          {
              return NotFound();
          }
          var result= await _context.rates.ToListAsync();
            return Ok(result);
        }

        // GET: api/Rates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRate([FromRoute] int id)
        {
          if (_context.rates == null)
          {
              return NotFound();
          }
            var rate = await _context.rates.FindAsync(id);

            if (rate == null)
            {
                return NotFound();
            }

            return Ok(rate);
        }

        // PUT: api/Rates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRate([FromRoute]int id, Rate rate)
        {
            if (id != rate.Id)
            {
                return BadRequest();
            }

            _context.Entry(rate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateExists(id))
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

        // POST: api/Rates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddRate(Rate rate)
        {
          if (_context.rates == null)
          {
              return Problem("Entity set 'APIContext.rates'  is null.");
          }
            _context.rates.Add(rate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRate", new { id = rate.Id }, rate);
        }

        // DELETE: api/Rates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRate([FromRoute] int id)
        {
            if (_context.rates == null)
            {
                return NotFound();
            }
            var rate = await _context.rates.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }

            _context.rates.Remove(rate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RateExists([FromRoute] int id)
        {
            return (_context.rates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
