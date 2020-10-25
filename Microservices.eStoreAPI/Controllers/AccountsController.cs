using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.Shared;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<eVoucherUser> _userManager;

        public AccountsController(UserManager<eVoucherUser> userManager)
        {
            _userManager = userManager;
        }

        // POST: api/accounts
        [HttpPost]
        public async Task<ActionResult> Register(UserRegisterVM model)
        {
            var newUser = new eVoucherUser
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
                //get errors and return
            }
            return Ok(new { Success = true });
        }
    }
}
