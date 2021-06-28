using Microsoft.AspNetCore.Mvc;
using OnlinePortal.Api.Services.Categories;
using OnlineShoppingDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Controllers
{
    public class MasterDataController : Controller
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Constructor of ProductController
        /// </summary>
        /// <param name="categoryService"></param>
        /// <param name="logger"></param>
        public MasterDataController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// The API endpoint to create products
        /// </summary>
        /// <param name="bulkClient">client</param>
        /// <returns>Created client</returns>
        [HttpGet("categories")]
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categoryService.GetCategoriesAsync();
        }
    }
}

