using DrugstoreApi.Models;

namespace DrugstoreApi.Dto.Request
{
    public class CreateMedicamentoDto
    {
        public Medicamento medicamento { get; set; }

        public CreateMedicamentoDto(Medicamento medicamento)
        {
            this.medicamento = medicamento;
        }

        public int MedicamentoId { get; set; }

        public string Nombre { get; set; } = null!;

        public bool Activo { get; set; }

        public string? Descripcion { get; set; }

        public string Presentacion { get; set; }

        public string Concentracion { get; set; }

        public string Administracion { get; set; }

        public string Categoria { get; set; }
        
    }
}
