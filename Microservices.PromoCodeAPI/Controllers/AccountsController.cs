﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microservices.PromoCodeAPI.Models;
using Microservices.PromoCodeAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Microservices.PromoCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<PromoCodeUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _appsettings;

        public AccountsController(UserManager<PromoCodeUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _appsettings = _configuration.GetSection("AppSettings");
        }

        [Authorize]
        [HttpGet]
        public string GetAll()
        {
            return "Congrat you did it!";
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto model)
        {
            var newUser = new PromoCodeUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = true
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResponseDto{ Errors = errors });
            }
            return Ok(new RegisterResponseDto { Success = true });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { Message = "Invalid Authentication" });

            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            user.RefreshToken = GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(2);

            await _userManager.UpdateAsync(user);

            return Ok(new AuthResponseDto { IsSuccess = true, Token = token, RefreshToken = user.RefreshToken });
        }

        #region To Seperate To New Repo
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_appsettings.GetSection("JwtSecurityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(PromoCodeUser user)
        {
            var claims = new List<Claim>{new Claim(ClaimTypes.Name, user.Email)};

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