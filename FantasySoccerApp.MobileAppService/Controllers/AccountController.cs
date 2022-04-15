using System.Threading.Tasks;
using FantasySoccerApp.MobileAppService.Models;
using FantasySoccerApp.MobileAppService.Services.Interfaces;
using FantasySoccerApp.MobileAppService.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FantasySoccerApp.MobileAppService.Models.Accounts;
using System.Net;
using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<AspNetUsers> userManager,
            IAccountService accountService)
        {
            _userManager = userManager;
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(UserModel request)
        {
            var validation = await _accountService.IsRegistrationValidAsync(request);

            if (validation.IsValid != true)
            {
                return StatusCode(422, validation);
            }

            AspNetUsers identityUser = new AspNetUsers()
            {
                UserName = request.Email,
                Email = request.Email
            };
            var result = await _userManager.CreateAsync(identityUser, request.Password);

            if (result.Succeeded)
            {
                identityUser = await _userManager.FindByEmailAsync(request.Email);

                await _userManager.AddToRoleAsync(identityUser, UserRoles.Roles.Standard.ToString());

                _accountService.InsertUser(request);

                var token = _accountService.CreateBearerToken(DateTime.Now.AddDays(14));
                return Ok(token);
            }
            else
            {
                return BadRequest("Unable to create user");
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserModel request)
        {
            var validation = await _accountService.IsLoginValidAsync(request);

            if (validation.IsValid != true)
            {
                return StatusCode(422, validation);
            }

            //TODO: Log login attempt

            var token = _accountService.CreateBearerToken(DateTime.Now.AddDays(14));
            return Ok(token);
        }
    }
}