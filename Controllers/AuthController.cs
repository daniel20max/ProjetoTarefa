using Microsoft.AspNetCore.Mvc;

using ProjetoTarefa.Services;
using ProjetoTarefa.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.Controllers
{
    [Route("api/v1/[controller]"), ApiController]
    public class AuthController : ControllerBase
    {
        AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] Client identityUser)
        {
            try
            {
                var result = _authService.Create(identityUser).Result;
                if (result.Succeeded)
                {
                    identityUser.PasswordHash = default;
                    identityUser.SecurityStamp = default;
                    identityUser.ConcurrencyStamp = default;
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e) { return BadRequest(e.Message); };

        }

        [HttpPost]
        [Route("Token")]
        public IActionResult Token([FromBody] Client identityUser)
        {
            try
            {
                return Ok(_authService.GenerateToken(identityUser));
            }
            catch (Exception e) { return BadRequest(e.Message); };
        }

    }
}
