namespace DrugstoreApi.Dto.Response
{
    public class GetMedicamentosPaginadosDto
    {
        public MedicamentoBasicInfo[] Informacion { get; set; }
        public int Pagina { get; set; }
        public int Filas { get; set; }
        public int Total { get; set; }
    }

    public class MedicamentoBasicInfo
    {
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public string? Descripcion { get; set; }
        public string Ubicacion { get; set; }
    }
}
