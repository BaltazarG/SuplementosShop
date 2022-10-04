using API.Models;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public UsersController(IUserRepository userRepository, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<IdentityUser>>> GetAll()
        {

            var users = await _userRepository.GetUsers();

            if (users == null || users.Count() <= 0)
                return NotFound();

            return Ok(users);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<IdentityUser>> Get(string userId)
        {

            var user = await _userRepository.GetUser(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }



        [HttpDelete]
        [Route("{userToDeleteId}")]
        public async Task<IActionResult> Delete(string userToDeleteId)
        {

            var user = await _userManager.FindByIdAsync(userToDeleteId);

            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Oops something went wrong. Please try again later" });

        }

        [HttpGet]
        [Route("waitingforapproval")]
        public async Task<ActionResult<ICollection<IdentityUser>>> GetPendingEmployees()
        {
            var users = await _userRepository.GetUsers();

            if (users == null || users.Count() <= 0)
                return NotFound();

            var pendingEmployees = new List<IdentityUser>();

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

            if (pendingEmployees is null || pendingEmployees.Count() <= 0)
                return NotFound();

            return Ok(pendingEmployees);
        }

        [HttpPost]
        [Route("waitingforapproval/approve/{employeeId}")]
        public async Task<IActionResult> ApproveEmployee(string employeeId)
        {
            //traigo el empleado
            var user = await _userManager.FindByIdAsync(employeeId);

            if (user == null)
                return NotFound();

            // le añado el role Employee y luego elimino el role WaitingForApproval
            if (!await _roleManager.RoleExistsAsync("Employee"))
                await _roleManager.CreateAsync(new IdentityRole("Employee"));

            await _userManager.AddToRoleAsync(user, "Employee");
            await _userManager.RemoveFromRoleAsync(user, "WaitingForApproval");


            return NoContent();
        }
    }
}
