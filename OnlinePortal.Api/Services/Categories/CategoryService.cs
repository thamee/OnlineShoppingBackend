using Microsoft.EntityFrameworkCore;
using OnlinePortal.Api.Exceptions;
using OnlineShoppingDbContext;
using OnlineShoppingDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Services.Categories
{
    public class CategoryService: ICategoryService
    {
        private readonly ApplicationDbContext _onlinePortalContext;
        public CategoryService(ApplicationDbContext dataContext)
        {
            _onlinePortalContext = dataContext;
        }

        /// <summary>
        /// Get Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryAsync(int id)
        {

            //Get the Category who matches with given Id
            var category = await _onlinePortalContext.Categories
                                                    .SingleOrDefaultAsync(s => s.Id == id);
            if (category == null)
            {
                throw new NotFoundException($"The Category not found for requested Identifier");
            }

            return category;
        }


        /// <summary>
        /// Get Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Category>> GetCategoriesAsync()
        {
            //Get the Category who matches with given Id
            var categories = await _onlinePortalContext.Categories.ToListAsync();
            return categories;
        }

       
    }
}
