using OnlinePortal.Api.Models.Sales;
using OnlineShoppingDbContext.Entities;
using OnlineShoppingDbContext.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Services.Sales
{
    public interface ISalesService
    {
        Task<int> CreateSalesAsync(CreateSalesDto sales, string userId);
        Task<List<MemberProduct>> GetOrderedItems(string userId);
        Task<int> ConformOrderedItems(string userId);
    }
}
