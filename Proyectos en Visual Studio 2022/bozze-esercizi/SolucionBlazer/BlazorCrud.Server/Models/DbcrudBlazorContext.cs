using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Models;

public partial class DbcrudBlazorContext : DbContext
{
    public DbcrudBlazorContext()
    {
    }

    public DbcrudBlazorContext(DbContextOptions<DbcrudBlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.Property(e => e.IdDepartamento).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleado");

            entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");
            entity.Property(e => e.FechaContrato).HasColumnType("date");
            entity.Property(e => e.IdDepartamento).HasColumnType("int(11)");
            entity.Property(e => e.NombreCompleto).HasMaxLength(50);
            entity.Property(e => e.Sueldo).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
