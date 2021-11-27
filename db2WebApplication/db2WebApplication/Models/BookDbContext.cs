using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace db2WebApplication.Models
{
    public class BookDbContext:DbContext    {
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    bookid = 1,
                    bookname = "asdsfsd"
                },
                new Book()
                {
                    bookid = 2,
                    bookname = "hjkhjh"
                },
                new Book()
                {
                    bookid = 3,
                    bookname = "jhuyuu"
                });

            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    authorid = 11,
                    authorname = "aaaa",
                    pubyear = 2018,
                    Bookid = 1
                },
                new Author()
                {
                    authorid = 12,
                    authorname = "bbb",
                    pubyear = 2020,
                    Bookid = 2
                },
                new Author()
                {
                    authorid = 13,
                    authorname = "cccc",
                    pubyear = 2021,
                    Bookid = 3
                },
                new Author()
                {
                    authorid = 14,
                    authorname = "dfdfd",
                    pubyear = 2018,
                    Bookid = 2
                });
            base.OnModelCreating(modelBuilder);

        }
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

