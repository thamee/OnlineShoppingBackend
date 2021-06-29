using Microsoft.AspNetCore.Mvc;
using OnlinePortal.Api.Models.Identity;
using OnlinePortal.Api.Services.Identity;
using OnlineShoppingDbContext.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Controllers
{
    public class IdentityController : Controller
    {

        private readonly IIdentityService _identityService;


        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
       

        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterStaff([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponce
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                Id = Guid.NewGuid().ToString()
        };
            var authResponce = await _identityService.RegisterUserAsync(request);
            if (!authResponce.Status)
            {
                return BadRequest(new AuthFailedResponce
                {
                    Errors = authResponce.Errors
                });
            }

            return Ok(new AuthSuccessResponce
            {
                Token = authResponce.Token,
                RefreshToken = authResponce.RefreshToken
            });
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponce
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var authResponce = await _identityService.LoginAsync(request);

            if (!authResponce.Status)
            {
                return BadRequest(new AuthFailedResponce
                {
                    Errors = authResponce.Errors
                });
            }

            return Ok(new AuthSuccessResponce
            {
                Token = authResponce.Token,
                RefreshToken = authResponce.RefreshToken
            });
        }

        [HttpPost("registerSellers")]
        public async Task<ActionResult> RegisterSellers([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponce
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                Id = Guid.NewGuid().ToString()
            };
            var authResponce = await _identityService.RegisterSellersAsync(request);
            if (!authResponce.Status)
            {
                return BadRequest(new AuthFailedResponce
                {
                    Errors = authResponce.Errors
                });
            }

            return Ok(new AuthSuccessResponce
            {
                Token = authResponce.Token,
                RefreshToken = authResponce.RefreshToken
            });
        }
        }
    
}
