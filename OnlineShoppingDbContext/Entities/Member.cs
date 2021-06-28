using OnlineShoppingDbContext.Entities.Base;
using OnlineShoppingDbContext.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShoppingDbContext.Entities
{
    public class Member : BaseEntity
    {

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public ApplicationUser user;




    }
}
