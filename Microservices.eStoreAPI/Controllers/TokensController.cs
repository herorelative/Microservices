using Microservices.DataAccess;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly UserManager<eVoucherUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _appsettings;

        public TokensController(UserManager<eVoucherUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _appsettings = _configuration.GetSection("AppSettings");
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenVM tokenDto)
        {
            if (tokenDto is null)
            {
                return BadRequest(new LoginResult { Success = false, Error = "Invalid client request" });
            }
            var principal = GetPrincipalFromExpiredToken(tokenDto.Token);
            var username = principal.Identity.Name;
            var user = await _userManager.FindByEmailAsync(username);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest(new LoginResult { Success = false, Error = "Invalid client request" });
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            user.RefreshToken = GenerateRefreshToken();
            await _userManager.UpdateAsync(user);
            return Ok(new LoginResult { Token = token, RefreshToken = user.RefreshToken, Success = true });
        }

        #region To Seperate To New Repo
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_appsettings.GetSection("JwtSecurityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private List<Claim> GetClaims(eVoucherUser user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _appsettings.GetSection("JwtIssuer").Value,
                audience: _appsettings.GetSection("JwtAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_appsettings.GetSection("JwtExpiryInMinutes").Value)),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_appsettings.GetSection("JwtSecurityKey").Value)),
                ValidateLifetime = false,
                ValidIssuer = _appsettings.GetSection("JwtIssuer").Value,
                ValidAudience = _appsettings.GetSection("JwtAudience").Value,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
        #endregion
    }
}
