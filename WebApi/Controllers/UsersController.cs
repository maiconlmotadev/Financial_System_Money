using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AddUser")]

        public async Task<IActionResult> AddUser([FromBody] Login login)
        {
            if(string.IsNullOrWhiteSpace(login.email) ||
                string.IsNullOrWhiteSpace(login.password) ||
                string.IsNullOrWhiteSpace(login.nif)
                )
            {
                return Ok("All data needs to be reported!");
            }

            var user = new ApplicationUser
            {
                Email = login.email,
                UserName = login.email,
                Nif = login.nif,
            };

            var result = await _userManager.CreateAsync(user, login.password);

            if(result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            // Creating of confirmation on success
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // Return of confirmation email 
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var response_return = await _userManager.ConfirmEmailAsync(user, code);

            if(response_return.Succeeded) 
            {
                return Ok("User added");
            }
            else
            {
                return Ok("Error registering user!");
            }
        }
    }
}
