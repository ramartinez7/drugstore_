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
        _ = modelBuilder.Entity<Administracion>(entity =>
        {
            _ = entity.HasKey(e => e.AdministracionId).HasName("PK__administ__1B41E818C5485B56");

            _ = entity.ToTable("administracion");

            _ = entity.HasIndex(e => e.AdministracionId, "UQ__administ__1B41E8196EDFD4FE").IsUnique();

            _ = entity.Property(e => e.AdministracionId).HasColumnName("administracion_id");
            _ = entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        _ = modelBuilder.Entity<Categoria>(entity =>
        {
            _ = entity.HasKey(e => e.CategoriaId).HasName("PK__categori__DB875A4F59974C85");

            _ = entity.ToTable("categoria");

            _ = entity.HasIndex(e => e.CategoriaId, "UQ__categori__DB875A4E8957E3EE").IsUnique();

            _ = entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            _ = entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        _ = modelBuilder.Entity<Concentracion>(entity =>
        {
            _ = entity.HasKey(e => e.ConcentracionId).HasName("PK__concentr__758525F092585E7E");

            _ = entity.ToTable("concentracion");

            _ = entity.HasIndex(e => e.ConcentracionId, "UQ__concentr__758525F1F4ACD8E1").IsUnique();

            _ = entity.Property(e => e.ConcentracionId).HasColumnName("concentracion_id");
            _ = entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        _ = modelBuilder.Entity<Medicamento>(entity =>
        {
            _ = entity.HasKey(e => e.MedicamentoId).HasName("PK__medicame__BBBBB8CA9C30AF12");

            _ = entity.ToTable("medicamento");

            _ = entity.HasIndex(e => e.MedicamentoId, "UQ__medicame__BBBBB8CBB3B33CB6").IsUnique();

            _ = entity.Property(e => e.MedicamentoId).HasColumnName("medicamento_id");
            _ = entity.Property(e => e.Activo).HasColumnName("activo");
            _ = entity.Property(e => e.AdministracionId).HasColumnName("administracion_id");
            _ = entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            _ = entity.Property(e => e.ConcentracionId).HasColumnName("concentracion_id");
            _ = entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            _ = entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
            _ = entity.Property(e => e.PresentacionId).HasColumnName("presentacion_id");

            _ = entity.HasOne(d => d.Administracion).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.AdministracionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__admin__440B1D61");

            _ = entity.HasOne(d => d.Categoria).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__categ__47DBAE45");

            _ = entity.HasOne(d => d.Concentracion).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.ConcentracionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__conce__4316F928");

            _ = entity.HasOne(d => d.Presentacion).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.PresentacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__prese__4222D4EF");
        });

        _ = modelBuilder.Entity<MedicamentoUbicacion>(entity =>
        {
            _ = entity.HasKey(e => e.MedicamentoUbicacionId).HasName("PK_medicamento_ubicacion");

            _ = entity.ToTable("medicamento_ubicacion");

            _ = entity.Property(e => e.MedicamentoId).HasColumnName("medicamento_id");
            _ = entity.Property(e => e.MedicamentoUbicacionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("medicamento_ubicacion_id");
            _ = entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");

            _ = entity.HasOne(d => d.Medicamento).WithMany()
                .HasForeignKey(d => d.MedicamentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__medic__4CA06362");

            _ = entity.HasOne(d => d.Ubicacion).WithMany()
                .HasForeignKey(d => d.UbicacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicamen__ubica__4D94879B");
        });

        _ = modelBuilder.Entity<Presentacion>(entity =>
        {
            _ = entity.HasKey(e => e.PresentacionId).HasName("PK__presenta__040BBA980B1065C0");

            _ = entity.ToTable("presentacion");

            _ = entity.HasIndex(e => e.PresentacionId, "UQ__presenta__040BBA99C046E857").IsUnique();

            _ = entity.Property(e => e.PresentacionId).HasColumnName("presentacion_id");
            _ = entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        _ = modelBuilder.Entity<Ubicacion>(entity =>
        {
            _ = entity.HasKey(e => e.UbicacionId).HasName("PK__ubicacio__54512829125653A6");

            _ = entity.ToTable("ubicacion");

            _ = entity.HasIndex(e => new { e.Estante, e.Casilla, e.Caja }, "UQ__ubicacio__129843858A5B2EE6").IsUnique();

            _ = entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");
            _ = entity.Property(e => e.Caja).HasColumnName("caja");
            _ = entity.Property(e => e.Casilla).HasColumnName("casilla");
            _ = entity.Property(e => e.Estante).HasColumnName("estante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
