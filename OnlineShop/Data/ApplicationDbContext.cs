using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineShop.Models.Domain;

namespace OnlineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<SpecialTag> SpecialTages { get; set; }
    }
}
