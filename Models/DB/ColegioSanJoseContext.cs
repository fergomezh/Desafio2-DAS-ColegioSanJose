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

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Materia> Materia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LEGION-FG\\MSSQLSERVER01; Database=ColegioSanJose; TrustServerCertificate=True; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.AlumnoId).HasName("PK__Alumno__90A6AA1373DF24AD");

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
            entity.HasKey(e => e.ExpedienteId).HasName("PK__Expedien__EBC60A367E62E507");

            entity.ToTable("Expediente");

            entity.Property(e => e.NotaFinal).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Alumno).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expedient__Alumn__3D5E1FD2");

            entity.HasOne(d => d.Materia).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expedient__Mater__3E52440B");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materia__0D019DE1C3753E00");

            entity.HasIndex(e => e.NombreMateria, "UQ__Materia__5A6D7C03BB7376A6").IsUnique();

            entity.Property(e => e.Docente)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
