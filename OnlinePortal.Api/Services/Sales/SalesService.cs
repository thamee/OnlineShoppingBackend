using Microsoft.EntityFrameworkCore;
using OnlinePortal.Api.Exceptions;
using OnlinePortal.Api.Models.Sales;
using OnlineShoppingDbContext;
using OnlineShoppingDbContext.Entities;
using OnlineShoppingDbContext.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Services.Sales
{
    public class SalesService : ISalesService
    {
        private readonly ApplicationDbContext _onlinePortalContext;
        public  SalesService(ApplicationDbContext onlinePortalContext)
        {
            _onlinePortalContext = onlinePortalContext;

            }

        public async Task<int> CreateSalesAsync(CreateSalesDto sales, ApplicationUser user)
        {

            var product = await _onlinePortalContext.Products.SingleOrDefaultAsync(s => s.Id == sales.ProductId);
            if (product == null || string.IsNullOrEmpty(product?.Name)) // checks Product valid
                throw new BadRequestException("Can't Create Sales");
            var salesProduct = new MemberProduct
            {
                Product = product,
                User = user,
                Quantity = sales.Quantity
            };
            await _onlinePortalContext.MemberProducts.AddAsync(salesProduct);
            await _onlinePortalContext.SaveChangesAsync();

            return 1;
        }
    }
}
