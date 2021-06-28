using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Models.Product
{
    public class UpdateProductDto
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Category 
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Price 
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// Model 
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Color 
        /// </summary>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// Product Image
        /// </summary>
        public string Image { get; set; }

        public bool IsOutOfStock { get; set; }

    }
}
