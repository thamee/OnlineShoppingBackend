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
        public SalesService(ApplicationDbContext onlinePortalContext)
        {
            _onlinePortalContext = onlinePortalContext;

        }

        public async Task<int> CreateSalesAsync(CreateSalesDto sales, string userId)
        {

            var product = await _onlinePortalContext.Products.SingleOrDefaultAsync(s => s.Id == sales.ProductId);
            if (product == null || string.IsNullOrEmpty(product?.Name))
                throw new BadRequestException("Can't Create Sales");

            var existingProductSale = await _onlinePortalContext.MemberProducts.Where(p => p.ProductId == sales.ProductId && p.UserId == userId && p.IsOrdered == false).SingleOrDefaultAsync();
            if (existingProductSale != null)
            {
                existingProductSale.Quantity += sales.Quantity;
                _onlinePortalContext.MemberProducts.Update(existingProductSale);

            }
            else
            {
                var salesProduct = new MemberProduct
                {
                    Product = product,
                    UserId = userId,
                    Quantity = sales.Quantity
                };
                await _onlinePortalContext.MemberProducts.AddAsync(salesProduct);
            }

            await _onlinePortalContext.SaveChangesAsync();

            return 1;
        }
        public async Task<List<MemberProduct>> GetOrderedItems(string userId)
        {
            var orders = await _onlinePortalContext.MemberProducts.Include(p=>p.Product).Where(p => p.User.Id == userId && p.IsOrdered==false).ToListAsync();
            return orders;

            }

        public async Task<int> ConformOrderedItems(string userId)
        {
            var orders = await _onlinePortalContext.MemberProducts.Where(p => p.User.Id == userId && p.IsOrdered == false).ToListAsync();
            orders.ForEach(a => a.IsOrdered = true);
            await _onlinePortalContext.SaveChangesAsync();
            return 1;

        }



    }
}
