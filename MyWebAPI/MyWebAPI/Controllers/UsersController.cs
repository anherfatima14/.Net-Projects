using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MyWebAPI.Models;
using MyWebAPI.Provider;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserProvider _userProvider;

        public UsersController(IUserProvider userProvider)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.PasswordHash))
                return BadRequest("User object, email, and password are required.");

            try
            {
                await _userProvider.RegisterUserAsync(user);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Email and password are required.");

            try
            {
                var token = await _userProvider.AuthenticateUserAsync(request.Email, request.Password);
                if (token == null)
                    return Unauthorized("Invalid email or password.");

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
