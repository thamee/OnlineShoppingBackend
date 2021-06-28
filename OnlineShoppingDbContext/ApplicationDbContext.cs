using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingDbContext.Entities;
using OnlineShoppingDbContext.Entities.Identity;
using System;

namespace OnlineShoppingDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {

        private readonly DbContextOptions _options;
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }


        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MemberProduct> MemberProducts { get; set; }

    


    }
}
