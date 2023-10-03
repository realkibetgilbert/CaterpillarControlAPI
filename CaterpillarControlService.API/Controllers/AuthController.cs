using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Core.Utils;
using CaterpillarControlService.API.Dtos.Auth;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Mail;

namespace CaterpillarControlService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly CaterpillarDbContext _context;

        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole<long>> roleManager, ITokenService tokenService, CaterpillarDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _context = context;
        }
        
        [HttpPost]
        [Route("login")]
        [ValidateModel]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user != null)
            {
                if (!user.IsActive)
                {
                    var error = new
                    {
                        title = "Error",
                        message = "This User Is Deactivated"
                    };

                    return BadRequest(error);
                }

                bool checkPasswordResult = await _userManager.CheckPasswordAsync(user, login.Password);

                if (checkPasswordResult)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    var jwtToken = _tokenService.CreateJwtToken(user, roles.ToList());

                    var res = new
                    {
                        id = user.Id,
                        userName = user.Email,
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        token = jwtToken,
                        roles = roles.ToList()
                    };

                    var jsonRes = JsonConvert.SerializeObject(res);

                    return Content(jsonRes, "application/json");
                }
                else
                {
                    var error = new
                    {
                        title = "Invalid Credentials",
                        message = "The Submitted Login Credentials are Invalid"
                    };

                    return BadRequest(error);

                }
            }

            var invalidCredentials = new
            {
                title = "Invalid Credentials",
                message = "The Submitted Login Credentials are Invalid"
            };

            return BadRequest(invalidCredentials);
        }

    }
}