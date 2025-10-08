using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
//using LoginRequest = eCommerce.Core.DTO.LoginRequest;
//using RegisterRequest = eCommerce.Core.DTO.RegisterRequest;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")] //api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService userService)
        {
            _usersService = userService;
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Hello Test");
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(Core.DTO.RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration Data");
            }
            AuthenticationResponse response = await _usersService.Register(registerRequest);
            if (response == null || !response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(Core.DTO.LoginRequest loginRequest)
        {
            //Check for invalid LoginRequest
            if (loginRequest == null)
            {
                return BadRequest("Invalid login data");
            }
            AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);

        }

    }
}
