using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_Jumiaaa.DbContext;
using WebApplication1.Models;

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly APIContext _context;

        public CartsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet("{id}")]
        public async Task<IActionResult> GetcartsByUserId([FromRoute] int id)
        {
          if (_context.carts == null)
          {
              return NotFound();
          }
          var result= await _context.carts.Where(p=>p.ApplicationUserId==id).ToListAsync();
           
          return Ok(result);
        }

        [HttpGet]
        public int GetLastId()
        {
            if (_context.carts == null)
            {
                return 0;
            }
            var result =  _context.carts.Max(p => p.Id);
            return result;
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart([FromRoute] int id)
        {
            if (_context.carts == null)
            {
                return NotFound();
            }
            var cart = await _context.carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart([FromRoute] int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddCart(Cart cart)
        {
            if (_context.carts == null)
            {
                return Problem("Entity set 'APIContext.carts'  is null.");
            }
            _context.carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart([FromRoute] int id)
        {
            if (_context.carts == null)
            {
                return NotFound();
            }
            var cart = await _context.carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists([FromRoute] int id)
        {
            return (_context.carts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}