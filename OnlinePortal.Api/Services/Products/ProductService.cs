using Microsoft.EntityFrameworkCore;
using OnlinePortal.Api.Exceptions;
using OnlinePortal.Api.Extensions;
using OnlinePortal.Api.Models.Product;
using OnlinePortal.Api.Services.Categories;
using OnlineShoppingDbContext;
using OnlineShoppingDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Services.Products
{
    public class ProductService:IProductService
    {
        private readonly ApplicationDbContext _onlinePortalContext;
        private readonly ICategoryService _categoryService;
        public ProductService(ApplicationDbContext dataContext, ICategoryService categoryService)
        {
            _onlinePortalContext = dataContext;
            _categoryService = categoryService;
        }
        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<int> CreateProductAsync(CreateProductDto product)
        {

            if (product == null || string.IsNullOrEmpty(product?.Name)) // checks Product valid
                throw new BadRequestException("Can't Create Product");

            if (IsExists(product))
                throw new BadRequestException("The Product already exists with the same name");

            var category = await _categoryService.GetCategoryAsync(product.CategoryId);

            if (category == null)
                throw new NotFoundException("The Associate Category Not found with requested Identifier!");



            var productEntity = product.ToEntityModel(category); // change as entity
            productEntity.SetCreatedTime(); // Set Created time
            productEntity.SetActivated(true); // Set the Client as active client initially
            await _onlinePortalContext.Products.AddAsync(productEntity);
            await _onlinePortalContext.SaveChangesAsync();     // create client           

            return 1; 
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _onlinePortalContext.Products.Include(p=>p.Category).ToListAsync();

           
        }

        


        private bool IsExists(CreateProductDto product)
        {
            var alreadyExists = _onlinePortalContext.Products.Select(x => x.Name).ToList();
            return alreadyExists.Contains(product.Name);
        }

        private bool IsOtherExists(UpdateProductDto product)
        {
            var alreadyExists = _onlinePortalContext.Products.Where(x=>x.Id != product.Id).Select(x => x.Name ).ToList();
            return alreadyExists.Contains(product.Name);
        }

        public async Task<int> UpdateProductAsync(UpdateProductDto product)
        {

            if (product == null || string.IsNullOrEmpty(product?.Name)) // checks Product valid
                throw new BadRequestException("Can't Create Product");

            if (IsOtherExists(product))
                throw new BadRequestException("The Product already exists with the same name");

            var category = await _categoryService.GetCategoryAsync(product.CategoryId);

            if (category == null)
                throw new NotFoundException("The Associate Category Not found with requested Identifier!");

            var productToUpdate = await GetProductAsync(product.Id);

            var productEntity = product.ToEntityModel(productToUpdate, category); 


            _onlinePortalContext.Products.Update(productEntity);
            await _onlinePortalContext.SaveChangesAsync();     

            return 1;
        }
        public async Task<Product> GetProductAsync(int id)
        {

            //Get the staff who matches with given Id
            var product = await _onlinePortalContext.Products
                                                    .Include(s => s.Category) // includes the category of the product
                                                    .SingleOrDefaultAsync(s => s.Id == id);
            if (product == null)
            {
                throw new NotFoundException($"The Staff not found for requested Identifier");
            }

            return product;
        }

        public async Task<int> DeleteProductAsync(int id)
        {

            //Get the staff who matches with given Id
            var product = await _onlinePortalContext.Products
                                                    .SingleOrDefaultAsync(s => s.Id == id);
            if (product == null)
            {
                throw new NotFoundException($"The Staff not found for requested Identifier");
            }
            _onlinePortalContext.Remove(product);
            await _onlinePortalContext.SaveChangesAsync();

            return 1;
        }

    }
}
