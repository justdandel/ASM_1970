using Assignment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PopulateCategory(builder);

            PopulateBook(builder);
        }

        private void PopulateBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "asdj",
                    CategoryID = 1,
                    Price = 30.4,
                    Edition = 2,
                    Description = "ahsufhadhsafasdhaa",
                    Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiUAaDFqobRwQ7KdQLQF3qkBYmb7rETd2TlA&usqp=CAU"
                },
                new Book
                {
                    Id = 2,
                    Name = "oiwouas",
                    CategoryID = 1,
                    Price = 99,
                    Edition = 3,
                    Description = "kjhadbfhlgsdafb saldlasdasd",
                    Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiUAaDFqobRwQ7KdQLQF3qkBYmb7rETd2TlA&usqp=CAU"
                },
                new Book
                {
                    Id = 3,
                    Name = "uhsdbhasad",
                    CategoryID = 3,
                    Price = 38,
                    Edition = 2,
                    Description = "kalhdfladhlahldf fadhfahdfaf",
                    Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiUAaDFqobRwQ7KdQLQF3qkBYmb7rETd2TlA&usqp=CAU"
                }
                );
        }

        private void PopulateCategory(ModelBuilder builder)
        {
            var Science = new Category { Id = 1, Name = "Science" };
            var Mystery = new Category { Id = 3, Name = "Mystery" };
            builder.Entity<Category>().HasData(Science, Mystery);
        }
    }
}
