
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuplementosShop.Models;
using SuplementosShop.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuplementosShop.Controllers
{
    public class AuthController : Controller
    {


        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ICartRepository _cartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, ICartRepository cartRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _cartRepository = cartRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
                return View();


            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };


                var token = TokenGenerator(authClaims).ToString();


                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                foreach (var userRole in userRoles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, userRole));
                }
                var principal = new ClaimsPrincipal(identity);


                // agrego el token a la cookie
                if (_httpContextAccessor.HttpContext != null)
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", token, new CookieOptions { HttpOnly = true, Secure = true });

                // inicio de sesion

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    });


                // dependiendo el role del usuario loggeado, lo redirijo a una vista

                if (userRoles[0].ToString() == "Customer")
                    return RedirectToAction("Index", "Market");



                if (userRoles[0].ToString() == "Employee")
                    return RedirectToAction("Index", "Product");

                if (userRoles[0].ToString() == "WaitingForApproval")
                    return RedirectToAction("Index", "WaitingForApproval");


                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterModel model)
        {


            if (!ModelState.IsValid)
                return View();

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

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = TokenGenerator(authClaims).ToString();

            var claimsIdentity = new ClaimsIdentity(authClaims, CookieAuthenticationDefaults.AuthenticationScheme);


            //agrego el token a la cookie

            _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", token, new CookieOptions { HttpOnly = true, Secure = true });

            // inicio sesion  despues de registrarse

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            // dependiendo el role del usuario loggeado, lo redirijo a una vista


            if (model.RoleSelected == enums.RoleRegister.Customer)
            {
                // le creo un carrito
                await _cartRepository.CreateCart(user.Id);
                return RedirectToAction("Index", "Market");
            }

            if (model.RoleSelected == enums.RoleRegister.Employee)
                return RedirectToAction("Index", "WaitingForApproval");


            return RedirectToAction("Index", "Category");


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("Token");

            return RedirectToAction("Login", "Auth");
        }


        // Genero el token

        private JwtSecurityToken TokenGenerator(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(4),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
