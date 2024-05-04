namespace DrugstoreApi.Dto.Request
{
    public class CreateMedicamentoDto
    {
        public string Nombre { get; set; } = null!;

        public bool Activo { get; set; }

        public string? Descripcion { get; set; }

        public int PresentacionId { get; set; }

        public int ConcentracionId { get; set; }

        public int AdministracionId { get; set; }

        public int CategoriaId { get; set; }
    }
}
