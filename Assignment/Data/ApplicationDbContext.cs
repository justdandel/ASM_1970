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
        public DbSet<Author> authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PopulateCategory(builder);
            PopulateAuthor(builder);

            PopulateBook(builder);

        }

        private void PopulateAuthor(ModelBuilder builder)
        {
            var A1 = new Author
            {
                Id = 1,
                Name = "Franz Kafka",
                Description = "ác phẩm của Kafka đều mang một đặc trưng:" +
                " nói về một phần u tối trong dãy “cảm xúc” của con người. Chúng đều được bao trùm trong bầu không khí," +
                " ấn tượng, cảm giác rất riêng biệt, xuất hiện với tần suất lớn như một nỗi ám ảnh khôn nguôi.",
                Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS_RyhnMq01yw12TECaSLPWq83HKvFvakE6A&usqp=CAU"
            };
            var A2 = new Author
            {
                Id = 4,
                Name = "Gabriel Garcia Marquez",
                Description = "ác phẩm của Kafka đều mang một đặc trưng:" +
                " nói về một phần u tối trong dãy “cảm xúc” của con người. Chúng đều được bao trùm trong bầu không khí," +
                " ấn tượng, cảm giác rất riêng biệt, xuất hiện với tần suất lớn như một nỗi ám ảnh khôn nguôi.",
                Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS_RyhnMq01yw12TECaSLPWq83HKvFvakE6A&usqp=CAU"
            };
            builder.Entity<Author>().HasData(A1, A2);
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
                    AuthorID = 1, 
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
                    AuthorID = 1,
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
                    AuthorID = 4,
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
