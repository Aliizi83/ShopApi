using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Auth;
using Shop.Application.Interfaces.Auth;

namespace Shop.Api.Controllers._V1.Auth
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1")]
    [ApiController]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = _loginService.Login(request);

                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new { Message = e.Message });
            }
        }
    }
}
