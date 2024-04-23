using DrugstoreApi.Dto.Response;
using DrugstoreApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DrugstoreApi.Controllers
{
    public interface IFarmacia
    {
        GetMedicamentoDtoResponse GetMedicamentosPaginados(string partial_name, int? category, int? shelf, int? slot, int? box, bool? status, int page, int rows);
        GetMedicamentoByIDDto GetMedicamentoByID(int Id);
    }
    //Inyección DbContext
    public class FarmaciaManager : IFarmacia
    {
        private readonly FarmaciaContext farmaciaContext;

        public FarmaciaManager(FarmaciaContext farmaciaContext)
        {
            this.farmaciaContext = farmaciaContext;
        }
        //ReadMedicinasPaginadas
        public GetMedicamentoDtoResponse GetMedicamentosPaginados(string partial_name, int? category, int? shelf, int? slot, int? box, bool? status, int page, int rows)
        {
            GetMedicamentoDtoResponse response = new GetMedicamentoDtoResponse();

            IQueryable<MedicamentoUbicacion> basequery = farmaciaContext.MedicamentoUbicacions
                    .Include(um => um.Medicamento) // join to medicamento
                    .Include(um => um.Ubicacion) //* join to ubicacion
                    .Where(um =>
                        (partial_name == null || um.Medicamento.Nombre.StartsWith(partial_name))
                        && (category == null || um.Medicamento.CategoriaId == category)
                        && (shelf == null || um.Ubicacion.Estante == shelf)
                        && (slot == null || um.Ubicacion.Casilla == slot)
                        && (box == null || um.Ubicacion.Caja == box)
                        && (status == null || um.Medicamento.Activo == status));

            int total = basequery.Count();

            MedicamentoBasicInfo[] data = basequery
                    .Skip((page - 1) * rows)
                    .Take(rows)
                    .Select(um => new MedicamentoBasicInfo
                    {
                        Nombre = um.Medicamento.Nombre,
                        Descripcion = um.Medicamento.Descripcion,
                        Estado = um.Medicamento.Activo,
                        Ubicacion = "Estante: " + um.Ubicacion.Estante + ", Casilla: " + um.Ubicacion.Casilla + ", Caja: " + um.Ubicacion.Caja
                    })
                    .ToArray();

            response.Data = data;
            response.Numero_Registros = rows;
            response.Pagina = page;
            response.Total = total;

            return response;
        }
        //ReadMedicinasById
        public GetMedicamentoByIDDto GetMedicamentoByID(int Id)
        {
            GetMedicamentoByIDDto response = new GetMedicamentoByIDDto();

            Medicamento medicamento = farmaciaContext.Medicamentos
                .Include(m => m.Presentacion)
                .Include(m => m.Concentracion)
                .Include(m => m.Administracion)
                .Include(m => m.Categoria)
                .Where(m => m.MedicamentoId == Id).FirstOrDefault();

            if (medicamento == null)
                return null;
                    
            response.Nombre = medicamento.Nombre;
            response.Activo = medicamento.Activo;
            response.Descripcion = medicamento.Descripcion;
            response.Presentacion = medicamento.Presentacion.Tipo;
            response.Concentracion = medicamento.Concentracion.Tipo;
            response.Administracion = medicamento.Administracion.Tipo;
            response.Categoria = medicamento.Categoria.Nombre;

            return response;         
        }
    }
}

