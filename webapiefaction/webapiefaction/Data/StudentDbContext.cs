using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapiefaction.Models;

namespace webapiefaction.Data
{
    public class StudentDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                   id = 1,
                   studentname = "agila",
                   age=22,
                   address="sdssdfdf",
                   course=".net"
                },
                 new Student()
                 {
                     id = 2,
                     studentname = "tripu",
                     age = 22,
                     address = "sdddsd asds",
                     course = "python"
                 }
               );

           
            base.OnModelCreating(modelBuilder);

        }


        public StudentDbContext (DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<webapiefaction.Models.Student> Student { get; set; }

       


    }
}
