using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using CoreJWTExample.Helpers;
using Microservices.Shared;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Microservices.eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly SignInManager<eVoucherUser> _signInManager;

        public LoginController(AppSettings appSettings, SignInManager<eVoucherUser> signInManager)
        {
            _appSettings = appSettings;
            _signInManager = signInManager;
        }
        // POST: api/login
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var result = await _signInManager
                .PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
                return BadRequest();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, model.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtSecurityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expire = DateTime.UtcNow.AddDays(_appSettings.JwtExpiryInDays);

            var token = new JwtSecurityToken(
                _appSettings.JwtIssuer,
                _appSettings.JwtAudience,
                claims,
                expires: expire,
                signingCredentials: credentials);

            return Ok(new { 
                Successful = true, 
                Token = new JwtSecurityTokenHandler().WriteToken(token) 
            });
        }
    }
}
