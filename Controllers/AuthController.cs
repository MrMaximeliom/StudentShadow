using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentShadow.Helpers;
using StudentShadow.Models;
using StudentShadow.Services;

namespace StudentShadow.Controllers
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
        public async Task<IActionResult> RegisterAsync(CustomUser model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterAsync(model);

            if(!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);

        }
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);

        }
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.AddRoleAsync(model);

            Console.WriteLine("result is " +$"{ result}");

            if(!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);    
            }
            return Ok(model);

        }

    }
}
