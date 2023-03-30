using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.ModelsDTO;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly ApplicationDbContext app;

        public RolesController(RoleManager<IdentityRole> roleManager, ApplicationDbContext app)
        {
            _RoleManager = roleManager;
            this.app = app;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var Roles = await _RoleManager.Roles.ToListAsync();
            return View(Roles);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(RoleDTO roleDTO)
        {
            if (!ModelState.IsValid) return View("Index", await _RoleManager.Roles.ToListAsync());

            if (await _RoleManager.RoleExistsAsync(roleDTO.Name))
            {
                ModelState.AddModelError("Name", "Role is Exist");
                return View("Index", await _RoleManager.Roles.ToListAsync());
            }
            await _RoleManager.CreateAsync(new IdentityRole(roleDTO.Name.Trim()));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Role = await _RoleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            return View(Role);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            var Role = await _RoleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Role == null)
            {
                return NotFound();
            }

            return View(Role);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var Role = await _RoleManager.Roles.FirstOrDefaultAsync(c => c.Id == id);
            if (Role == null) return NotFound();
            app.Roles.Remove(Role);
            await app.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}