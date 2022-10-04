using API.Models.AuthModels;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICartRepository _cartRepository;
        private readonly IJwtGeneratorService _jwtGeneratorService;

        public AuthController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, ICartRepository cartRepository, IJwtGeneratorService jwtGeneratorService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _cartRepository = cartRepository;
            _jwtGeneratorService = jwtGeneratorService;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(LoginModel model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var jwt = _jwtGeneratorService.GenerateAuthToken(user, userRoles);

                if (jwt is null)
                    return Forbid();

                return jwt;
            }

            return Forbid();

        }


        [HttpPost]
        [Route("SignUp")]
        public async Task<ActionResult<string>> SignUp(RegisterModel model)
        {

            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);

            // Añado el role pedido por el usuario, pero en caso de seleccionar empleado, entrará en espera de ser aprobado por el administrador


            if (model.RoleSelected == enums.RoleRegister.Customer)
            {
                if (!await _roleManager.RoleExistsAsync("Customer"))
                    await _roleManager.CreateAsync(new IdentityRole("Customer"));

                await _userManager.AddToRoleAsync(user, "Customer");

            }

            if (model.RoleSelected == enums.RoleRegister.Employee)
            {
                if (!await _roleManager.RoleExistsAsync("WaitingForApproval"))
                    await _roleManager.CreateAsync(new IdentityRole("WaitingForApproval"));

                await _userManager.AddToRoleAsync(user, "WaitingForApproval");
            }


            var userRoles = await _userManager.GetRolesAsync(user);

            var jwt = _jwtGeneratorService.GenerateAuthToken(user, userRoles);

            if (jwt is null)
                return Forbid();

            return jwt;
        }


    }
}