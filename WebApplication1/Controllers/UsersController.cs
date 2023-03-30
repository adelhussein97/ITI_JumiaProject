using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.ModelsDTO;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller

    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext app;

        public UsersController(UserManager<ApplicationUser> userManger, RoleManager<IdentityRole> roleManager, ApplicationDbContext app)
        {
            this.app = app;
            _userManger = userManger;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManger.Users.Select(x => new UserDTO
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
            }).ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var User = await _userManger.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            var User = await _userManger.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var User = await _userManger.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (User == null) return NotFound();
            app.Users.Remove(User);
            await app.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}