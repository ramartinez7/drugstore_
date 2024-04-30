using DrugstoreApi.Dto.Request;
using DrugstoreApi.Dto.Response;
using DrugstoreApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;

namespace DrugstoreApi.Controllers
{
    public interface IFarmacia
    {
        GetMedicamentosPaginadosDto GetMedicamentosPaginados(string Nombre_parcial, int? Categoria, int? Estante, int? Casilla, int? Caja, bool? Estado, int Pagina, int Filas);
        GetMedicamentoByIDDto GetMedicamentoByID(int Id);
        Medicamento CreateMedicamento(CreateMedicamentoDto request);
        Medicamento UpdateMedicamento(UpdateMedicamentoDto request, int Id);
        Medicamento DeleteMedicamento(int Id);
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
        public GetMedicamentosPaginadosDto GetMedicamentosPaginados(string Nombre_parcial, int? Categoria, int? Estante, int? Casilla, int? Caja, bool? Estado, int Pagina, int Filas)
        {
            GetMedicamentosPaginadosDto response = new GetMedicamentosPaginadosDto();

            IQueryable<MedicamentoUbicacion> buscadorMedicamento = farmaciaContext.MedicamentoUbicacion
                    .Include(um => um.Medicamento)
                    .Include(um => um.Ubicacion)
                    .Where(um => um.Medicamento.Nombre.StartsWith(Nombre_parcial)
                              && um.Medicamento.CategoriaId == Categoria
                              && um.Ubicacion.Estante == Estante
                              && um.Ubicacion.Casilla == Casilla
                              && um.Ubicacion.Caja == Caja
                              && um.Medicamento.Activo == Estado);

            int Total = buscadorMedicamento.Count();

            MedicamentoBasicInfo[] Informacion = buscadorMedicamento
                    .Skip((Pagina - 1) * Filas)
                    .Take(Filas)
                    .Select(um => new MedicamentoBasicInfo
                    {
                        Nombre = um.Medicamento.Nombre,
                        Descripcion = um.Medicamento.Descripcion,
                        Estado = um.Medicamento.Activo,
                        Ubicacion = "Estante: " + um.Ubicacion.Estante + ", Casilla: " + um.Ubicacion.Casilla + ", Caja: " + um.Ubicacion.Caja
                    })
            .ToArray();

            response.Informacion = Informacion;
            response.Filas = Filas;
            response.Pagina = Pagina;
            response.Total = Total;
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
                .Where(m => m.MedicamentoId == Id)
                .FirstOrDefault();
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
        public Medicamento CreateMedicamento(CreateMedicamentoDto request)//-----------------------------------------
        {
            Medicamento medicamento = new Medicamento();
            medicamento.Nombre = request.Nombre;
            medicamento.Activo = request.Activo;
            medicamento.Descripcion = request.Descripcion;
            medicamento.PresentacionId = request.PresentacionId;
            medicamento.ConcentracionId = request.ConcentracionId;
            medicamento.AdministracionId = request.AdministracionId;
            medicamento.CategoriaId = request.CategoriaId;          
            farmaciaContext.Medicamento.Entry(medicamento).State = EntityState.Added;
            farmaciaContext.SaveChanges();
            return medicamento;
        }
        //UpdateMedicinas
        public Medicamento UpdateMedicamento(UpdateMedicamentoDto request, int Id)
        {
            Medicamento medicamento = farmaciaContext.Medicamento
                .Where(m => m.MedicamentoId == Id)
                .FirstOrDefault();
            medicamento.Nombre = request.Nombre;
            medicamento.Activo = request.Activo;
            medicamento.Descripcion = request.Descripcion;
            medicamento.PresentacionId = request.PresentacionId;
            medicamento.ConcentracionId = request.ConcentracionId;
            medicamento.AdministracionId = request.AdministracionId;
            medicamento.CategoriaId = request.CategoriaId;
            farmaciaContext.Medicamento.Entry(medicamento).State = EntityState.Modified;
            farmaciaContext.SaveChanges();
            return medicamento;
        }
        //DeleteMedicinas
        public Medicamento DeleteMedicamento(int Id)
        {
            Medicamento medicamento = farmaciaContext.Medicamento
                .Where(m => m.MedicamentoId == Id)
                .FirstOrDefault();
            farmaciaContext.Medicamento.Entry(medicamento).State = EntityState.Deleted;
            farmaciaContext.SaveChanges();
            return medicamento;
        }       
    }
}

