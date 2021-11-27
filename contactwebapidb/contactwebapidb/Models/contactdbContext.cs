using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace contactwebapidb.Models
{
    public partial class contactdbContext : DbContext
    {
        public contactdbContext()
        {
        }

        public contactdbContext(DbContextOptions<contactdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=.;initial catalog =contactdb;integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("message");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
