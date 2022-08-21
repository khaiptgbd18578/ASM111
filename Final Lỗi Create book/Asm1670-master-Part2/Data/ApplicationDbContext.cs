using Asm1670.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asm1670.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedCategory(builder);
            SeedBook(builder);
            SeedAuthor(builder);
            SeedUser(builder);
            SeedRole(builder);
            SeedUserRole(builder);
        }
        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "1"
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "2"
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "3"
                }
            );
        }
        private void SeedRole(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "Admin"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Customer",
                    NormalizedName = "Customer"
                },
                new IdentityRole
                {
                    Id ="3",
                    Name = "Store Owner",
                    NormalizedName = "Store Owner"
                }
            );
        }
        private void SeedUser(ModelBuilder builder)
        {
            //tạo tài khoản test cho admin & customer
            var admin = new IdentityUser
            {
                Id = "1",
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com"
            };
            var customer = new IdentityUser
            {
                Id = "2",
                Email = "customer@gmail.com",
                UserName = "customer@gmail.com",
                NormalizedUserName = "customer@gmail.com"
            };
            var storeowner = new IdentityUser
            {
                Id = "3",
                Email = "storeowner@gmail.com",
                UserName = "storeowner@gmail.com",
                NormalizedUserName = "storeowner@gmail.com"
            };

            //khai báo thư viện để mã hóa mật khẩu cho user
            var hasher = new PasswordHasher<IdentityUser>();

            //set mật khẩu đã mã hóa cho từng user
            admin.PasswordHash = hasher.HashPassword(admin, "123456");
            customer.PasswordHash = hasher.HashPassword(customer, "123456");
            storeowner.PasswordHash = hasher.HashPassword(storeowner, "123456");

            //add 2 tài khoản test vào bảng User
            builder.Entity<IdentityUser>().HasData(admin, customer, storeowner);
        }
        
        private void SeedBook(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Doraemon", Description= "comic", Image= "https://img.freepik.com/free-psd/book-cover-mockup_125540-572.jpg?w=996&t=st=1660985940~exp=1660986540~hmac=7314f1b2a83b26dae6b7500ddf4975192bb4aecb8e5373545ec253baf16eb2e5", Quantity = 10, Price = 13000, CategoryId = 2, AuthorId = 1 },
                new Book { Id = 2, Name = "Doraemon", Description = "comic", Image = "https://img.freepik.com/free-psd/book-cover-mockup_125540-572.jpg?w=996&t=st=1660985940~exp=1660986540~hmac=7314f1b2a83b26dae6b7500ddf4975192bb4aecb8e5373545ec253baf16eb2e5", Quantity = 10, Price = 13000, CategoryId = 2, AuthorId = 2 },
                new Book { Id = 3, Name = "Doraemon", Description = "comic", Image = "https://img.freepik.com/free-psd/book-cover-mockup_125540-572.jpg?w=996&t=st=1660985940~exp=1660986540~hmac=7314f1b2a83b26dae6b7500ddf4975192bb4aecb8e5373545ec253baf16eb2e5", Quantity = 10, Price = 13000, CategoryId = 2, AuthorId = 3 }
            );
        }
        private void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Entertainment" },
                new Category { Id = 2, CategoryName = "History" },
                new Category { Id = 3, CategoryName = "Romance" }
                );
        }
        private void SeedAuthor(ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(
                new Author { Id = 1, AuthorName = "Nguyen Trai" },
                new Author { Id = 2, AuthorName = "Nguyen Du" },
                new Author { Id = 3, AuthorName = "Nam Cao" }
                );
        }
    }
}
