using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuplementosShop.Entities;

namespace SuplementosShop.Areas.Identity.Data;

public class SuplementosShopContext : IdentityDbContext<IdentityUser>
{
    public SuplementosShopContext(DbContextOptions<SuplementosShopContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Cart> Carts { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


    }
}
