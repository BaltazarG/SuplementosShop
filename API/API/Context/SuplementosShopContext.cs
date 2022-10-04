using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Context;

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

        string CUSTOMER_ROLE = "59973da1-dd11-46d7-88ed-ad93819d2f85";
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Customer",
            NormalizedName = "CUSTOMER",
            Id = CUSTOMER_ROLE,
            ConcurrencyStamp = CUSTOMER_ROLE
        });

        string CUSTOMER_ID = "563bcc80-16ed-4f79-83d4-ed3fe59a933c";

        var newCustomer = new IdentityUser
        {
            Id = CUSTOMER_ID,
            Email = "customer@gmail.com",
            NormalizedEmail = "CUSTOMER@GMAIL.COM",
            EmailConfirmed = true,
            UserName = "Customer",
            NormalizedUserName = "CUSTOMER"
        };

        PasswordHasher<IdentityUser> ph3 = new PasswordHasher<IdentityUser>();
        newCustomer.PasswordHash = ph3.HashPassword(newCustomer, "12345");

        builder.Entity<IdentityUser>().HasData(newCustomer);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = CUSTOMER_ROLE,
            UserId = CUSTOMER_ID
        });

        builder.Entity<Cart>().HasData(new Cart
        {
            UserId = CUSTOMER_ID,
            Id = 1,
        });


        string EMPLOYEE_ROLE = "e6c36ff5-f673-4745-bf9d-7b321388ed38";
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Employee",
            NormalizedName = "EMPLOYEE",
            Id = EMPLOYEE_ROLE,
            ConcurrencyStamp = EMPLOYEE_ROLE
        });

        string EMPLOYEE_ID = "0fbd4a36-8062-42af-912e-fa22aa808bbf";

        var newEmployee = new IdentityUser
        {
            Id = EMPLOYEE_ID,
            Email = "employee@gmail.com",
            NormalizedEmail = "EMPLOYEE@GMAIL.COM",
            EmailConfirmed = true,
            UserName = "Employee",
            NormalizedUserName = "EMPLOYEE"
        };

        PasswordHasher<IdentityUser> ph2 = new PasswordHasher<IdentityUser>();
        newEmployee.PasswordHash = ph2.HashPassword(newEmployee, "12345");

        builder.Entity<IdentityUser>().HasData(newEmployee);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = EMPLOYEE_ROLE,
            UserId = EMPLOYEE_ID
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
            Id = 11,
            Name = "Iso Whey Ripped Star",
            Description = "30 servicios",
            Price = 8000,
            ImageUrl = "data:image/jpeg;base64,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",
            CategoryId = 1
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