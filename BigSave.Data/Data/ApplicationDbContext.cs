using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BigSave.Core.Entities;
using System;
using System.Collections.Generic;
namespace BigSave.Data.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flyer>().HasIndex(s => s.Url).IsUnique();
            modelBuilder.Entity<Cart>().HasIndex(s => s.UserName).IsUnique();
            modelBuilder.Entity<Wishlist>().HasIndex(s => s.UserName).IsUnique();
            modelBuilder.Entity<Merchant>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Menu>().HasIndex(c => c.Name).IsUnique();
            // modelBuilder.Entity<CategoryInMerchant>()
            //              .HasKey(e => new { e.CategoryId, e.MerchantId });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<FlyerCategory>().HasData(new List<FlyerCategory>
            {
                new FlyerCategory {
                    Id = 1,
                    Name = "Groceries"
                },
                new FlyerCategory{
                    Id=2,
                    Name = "Pharmacy"
                },
                new FlyerCategory{
                    Id=3,
                    Name = "General"
                },
                new FlyerCategory{
                    Id=4,
                    Name = "Fashion"
                },
                new FlyerCategory{
                    Id=5,
                    Name = "Automotive"
                },
                new FlyerCategory{
                    Id=6,
                    Name = "Sports"
                },
                new FlyerCategory{
                    Id=7,
                    Name = "Pets"
                },
                new FlyerCategory{
                    Id=8,
                    Name = "Beauty"
                },
                 new FlyerCategory{
                    Id=9,
                    Name = "Home-Garden"
                },
                 new FlyerCategory{
                    Id=10,
                    Name = "boxing-day-ca"
                },
                 new FlyerCategory{
                    Id=11,
                    Name = "office-ca"
                },
                 new FlyerCategory{
                    Id=12,
                    Name = "specialty-ca"
                },
                new FlyerCategory{
                    Id=13,
                    Name = "baby-kids"
                },
                new FlyerCategory{
                    Id=14,
                    Name = "electronics-computers"
                }
            });

            modelBuilder.Entity<Menu>().HasData(new List<Menu>
            {
                new Menu
                {
                    Id =1,
                    Name ="Home"
                },
                 new Menu
                {
                    Id =2,
                    Name ="About"
                },
                  new Menu
                  {
                      Id = 3,
                      Name = "Service"
                  },
                   new Menu
                   {
                       Id = 4,
                       Name = "Contact"
                   },
                   new Menu
                   {
                       Id = 5,
                       Name = "Login"
                   },
                    new Menu
                    {
                        Id = 6,
                        Name = "Cart"
                    }

            });
            modelBuilder.Entity<AppRole>().HasData(new List<AppRole>
            {
                new AppRole {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole {
                    Id = 2,
                    Name = "Staff",
                    NormalizedName = "STAFF"
                },
                new AppRole {
                    Id = 3,
                    Name = "User",
                    NormalizedName = "USER"
                }
            });
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1, // primary key
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAEAACcQAAAAEKvOdqQb/eRx+WE3iCIOAnx24OhVMXmDt9CM0lts/RaP78ykRjUtE6YpiH8XBObFrg==",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new AppUser
                {
                    Id = 2, // primary key
                    UserName = "staff",
                    NormalizedUserName = "STAFF",
                    PasswordHash = "AQAAAAEAACcQAAAAEKvOdqQb/eRx+WE3iCIOAnx24OhVMXmDt9CM0lts/RaP78ykRjUtE6YpiH8XBObFrg==",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new AppUser
                {
                    Id = 3, // primary key
                    UserName = "user",
                    NormalizedUserName = "USER",
                    PasswordHash = "AQAAAAEAACcQAAAAEKvOdqQb/eRx+WE3iCIOAnx24OhVMXmDt9CM0lts/RaP78ykRjUtE6YpiH8XBObFrg==",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                }
            );
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>()
                {
                    RoleId = 1, // for admin username
                    UserId = 1  // for admin role
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 2, // for staff username
                    UserId = 2  // for staff role
                },
                new IdentityUserRole<int>()
                {
                    RoleId = 3, // for staff username
                    UserId = 3  // for staff role
                }
            );

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistProduct> WishlistProducts { get; set; }
        public DbSet<Flyer> Flyers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<FlyerCategory> FlyerCategories { get; set; }
    }
}