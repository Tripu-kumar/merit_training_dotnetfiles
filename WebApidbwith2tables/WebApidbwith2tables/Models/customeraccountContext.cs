using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApidbwith2tables.Models
{
    public partial class customeraccountContext : DbContext
    {
        public customeraccountContext()
        {
        }

        public customeraccountContext(DbContextOptions<customeraccountContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=.; initial catalog = customeraccount;integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("account_id");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("account_type");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accounts__custom__38996AB5");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
