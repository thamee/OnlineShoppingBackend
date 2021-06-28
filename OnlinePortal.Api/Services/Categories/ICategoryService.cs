using OnlineShoppingDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Services.Categories
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryAsync(int id);

        Task<List<Category>> GetCategoriesAsync();
    }
}
