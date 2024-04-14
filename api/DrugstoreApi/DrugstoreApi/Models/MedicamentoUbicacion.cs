using System;
using System.Collections.Generic;

namespace DrugstoreApi.Models;

public partial class MedicamentoUbicacion
{
    public int MedicamentoUbicacionId { get; set; }

    public int MedicamentoId { get; set; }

    public int UbicacionId { get; set; }

    public virtual Medicamento Medicamento { get; set; } = null!;

    public virtual Ubicacion Ubicacion { get; set; } = null!;
}
