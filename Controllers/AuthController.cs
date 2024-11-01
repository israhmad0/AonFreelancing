using AonFreelancing.Models;
using AonFreelancing.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AonFreelancing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegRequest Req)
        {
            // Register User
            User u = new User {
                Name = Req.Name,
                UserName = Req.Username,
                PhoneNumber = Req.PhoneNumber
            };

            var User = await _userManager.CreateAsync(u, Req.Password);
            // Return
            return Ok("Registered");
        }
    }
}
