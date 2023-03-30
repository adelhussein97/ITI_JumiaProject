using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PrdImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrdImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrdImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.prdImages.Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PrdImages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.prdImages == null)
            {
                return NotFound();
            }

            var prdImage = await _context.prdImages
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prdImage == null)
            {
                return NotFound();
            }

            return View(prdImage);
        }

        // GET: PrdImages/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
            return View();
        }

        // POST: PrdImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Url,ProductId")] PrdImage prdImage)
        {
            if (ModelState.IsValid)
            {
                prdImage.Id = Guid.NewGuid();
                _context.Add(prdImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", prdImage.ProductId);
            return View(prdImage);
        }

        // GET: PrdImages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.prdImages == null)
            {
                return NotFound();
            }

            var prdImage = await _context.prdImages.FindAsync(id);
            if (prdImage == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", prdImage.ProductId);
            return View(prdImage);
        }

        // POST: PrdImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Url,ProductId")] PrdImage prdImage)
        {
            if (id != prdImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prdImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrdImageExists(prdImage.Id))
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
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", prdImage.ProductId);
            return View(prdImage);
        }

        // GET: PrdImages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.prdImages == null)
            {
                return NotFound();
            }

            var prdImage = await _context.prdImages
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prdImage == null)
            {
                return NotFound();
            }

            return View(prdImage);
        }

        // POST: PrdImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.prdImages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.prdImages'  is null.");
            }
            var prdImage = await _context.prdImages.FindAsync(id);
            if (prdImage != null)
            {
                _context.prdImages.Remove(prdImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrdImageExists(Guid id)
        {
            return (_context.prdImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}