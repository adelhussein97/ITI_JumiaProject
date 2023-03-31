﻿using System;
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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _WebHost;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment WebHost)
        {
            _context = context;
            this._WebHost = WebHost;
        }

        // GET: Products
        public async Task<IActionResult> Index(string? Filter = null, int? FilterCategory = null, int? FilterBrand = null)
        {
            var task = _context.products
                    .Where(c => Filter == null || c.Name.ToLower().Contains(Filter.ToLower()))
                    .Where(c => FilterCategory == null ||
                    (c.CategoryId == FilterCategory))
                    .Where(c => FilterBrand == null ||
                    (c.BrandId == FilterBrand))
                    .Include(p=>p.Brand).Include(t => t.Category);

            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name");

            return View(await task.ToListAsync());
            
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile imgfile,[Bind("Id,Name,DiscountPercent,Discription,IsFeatured,Quantity,UnitPrice,InsertingDate,BrandId,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                // Upload Image on Server
                #region Check Image File Name
                var saveImage = Path.Combine(_WebHost.WebRootPath, "PrdImages", imgfile.FileName);
                string imageExtension = Path.GetExtension(imgfile.FileName); 
                #endregion

                if(imageExtension== ".jpg" || imageExtension == ".png" || imageExtension == ".tiff")
                {
                    #region Add New Product
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    #endregion

                    #region Create New Object of Prd Images
                    PrdImage prdImage = new PrdImage();
                    prdImage.ProductId = product.Id;
                    prdImage.Url = "~/PrdImages/" + imgfile.FileName;
                    #endregion

                    #region Upload Image on Server Root and Save URL in DBs
                    using (var uploadimg = new FileStream(saveImage, FileMode.Create))
                    {
                        await imgfile.CopyToAsync(uploadimg);
                        _context.prdImages.Add(prdImage);
                        await _context.SaveChangesAsync();
                        ViewData["message"] = "The Selected File " + imgfile.FileName + " is Uploaded Successfully";
                    } 
                    #endregion

                }
                else
                {
                    ViewData["message"] = "The Selected File " + imgfile.FileName + " not match .jpg | .png | .tiff";

                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "Id", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,DiscountPercent,Discription,IsFeatured,Quantity,UnitPrice,InsertingDate,BrandId,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.brands, "Id", "Id", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.products'  is null.");
            }
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return (_context.products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}