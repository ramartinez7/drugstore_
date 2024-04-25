using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DrugstoreApi.Models;

public partial class FarmaciaContext : DbContext
{
    public FarmaciaContext()
    {
    }

    public FarmaciaContext(DbContextOptions<FarmaciaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administracion> Administracion { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Concentracion> Concentracion { get; set; }

    public virtual DbSet<Medicamento> Medicamento { get; set; }

    public virtual DbSet<MedicamentoUbicacion> MedicamentoUbicacion { get; set; }

    public virtual DbSet<Presentacion> Presentacion { get; set; }

    public virtual DbSet<Ubicacion> Ubicacion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administracion>(entity =>
        {
            entity.HasKey(e => e.AdministracionId).HasName("PK__administ__1B41E818C5485B56");

            entity.ToTable("administracion");

            entity.HasIndex(e => e.AdministracionId, "UQ__administ__1B41E8196EDFD4FE").IsUnique();

            entity.Property(e => e.AdministracionId).HasColumnName("administracion_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__categori__DB875A4F59974C85");

            entity.ToTable("categoria");

            entity.HasIndex(e => e.CategoriaId, "UQ__categori__DB875A4E8957E3EE").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Concentracion>(entity =>
        {
            entity.HasKey(e => e.ConcentracionId).HasName("PK__concentr__758525F092585E7E");

            entity.ToTable("concentracion");

            entity.HasIndex(e => e.ConcentracionId, "UQ__concentr__758525F1F4ACD8E1").IsUnique();

            entity.Property(e => e.ConcentracionId).HasColumnName("concentracion_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.MedicamentoId).HasName("PK__medicame__BBBBB8CA9C30AF12");

            entity.ToTable("medicamento");

            entity.HasIndex(e => e.MedicamentoId, "UQ__medicame__BBBBB8CBB3B33CB6").IsUnique();

            entity.Property(e => e.MedicamentoId).HasColumnName("medicamento_id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.AdministracionId).HasColumnName("administracion_id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.ConcentracionId).HasColumnName("concentracion_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PresentacionId).HasColumnName("presentacion_id");

            entity.HasOne(d => d.Administracion).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.AdministracionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__admin__440B1D61");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__categ__47DBAE45");

            entity.HasOne(d => d.Concentracion).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.ConcentracionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__conce__4316F928");

            entity.HasOne(d => d.Presentacion).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.PresentacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__prese__4222D4EF");
        });

        modelBuilder.Entity<MedicamentoUbicacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("medicamento_ubicacion");

            entity.Property(e => e.MedicamentoId).HasColumnName("medicamento_id");
            entity.Property(e => e.MedicamentoUbicacionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("medicamento_ubicacion_id");
            entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");

            entity.HasOne(d => d.Medicamento).WithMany()
                .HasForeignKey(d => d.MedicamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__medic__4CA06362");

            entity.HasOne(d => d.Ubicacion).WithMany()
                .HasForeignKey(d => d.UbicacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__ubica__4D94879B");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.PresentacionId).HasName("PK__presenta__040BBA980B1065C0");

            entity.ToTable("presentacion");

            entity.HasIndex(e => e.PresentacionId, "UQ__presenta__040BBA99C046E857").IsUnique();

            entity.Property(e => e.PresentacionId).HasColumnName("presentacion_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.UbicacionId).HasName("PK__ubicacio__54512829125653A6");

            entity.ToTable("ubicacion");

            entity.HasIndex(e => new { e.Estante, e.Casilla, e.Caja }, "UQ__ubicacio__129843858A5B2EE6").IsUnique();

            entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");
            entity.Property(e => e.Caja).HasColumnName("caja");
            entity.Property(e => e.Casilla).HasColumnName("casilla");
            entity.Property(e => e.Estante).HasColumnName("estante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
