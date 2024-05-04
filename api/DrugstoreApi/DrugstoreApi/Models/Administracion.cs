using System;
using System.Collections.Generic;

namespace DrugstoreApi.Models;

public partial class Administracion
{
    public int AdministracionId { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();
}
