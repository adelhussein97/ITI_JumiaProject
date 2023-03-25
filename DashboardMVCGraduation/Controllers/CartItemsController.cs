using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainLayer;
using DomainLayer.Models.CartItems;

namespace DashboardMVCGraduation.Controllers
{
    public class CartItemsController : Controller
    {
        private readonly EcommerceDbContext _context;

        public CartItemsController(EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: CartItems
        public async Task<IActionResult> Index()
        {
            var ecommerceDbContext = _context.CartItems.Include(c => c.Cart);
            return View(await ecommerceDbContext.ToListAsync());
        }

        // GET: CartItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CartItems == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .Include(c => c.Cart)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // GET: CartItems/Create
        public IActionResult Create()
        {
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id");
            return View();
        }

        // POST: CartItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,ProductId,Quantity,Price,TotalCost")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", cartItem.CartId);
            return View(cartItem);
        }

        // GET: CartItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CartItems == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", cartItem.CartId);
            return View(cartItem);
        }

        // POST: CartItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,ProductId,Quantity,Price,TotalCost")] CartItem cartItem)
        {
            if (id != cartItem.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemExists(cartItem.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", cartItem.CartId);
            return View(cartItem);
        }

        // GET: CartItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CartItems == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .Include(c => c.Cart)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // POST: CartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CartItems == null)
            {
                return Problem("Entity set 'EcommerceDbContext.CartItems'  is null.");
            }
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemExists(int id)
        {
          return (_context.CartItems?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}
