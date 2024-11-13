using Microsoft.Extensions.Configuration;
using MyCrudApp.Application.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyCrudApp.Application.Interfaces
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration _config);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config);
        Task<ResponseLoginDTO> LoginAsync(LoginModelDTO model);
        Task<ResponseDTO> RegisterAsync(RegisterModelDTO model);
        Task<ResponseLoginDTO> RefreshTokenAsync(TokenModelDTO tokenModel);
        Task RevokeTokenAync(string userName);
    }
}
