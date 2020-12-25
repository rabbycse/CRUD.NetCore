using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CRUD.NetCore.Data
{
    using Data.Entities;
    public partial class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {
        }

        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SalesMain> SalesMains { get; set; }
        public virtual DbSet<SalesSub> SalesSubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SalesDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SalesMain>(entity =>
            {
                entity.ToTable("SalesMain");

                entity.Property(e => e.SalesMainId).HasColumnName("SalesMainID");

                entity.Property(e => e.SalesDate).HasColumnType("date");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SalesSub>(entity =>
            {
                entity.ToTable("SalesSub");

                entity.Property(e => e.SalesSubId).HasColumnName("SalesSubID");

                entity.Property(e => e.ItemName).HasMaxLength(150);

                entity.Property(e => e.ItemQuantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItemRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalesMainId).HasColumnName("SalesMainID");

                entity.HasOne(d => d.SalesMain)
                    .WithMany(p => p.SalesSubs)
                    .HasForeignKey(d => d.SalesMainId)
                    .HasConstraintName("FK_SalesSub_SalesMain");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
