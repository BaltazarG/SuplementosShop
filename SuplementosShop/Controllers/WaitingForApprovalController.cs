using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuplementosShop.Models;
using SuplementosShop.Repositories.Interfaces;

namespace SuplementosShop.Controllers
{
    public class WaitingForApprovalController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository _userRepository;

        public WaitingForApprovalController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "WaitingForApproval")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> ApproveUser()
        {
            //traigo todos los usuarios registrados
            var users = await _userRepository.GetUsers();

            var pendingEmployees = new List<IdentityUser>();


            // y los filtro por role 'WaitingForApproval' para mostrar solo esos en la vista de aprobacion del admin
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                if (userRoles.Count() > 0)
                {
                    if (userRoles[0].ToString() == "WaitingForApproval")
                    {
                        pendingEmployees.Add(user);
                    }
                }

            }

            var approveUsers = new ApproveUsersViewModel()
            {
                UsersWaitingForApproval = pendingEmployees
            };

            return View(approveUsers);
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Approve(ApproveUsersViewModel model)
        {
            //traigo el empleado
            var user = await _userManager.FindByIdAsync(model.CurrentUserId);

            if (user == null)
                return RedirectToAction("ApproveUser", "WaitingForApproval");

            // le añado el role Employee y luego elimino el role WaitingForApproval
            if (!await _roleManager.RoleExistsAsync("Employee"))
                await _roleManager.CreateAsync(new IdentityRole("Employee"));

            await _userManager.AddToRoleAsync(user, "Employee");
            await _userManager.RemoveFromRoleAsync(user, "WaitingForApproval");


            return RedirectToAction("Index", "Admin");
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(ApproveUsersViewModel model)
        {
            //traigo el empleado
            var user = await _userManager.FindByIdAsync(model.CurrentUserId);

            if (user == null)
                return RedirectToAction("ApproveUser", "WaitingForApproval");

            //lo elimino
            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index", "Admin");
        }
    }
}
