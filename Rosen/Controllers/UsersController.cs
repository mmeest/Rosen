using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rosen.Models;

namespace Rosen.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var users = await _userManager.Users.OrderBy(u => u.FLName).ToListAsync();
        //    return View(users);
        //}

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.OrderBy(u => u.FLName).ToListAsync();

            var usersWithRoles = new List<Dictionary<string, string>>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userWithRole = new Dictionary<string, string>
            {
                { "Id", user.Id },
                { "FLName", user.FLName },
                { "Email", user.Email },
                { "Phone", user.Phone },
                { "AdditionalInfo", user.AdditionalInfo },
                { "Role", roles.FirstOrDefault() ?? "No role assigned" }
            };

                usersWithRoles.Add(userWithRole);
            }

            return View(usersWithRoles);
        }






        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
