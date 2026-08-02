using UniversityApp.Entities;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.BLL.Interfaces;
using UniversityApp.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace UniversityApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await _authService.LoginAsync(request);
            if (response == null || string.IsNullOrEmpty(response.Token))
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
            return Ok(response);
        }
    }
}

