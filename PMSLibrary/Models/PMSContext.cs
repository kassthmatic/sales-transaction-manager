using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PMSLibrary.Models;

public partial class PMSContext : DbContext
{
    public PMSContext()
    {
    }

    public PMSContext(DbContextOptions<PMSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SalesTransaction> SalesTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PMS;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F36BDA22E");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__product__357D4CF8B2E187FF");
        });

        modelBuilder.Entity<SalesTransaction>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.ProductCode, e.SaleDate }).HasName("pf");

            entity.HasOne(d => d.Employee).WithMany(p => p.SalesTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_emploee");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.SalesTransactions)
                .HasForeignKey(d => d.ProductCode)
                .HasConstraintName("FK_salesTransaction_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
