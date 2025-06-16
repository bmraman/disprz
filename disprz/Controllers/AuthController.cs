using disprz.Model;
using disprz.Model.DTOs;
using disprz.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace disprz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IService _service;

        public AuthController(IService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            await _service.RegisterAsync(user, user.PasswordHash);
            return Ok("Registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest req)
        {
            var token = await _service.AuthenticateAsync(req.Email, req.Password);
            if (token == null) return Unauthorized("Invalid credentials");

            return Ok(new { Token = token });
        }
    }
}
