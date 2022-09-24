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

        string ADMIN_ROLE = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Admin",
            NormalizedName = "ADMIN",
            Id = ADMIN_ROLE,
            ConcurrencyStamp = ADMIN_ROLE
        });

        string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";

        var newAdmin = new IdentityUser
        {
            Id = ADMIN_ID,
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            EmailConfirmed = true,
            UserName = "Admin",
            NormalizedUserName = "ADMIN"
        };

        PasswordHasher<IdentityUser> ph4 = new PasswordHasher<IdentityUser>();
        newAdmin.PasswordHash = ph4.HashPassword(newAdmin, "12345");

        builder.Entity<IdentityUser>().HasData(newAdmin);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = ADMIN_ROLE,
            UserId = ADMIN_ID
        });

        builder.Entity<Category>().HasData(new Category
        {
            Id = 1,
            Name = "Proteina",
            ShortDescription = "Recuperacion muscular",
        });

        builder.Entity<Category>().HasData(new Category
        {
            Id = 2,
            Name = "Creatina",
            ShortDescription = "Se utiliza para mejorar el rendimiento del ejercicio",
        });

        builder.Entity<Category>().HasData(new Category
        {
            Id = 3,
            Name = "Prework",
            ShortDescription = "Se toma para aumentar la resistencia, la energía y la concentración durante un entrenamiento",
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Name = "Creatina Star",
            Description = "300g",
            Price = 8000,
            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.hln.com.ar%2Fproductos%2Fcreatina-monohidrato-300-grs-star-nutrition%2F&psig=AOvVaw3uY-qNqzTqO9GJMDKADHn2&ust=1664115334639000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCOCKlObOrfoCFQAAAAAdAAAAABAh",
            CategoryId = 2
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 2,
            Name = "Creatina ultra tech",
            Description = "300g",
            Price = 9200,
            ImageUrl = "https://farmaciassanchezantoniolli.com.ar/6136-large_default/ultra-tech-creatine-suplemento-deportivo-creatina-x-300g.jpg",
            CategoryId = 2
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 3,
            Name = "Pump V8 Star",
            Description = "285g",
            Price = 3500,
            ImageUrl = "https://titansport.com.ar/wp-content/uploads/2021/02/Pump-v8.png",
            CategoryId = 3
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 4,
            Name = "Cellucor C4",
            Description = "60 servicios",
            Price = 20400,
            ImageUrl = "http://d2r9epyceweg5n.cloudfront.net/stores/001/614/635/products/c4-cellucor-x-601-4b61cb1d3db2b8262f16299857991074-640-0.jpg",
            CategoryId = 3
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 5,
            Name = "Whey Protein Star",
            Description = "30 servicios, sabor chocolate",
            Price = 5200,
            ImageUrl = "https://www.demusculos.com/shop/24-medium_default/proteina-premium-whey-protein-2-lbs-star-nutrition.jpg",
            CategoryId = 1
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 6,
            Name = "Whey Protein Truemade Ena",
            Description = "30 servicios, sabor chocolate",
            Price = 5300,
            ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_812835-MLA50418167124_062022-O.webp",
            CategoryId = 1
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 7,
            Name = "Whey Protein X-Pro Ena",
            Description = "30 servicios, sabor vainilla",
            Price = 7500,
            ImageUrl = "https://www.farmacialeloir.com.ar/img/articulos/2021/09/ena_whey_x_pro_complex_protein_1_imagen2.jpg",
            CategoryId = 1
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 8,
            Name = "Creatina Universal",
            Description = "200g",
            Price = 12000,
            ImageUrl = "https://d2r9epyceweg5n.cloudfront.net/stores/001/740/999/products/creatina-universal-200-g1-e8c56af1b6e101139116242981241414-1024-1024.jpg",
            CategoryId = 2
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 9,
            Name = "Proteina Ultratech",
            Description = "1kg, sabor chocolate",
            Price = 12000,
            ImageUrl = "http://d3ugyf2ht6aenh.cloudfront.net/stores/001/040/363/products/chocolate1-369cf71a9add07c4fa16207447748528-640-01-150d24b78c045c676916500317383129-640-0.jpg",
            CategoryId = 1
        });

        builder.Entity<Product>().HasData(new Product
        {
            Id = 10,
            Name = "Creatina Nutrilab",
            Description = "300g",
            Price = 3000,
            ImageUrl = "http://d3ugyf2ht6aenh.cloudfront.net/stores/001/533/270/products/28-4-crea-shock-181-c3a33f165bc143986116214473685261-640-0.jpg",
            CategoryId = 2
        });
    }
}
