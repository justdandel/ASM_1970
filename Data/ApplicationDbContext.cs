using ASM_1670.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM_1670.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedAuthor(builder);
            SeedCategory(builder);
            SeedBook(builder);

        }

        private void SeedAuthor(ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Vu Trong Phung",
                    Description = "Nha van",
                    Img = "https://scov.gov.vn/upload/2005660/20210923/f23556e10437237abbc3f8bfb90fdb26103019_vutrongphung1.jpg",
                    Dob = DateTime.Parse("1912-10-20")
                },

                new Author
                {
                    Id = 2,
                    Name = "Nguyen Nhat Anh",
                    Description = "Nha Van, Nha Tho",
                    Img = "https://vcdn1-giaitri.vnecdn.net/2022/01/14/nguyen-nhat-anh-1-2072-1642148269.jpg?w=0&h=0&q=100&dpr=2&fit=crop&s=u_S5CzqaxPrA51GZ4VCVPg",
                    Dob = DateTime.Parse("1955-05-07")
                }
                );
        }

        private void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Satire"
                },

                new Category
                {
                    Id = 2,
                    Name = "Romance"
                }
                );
        }

        private void SeedBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
               new Book
               {
                   Id = 1,
                   Name = "Lam DI",
                   AuthorId = 1,
                   CategoryId = 1
               },

               new Book
               {
                   Id = 2,
                   Name = "So Do",
                   AuthorId = 1,
                   CategoryId = 1
               },

               new Book
               {
                   Id = 3,
                   Name = "Mat Biec",
                   AuthorId = 2,
                   CategoryId = 2
               }
                ); 
        }
    }
}
