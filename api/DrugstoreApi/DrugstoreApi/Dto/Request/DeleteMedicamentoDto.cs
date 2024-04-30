namespace DrugstoreApi.Dto.Request
{
    public class DeleteMedicamentoDto
    {
        public string Nombre { get; set; } = null!;

        public bool Activo { get; set; }

        public string? Descripcion { get; set; }

        public string Presentacion { get; set; }

        public string Concentracion { get; set; }

        public string Administracion { get; set; }

        public string Categoria { get; set; }
    }
}
