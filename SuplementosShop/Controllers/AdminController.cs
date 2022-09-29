using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;


        public AdminController(IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // traigo todos los usuarios registrados
            var users = await _userRepository.GetUsers();



            return View(users);
        }

        public async Task<IActionResult> DeleteUser(IdentityUser userToDelete)
        {
            // traigo el usuario que quiero eliminar 

            var user = await _userManager.FindByIdAsync(userToDelete.Id);

            if (user is null)
                return RedirectToAction("Index", "Admin");

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IdentityUser userToDelete)
        {
            //traigo el usuario

            if (userToDelete == null)
                return RedirectToAction("Index", "Admin");

            //lo elimino
            var user = await _userManager.FindByIdAsync(userToDelete.Id);

            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index", "Admin");
        }
    }
}
