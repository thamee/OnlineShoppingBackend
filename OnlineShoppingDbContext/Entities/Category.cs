using OnlineShoppingDbContext.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShoppingDbContext.Entities
{
    public class Category : BaseEntity
    {

        [Required]
        public string Name { get; set; }

    }
}
