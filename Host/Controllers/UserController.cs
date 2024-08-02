using Application.Contracts.Services;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
            public UserController(IUserService userService) => _userService = userService;

        [HttpPost("Authentication")]
        [OpenApiOperation("Login", "")]
        public async Task<IActionResult> LogIn(LoginRequest loginRequest)
        {
            var response = await _userService.Login(loginRequest);
            return Ok(response);
        }
    }
}
