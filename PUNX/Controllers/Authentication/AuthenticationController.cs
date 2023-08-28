using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PUNX.Domain.DTOs;
using PUNX.Domain.Repository.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace PUNX.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthenticationController> _logger;


        public AuthenticationController(IJwtAuthenticationService JwtAuthenticationService, IConfiguration config, ILogger<AuthenticationController> logger)
        {
            _jwtAuthenticationService = JwtAuthenticationService;
            _config = config;
            _logger = logger;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginModel)
        {

                var user = await _jwtAuthenticationService.Authenticate(loginModel.Name, loginModel.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                    };
                    var token = _jwtAuthenticationService.GenerateToken(_config["Jwt:Key"], claims);

                    return Ok(token);
                }

            return Unauthorized(new { message = "Authentication failed: Invalid credentials." });
        }
    }
}
