using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ColegioSanJose.Models.DB;

public partial class ColegioSanJoseContext : DbContext
{
    public ColegioSanJoseContext()
    {
    }

    public ColegioSanJoseContext(DbContextOptions<ColegioSanJoseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumno { get; set; }

    public virtual DbSet<Expediente> Expediente { get; set; }

    public virtual DbSet<Materia> Materia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LEGION-FG\\MSSQLSERVER01;Database=ColegioSanJose;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.AlumnoId).HasName("PK__Alumno__90A6AA13253B0BAD");

            entity.ToTable("Alumno");

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Grado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.ExpedienteId).HasName("PK__Expedien__EBC60A36EC23AB0F");

            entity.ToTable("Expediente");

            entity.Property(e => e.NotaFinal).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Alumno).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expedient__Alumn__3C69FB99");

            entity.HasOne(d => d.Materia).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expedient__Mater__3D5E1FD2");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materia__0D019DE1E810DF0A");

            entity.HasIndex(e => e.NombreMateria, "UQ__Materia__5A6D7C03B3B23E0A").IsUnique();

            entity.Property(e => e.Docente)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
