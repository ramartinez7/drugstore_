namespace DrugstoreApi.Models;

public partial class Medicamento
{
    public int MedicamentoId { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public string? Descripcion { get; set; }

    public int PresentacionId { get; set; }

    public int ConcentracionId { get; set; }

    public int AdministracionId { get; set; }

    public int CategoriaId { get; set; }

    public Ubicacion Ubicacion { get; set; }

    public virtual Administracion Administracion { get; set; } = null!;

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Concentracion Concentracion { get; set; } = null!;

    public virtual Presentacion Presentacion { get; set; } = null!;
}
