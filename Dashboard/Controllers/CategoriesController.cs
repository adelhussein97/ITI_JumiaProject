using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoriesController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Categories
        public async Task<IActionResult> Index(string? Filter = null)
        {//test
            var task= _context.categories
                    .Where(c => Filter == null || c.Name.ToLower().Contains(Filter.ToLower()));
            return View(await task.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var category = await _context.categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile imgfile, [Bind("Id,Name,Image,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                var saveImage = Path.Combine(_hostEnvironment.WebRootPath, "CatImages", imgfile.FileName);
                string imageExtension = Path.GetExtension(imgfile.FileName);
                if (imageExtension == ".jpg" || imageExtension == ".png" || imageExtension == ".tiff" || imageExtension == ".jpeg"  || imageExtension == ".gif")
                {


                    #region Create New Object of Prd Images

                    category.Image = "./CatImages/" + imgfile.FileName;
                    #endregion

                    #region Upload Image on Server Root and Save URL in DBs
                    using (var uploadimg = new FileStream(saveImage, FileMode.Create))
                    {
                        await imgfile.CopyToAsync(uploadimg);

                        ViewData["message"] = "The Selected File " + imgfile.FileName + " is Uploaded Successfully";
                    }
                    #endregion


                    _context.Add(category);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["message"] = "The Selected File " + imgfile.FileName + " not match .jpg | .png | .tiff | .gif";

                }
            }
                return RedirectToAction(nameof(Index));
              
           
           
        }
            
        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var category = await _context.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Description")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var category = await _context.categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.categories'  is null.");
            }
            var category = await _context.categories.FindAsync(id);
            if (category != null)
            {
                _context.categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return (_context.categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}