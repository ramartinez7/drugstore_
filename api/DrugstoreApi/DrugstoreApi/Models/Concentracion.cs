namespace DrugstoreApi.Models;

public partial class Concentracion
{
    public int ConcentracionId { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();
}
