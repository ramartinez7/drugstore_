using System.Text.Json.Serialization;

namespace DrugstoreApi.Dto.Response
{
    public class GetMedicamentoDtoResponse
    {
        public MedicamentoBasicInfo[] Data { get; set; }
        public int Pagina { get; set; }
        public int Numero_Registros { get; set; }
        public int Total { get; set; }
    }

    public class MedicamentoBasicInfo
    {
        public string Nombre { get; set; } 
        public string? Descripcion { get; set; } 
        public string Ubicacion { get; set; } 
        public bool Estado { get; set; } 
    }
}
