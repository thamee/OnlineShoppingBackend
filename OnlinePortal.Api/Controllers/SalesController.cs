using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlinePortal.Api.Extensions;
using OnlinePortal.Api.Models.Sales;
using OnlinePortal.Api.Services.Sales;
using OnlineShoppingDbContext.Entities;
using OnlineShoppingDbContext.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Controllers
{
    public class SalesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISalesService _salesService;




        public SalesController(UserManager<ApplicationUser> userManager, ISalesService salesService)
        {
            _userManager = userManager;
            _salesService = salesService;
        }

        [HttpPost("sales")]
        [Authorize]
        public async Task<int> CreateSalesAsync([FromBody] CreateSalesDto sales)
        {
            var userId = User.GetId();
            return await _salesService.CreateSalesAsync(sales, userId);
        }

        [HttpGet("sales")]
        [Authorize]
        public async Task<List<MemberProduct>> GetSalesAsync()
        {
            var userId = User.GetId();
            return await _salesService.GetOrderedItems(userId);
        }


        [HttpPost("order")]
        [Authorize]
        public async Task<int> OrderSalesAsync()
        {
            var userId = User.GetId();
            return await _salesService.ConformOrderedItems(userId);
        }


       
    }
}
