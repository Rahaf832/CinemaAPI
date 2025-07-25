using CinemaAPI.Services.Interfaces;
using CinemaAPI.DTO.UserDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegister)
        {
            var token =await _authService.Register(userRegister);
            return Ok(new { message = "Registered successfully", token });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            var token =await _authService.Login(userLogin);
            return Ok(new { message = "Logined in successfully", token });
        }
    }
}
