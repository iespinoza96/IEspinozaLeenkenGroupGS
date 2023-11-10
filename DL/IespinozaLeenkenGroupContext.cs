using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class IespinozaLeenkenGroupContext : DbContext
{
    public IespinozaLeenkenGroupContext()
    {
    }

    public IespinozaLeenkenGroupContext(DbContextOptions<IespinozaLeenkenGroupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatEntidadFederativa> CatEntidadFederativas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= IEspinozaLeenkenGroup; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatEntidadFederativa>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__CatEntid__FBB0EDC157E415BA");

            entity.ToTable("CatEntidadFederativa");

            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E945F9C9F");

            entity.ToTable("Empleado", tb => tb.HasTrigger("EmpleadoTrigger"));

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroNomina)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Empleado__IdEsta__1273C1CD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
