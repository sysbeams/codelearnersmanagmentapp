using Application.Contracts.Services;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILogInService loginService) : ControllerBase
    {
        private readonly ILogInService _logInService = loginService;

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LoginRequest loginRequest)
        {
            var response = await _logInService.Login(loginRequest);
            return Ok(response);
        }
    }
}
