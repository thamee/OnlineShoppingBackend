using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlinePortal.Api.Models.Product;
using OnlinePortal.Api.Services.Products;
using OnlineShoppingDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

      
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

       
        [HttpPost("product")]
        [Authorize]
        public async Task<int> CreateProductsAsync([FromBody] CreateProductDto product)
        {
                return await _productService.CreateProductAsync(product);
        }

        [HttpGet("products")]
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productService.GetAllProductsAsync();
        }

        [HttpGet("products/{id}")]
        public async Task<Product> GetProductAsync(int Id)
        {
            return await _productService.GetProductAsync(Id);
        }

        [HttpPatch("products/{id}")]
        [Authorize]
        public async Task<int> UpdateProductAsync([FromBody] UpdateProductDto product)
        {
            return await _productService.UpdateProductAsync(product);
        }

        [HttpDelete("products/{id}")]
        [Authorize]
        public async Task<int> DeleteProductAsync(int Id)
        {
            return await _productService.DeleteProductAsync(Id);
        }
    }
}
