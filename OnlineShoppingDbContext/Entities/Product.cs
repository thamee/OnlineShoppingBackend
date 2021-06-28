using OnlineShoppingDbContext.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShoppingDbContext.Entities
{
    public class Product : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Model { get; set; }


        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public bool IsOutOfStock { get; set; }
        /// <summary>
        /// Product Image
        /// </summary>
        public string Image { get; set; }


    }
}
