using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RouteGuardProject.Models;

public partial class LogisticContext : DbContext
{
    public LogisticContext()
    {
    }

    public LogisticContext(DbContextOptions<LogisticContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminSession> AdminSessions { get; set; }

    public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }

    public virtual DbSet<SuperAdminSession> SuperAdminSessions { get; set; }

    public virtual DbSet<VehicleRouteTable> VehicleRouteTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=Logistic;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC27AC8F01C9");

            entity.ToTable("Admin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Designation).HasMaxLength(50);
            entity.Property(e => e.Dob)
                .HasMaxLength(50)
                .HasColumnName("DOB");
            entity.Property(e => e.JoinDate).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<AdminSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminSes__3214EC274569198F");

            entity.ToTable("AdminSession");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.LoginAt).HasMaxLength(50);
            entity.Property(e => e.Token).HasMaxLength(50);

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminSessions)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminSession_Admin");
        });

        modelBuilder.Entity<SuperAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SuperAdm__3214EC27DB3B2B91");

            entity.ToTable("SuperAdmin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Designation).HasMaxLength(50);
            entity.Property(e => e.Dob)
                .HasMaxLength(50)
                .HasColumnName("DOB");
            entity.Property(e => e.JoinDate).HasMaxLength(50);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<SuperAdminSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SuperAdm__3214EC27BC5E3561");

            entity.ToTable("SuperAdminSession");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LoginAt).HasMaxLength(50);
            entity.Property(e => e.SuperAdminId).HasColumnName("SuperAdminID");
            entity.Property(e => e.Token).HasMaxLength(50);

            entity.HasOne(d => d.SuperAdmin).WithMany(p => p.SuperAdminSessions)
                .HasForeignKey(d => d.SuperAdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SuperAdminSession_SuperAdmin");
        });

        modelBuilder.Entity<VehicleRouteTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleR__3214EC279F0EFA9B");

            entity.ToTable("VehicleRouteTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.Destination).HasMaxLength(50);
            entity.Property(e => e.DistanceTravelByVehicle).HasMaxLength(50);
            entity.Property(e => e.DriverName).HasMaxLength(50);
            entity.Property(e => e.LicenseDate).HasMaxLength(50);
            entity.Property(e => e.LicenseExpiryDate).HasMaxLength(50);
            entity.Property(e => e.LicenseNumber).HasMaxLength(50);
            entity.Property(e => e.ModifiedAt).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .HasColumnName("PhoneNo.");
            entity.Property(e => e.Source).HasMaxLength(50);
            entity.Property(e => e.VehicleModel).HasMaxLength(50);
            entity.Property(e => e.VehicleNumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
