using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace dbefapplication.Models
{
    public partial class meritemployeeContext : DbContext
    {
        public meritemployeeContext()
        {
        }

        public meritemployeeContext(DbContextOptions<meritemployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeMerit> EmployeeMerits { get; set; }
        /* public IQueryable<EmployeeMerit> getemployeebyid(int id)
       {
           SqlParameter pid = new SqlParameter("@id", id );
           return EmployeeMerits.FromSql("EXECUTE spgetemployeebyid @id", pid);
       }*/


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("data source=.;initial catalog=meritemployee;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmployeeMerit>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("EmployeeMerit");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.EmployeeDept).HasColumnName("employee_dept");

                entity.Property(e => e.EmployeeSal).HasColumnName("employee_sal");

                entity.Property(e => e.Employeename).HasColumnName("employeename");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
