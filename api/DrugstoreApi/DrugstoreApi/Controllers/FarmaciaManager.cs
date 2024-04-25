using DrugstoreApi.Dto.Request;
using DrugstoreApi.Dto.Response;
using DrugstoreApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DrugstoreApi.Controllers
{
    public interface IFarmacia
    {
        GetMedicamentosPaginadosDto GetMedicamentosPaginados(string partial_name, int? category, int? shelf, int? slot, int? box, bool? status, int page, int rows);
        GetMedicamentoByIDDto GetMedicamentoByID(int Id);
        CreateMedicamentoDto CreateMedicamento(CreateMedicamentoDto request);
        UpdateMedicamentoDto UpdateMedicamento(UpdateMedicamentoDto request);
        DeleteMedicamentoDto DeleteMedicamento(int Id);
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
        public GetMedicamentosPaginadosDto GetMedicamentosPaginados(string partial_name, int? category, int? shelf, int? slot, int? box, bool? status, int page, int rows)
        {
            GetMedicamentosPaginadosDto response = new GetMedicamentosPaginadosDto();

            IQueryable<MedicamentoUbicacion> basequery = farmaciaContext.MedicamentoUbicacion
                    .Include(um => um.Medicamento)
                    .Include(um => um.Ubicacion)
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

            Medicamento medicamento = farmaciaContext.Medicamento
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
        //CreateMedicinas
        public CreateMedicamentoDto CreateMedicamento(CreateMedicamentoDto request)
        {
            Medicamento medicamento = new Medicamento();
            request.Nombre = medicamento.Nombre;
            request.Activo = medicamento.Activo;
            request.Descripcion = medicamento.Descripcion;
            request.medicamento.Presentacion.Tipo = medicamento.Presentacion.Tipo;
            request.medicamento.Concentracion.Tipo = medicamento.Concentracion.Tipo;
            request.medicamento.Administracion.Tipo = medicamento.Administracion.Tipo;
            request.medicamento.Categoria.Nombre = medicamento.Categoria.Nombre;
            farmaciaContext.Medicamento.Entry(medicamento).State = EntityState.Added;
            farmaciaContext.SaveChanges();
            return request;
        }
        //UpdateMedicinas
        public UpdateMedicamentoDto UpdateMedicamento(UpdateMedicamentoDto request)
        {
            Medicamento medicamento = new Medicamento();
            request.Nombre = medicamento.Nombre;
            request.Activo = medicamento.Activo;
            request.Descripcion = medicamento.Descripcion;
            request.Presentacion = medicamento.Presentacion.Tipo;
            request.Concentracion = medicamento.Concentracion.Tipo;
            request.Administracion = medicamento.Administracion.Tipo;
            request.Categoria = medicamento.Categoria.Nombre;
            farmaciaContext.Medicamento.Entry(medicamento).State = EntityState.Modified;
            farmaciaContext.SaveChanges();
            return request;
        }
        //DeleteMedicinas
        public DeleteMedicamentoDto DeleteMedicamento(int Id)
        {
            DeleteMedicamentoDto request = new DeleteMedicamentoDto();

            Medicamento medicamento = farmaciaContext.Medicamento.Where(m => m.MedicamentoId == Id).FirstOrDefault();
            request.Nombre = medicamento.Nombre;
            request.Activo = medicamento.Activo;
            request.Descripcion = medicamento.Descripcion;
            request.Presentacion = medicamento.Presentacion.Tipo;
            request.Concentracion = medicamento.Concentracion.Tipo;
            request.Administracion = medicamento.Administracion.Tipo;
            request.Categoria = medicamento.Categoria.Nombre;
            farmaciaContext.Medicamento.Entry(medicamento).State = EntityState.Deleted;
            farmaciaContext.SaveChanges();
            return request;
        }       
    }
}

