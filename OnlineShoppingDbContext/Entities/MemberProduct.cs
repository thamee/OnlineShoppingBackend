using OnlineShoppingDbContext.Entities.Base;
using OnlineShoppingDbContext.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShoppingDbContext.Entities
{
    public class MemberProduct : BaseEntity
    {

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public bool IsOrdered { get; set; }


        public Product Product { get; set; }

    }
}
