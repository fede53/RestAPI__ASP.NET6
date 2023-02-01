using Cube.RestApi.Models.DTO;
using Cube.RestApi.Repositories;
using Cube.RestApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cube.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository authRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IAuthRepository authRepository, ITokenHandler tokenHandler)
        {
            this.authRepository = authRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO loginRequest)
        {
            var user = await authRepository.AuthenticateAsync(
                loginRequest.Email, loginRequest.Password);

            if (user != null)
            {
                var token = await tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("Username or Password is incorrect.");
        }
    }
}
