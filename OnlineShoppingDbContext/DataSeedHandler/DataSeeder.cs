using Microsoft.EntityFrameworkCore;
using OnlineShoppingDbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShoppingDbContext.DataSeedHandler
{
    public class DataSeeder
    {
        public static void SeedCategories(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var countries = new List<Category>
            {
                new Category { Name = "MobilePhone" },
                new Category { Name = "Electonic Items" },
                new Category { Name = "Television" },
                new Category { Name = "Furnitures" },
                new Category { Name = "Toys" },
                new Category { Name = "Vegetables" },
                new Category { Name = "Head Phone" },
                new Category { Name = "Books" },
                new Category { Name = "Laptop" },
               
            };
                context.Categories.AddRange(countries);
                context.SaveChanges();
            }
        }

       
    }
}
