using OnlinePortal.Api.Models.Product;
using OnlineShoppingDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Extensions
{
    public static class ProductExtension
    {

        /// <summary>
        /// The Method to convert Dto model as Entity model
        /// </summary>
        /// <param name="createModel"></param>
        /// /// <param name="category"></param>
        /// <returns></returns>
        public static Product ToEntityModel(this CreateProductDto createModel, Category category)
        {
            // Create new instance of entity and populate Dto model value into entity model then return it
            return new Product()
            {
                Name = createModel.Name,
                Category = category,
                Price = createModel.Price,
                Color = createModel.Color,
                Model = createModel.Model,
                IsOutOfStock = createModel.IsOutOfStock



            };
        }

        
        public static void SetActivated(this Product product, bool state)
        {
            product.IsActive = state;
        }

        public static Product ToEntityModel(this UpdateProductDto updateModel, Product product, Category category)
        {
            //populate Dto model value into entity model
            product.Name = updateModel.Name;
            product.Category = category;
            product.Color = updateModel.Color;
            product.Price = updateModel.Price;
            product.Model = updateModel.Model;
            product.IsOutOfStock = updateModel.IsOutOfStock;
            return product;// Return product entity
        }



    }
}
