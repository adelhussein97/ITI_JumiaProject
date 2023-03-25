using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainLayer;
using DomainLayer.Models.PrdImages;

namespace DashboardMVCGraduation.Controllers
{
    public class PrdImagesController : Controller
    {
        private readonly EcommerceDbContext _context;

        public PrdImagesController(EcommerceDbContext context)
        {
            _context = context;
        }

        // GET: PrdImages
        public async Task<IActionResult> Index()
        {
            var ecommerceDbContext = _context.Product_Images.Include(p => p.Product);
            return View(await ecommerceDbContext.ToListAsync());
        }

        // GET: PrdImages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Product_Images == null)
            {
                return NotFound();
            }

            var prdImage = await _context.Product_Images
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
            ViewData["PrdID"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: PrdImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Url,PrdID")] PrdImage prdImage)
        {
            if (ModelState.IsValid)
            {
                prdImage.Id = Guid.NewGuid();
                _context.Add(prdImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrdID"] = new SelectList(_context.Products, "Id", "Name", prdImage.PrdID);
            return View(prdImage);
        }

        // GET: PrdImages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Product_Images == null)
            {
                return NotFound();
            }

            var prdImage = await _context.Product_Images.FindAsync(id);
            if (prdImage == null)
            {
                return NotFound();
            }
            ViewData["PrdID"] = new SelectList(_context.Products, "Id", "Name", prdImage.PrdID);
            return View(prdImage);
        }

        // POST: PrdImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Url,PrdID")] PrdImage prdImage)
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
            ViewData["PrdID"] = new SelectList(_context.Products, "Id", "Name", prdImage.PrdID);
            return View(prdImage);
        }

        // GET: PrdImages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Product_Images == null)
            {
                return NotFound();
            }

            var prdImage = await _context.Product_Images
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
            if (_context.Product_Images == null)
            {
                return Problem("Entity set 'EcommerceDbContext.Product_Images'  is null.");
            }
            var prdImage = await _context.Product_Images.FindAsync(id);
            if (prdImage != null)
            {
                _context.Product_Images.Remove(prdImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrdImageExists(Guid id)
        {
          return (_context.Product_Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
