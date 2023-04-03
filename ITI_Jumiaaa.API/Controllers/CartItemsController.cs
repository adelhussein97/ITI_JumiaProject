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
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly APIContext _context;

        public CartItemsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/CartItems
        [HttpGet]
        public async Task<IActionResult> GetcartItems()
        {
          if (_context.cartItems == null)
          {
              return NotFound();
          }
            var result = await _context.cartItems.ToListAsync();
            return Ok(result);
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItem([FromRoute] int id)
        {
          if (_context.cartItems == null)
          {
              return NotFound();
          }
            var cartItem = await _context.cartItems.FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            return Ok(cartItem);
        }

        // PUT: api/CartItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem([FromRoute] int id, CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
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

        // POST: api/CartItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody]CartItem cartItem)
        {
          if (_context.cartItems == null)
          {
              return Problem("Entity set 'APIContext.cartItems'  is null.");
          }
            _context.cartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartItem", new { id = cartItem.Id }, cartItem);
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem([FromRoute] int id)
        {
            if (_context.cartItems == null)
            {
                return NotFound();
            }
            var cartItem = await _context.cartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.cartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartItemExists([FromRoute] int id)
        {
            return (_context.cartItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
