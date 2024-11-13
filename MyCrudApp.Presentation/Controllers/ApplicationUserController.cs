using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCrudApp.Application.DTOs;
using MyCrudApp.Application.Interfaces;

namespace MyCrudApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public ApplicationUserController(ITokenService tokenService) 
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseLoginDTO>> Login([FromBody] LoginModelDTO model)
        {
            try
            {
                var responseLogin = await _tokenService.LoginAsync(model);
                return Ok(responseLogin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterModelDTO registerModel)
        {
            var response = await _tokenService.RegisterAsync(registerModel);
            if (response.Status.Equals("error", StringComparison.OrdinalIgnoreCase))
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            return Ok(response);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<ActionResult<ResponseLoginDTO>> RefreshToken(TokenModelDTO tokenModel)
        {
            try
            {
                var responseLogin = await _tokenService.RefreshTokenAsync(tokenModel);
                return Ok(responseLogin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<ActionResult> Revoke(string username)
        {
            await _tokenService.RevokeTokenAync(username);
            return NoContent();
        }
    }
}
