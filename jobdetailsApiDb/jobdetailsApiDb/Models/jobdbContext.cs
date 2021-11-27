using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace jobdetailsApiDb.Models
{
    public partial class jobdbContext : DbContext
    {
        public jobdbContext()
        {
        }

        public jobdbContext(DbContextOptions<jobdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobDetail> JobDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=.;initial catalog = jobdb;integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<JobDetail>(entity =>
            {
                entity.HasKey(e => e.JobDetailsId)
                    .HasName("PK__job_deta__839C0E6AEA8EEDBB");

                entity.ToTable("job_details");

                entity.Property(e => e.JobDetailsId).HasColumnName("Job_details_id");

                entity.Property(e => e.CompanyAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("company_address");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("companyname");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.Experience)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("experience");

                entity.Property(e => e.JobCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("job_category");

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("job_description");

                entity.Property(e => e.JobLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("job_location");

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("job_type");

                entity.Property(e => e.NoOfVacancies).HasColumnName("no_of_vacancies");

                entity.Property(e => e.PhNo).HasColumnName("ph_no");

                entity.Property(e => e.Requiredskills)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("requiredskills");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
