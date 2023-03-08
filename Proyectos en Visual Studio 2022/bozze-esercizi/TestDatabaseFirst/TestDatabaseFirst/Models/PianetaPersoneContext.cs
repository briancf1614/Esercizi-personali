using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestDatabaseFirst.Models;

public partial class PianetaPersoneContext : DbContext
{
    public PianetaPersoneContext()
    {
    }

    public PianetaPersoneContext(DbContextOptions<PianetaPersoneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Identificazione> Identificaziones { get; set; }

    public virtual DbSet<Persone> Persones { get; set; }

    public virtual DbSet<Pianeti> Pianetis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=DefaultConnections", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Identificazione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("identificazione");

            entity.HasIndex(e => e.PersonaId, "IX_Identificazione_PersonaId").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DataNascita).HasMaxLength(6);
            entity.Property(e => e.PersonaId).HasColumnType("int(11)");

            entity.HasOne(d => d.Persona).WithOne(p => p.Identificazione)
                .HasForeignKey<Identificazione>(d => d.PersonaId)
                .HasConstraintName("FK_Identificazione_Persone_PersonaId");
        });

        modelBuilder.Entity<Persone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persone");

            entity.HasIndex(e => e.PianetaId, "IX_Persone_PianetaId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Anni).HasColumnType("int(11)");
            entity.Property(e => e.PianetaId).HasColumnType("int(11)");

            entity.HasOne(d => d.Pianeta).WithMany(p => p.Persones)
                .HasForeignKey(d => d.PianetaId)
                .HasConstraintName("FK_Persone_Pianeti_PianetaId");
        });

        modelBuilder.Entity<Pianeti>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pianeti");

            entity.Property(e => e.Id).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
