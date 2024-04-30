using Azure.Core;
using DrugstoreApi.Dto.Request;
using DrugstoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrugstoreApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class MedicinasController : Controller
    {
        private readonly IFarmacia _farmacia;

        public MedicinasController(IFarmacia farmacia)
        {
            _farmacia = farmacia;
        }
        //ReadMedicinasPaginadas
        [HttpGet]
        [Route("ReadMedicamentosPaginados")]
        public ActionResult GetMedicamentosPaginados(string Nombre_parcial, int? Categoria, int? Estante, int? Casilla, int? Caja, bool? Estado, int Pagina, int Filas)
        {
            if (Pagina == 0)
            {
                return BadRequest("Digite el número la página que desea visualizar");
            }
            if (Filas == 0)
            {
                return BadRequest("Digite el número de filas que desea ver por página");
            }         
            return Ok(_farmacia.GetMedicamentosPaginados(Nombre_parcial, Categoria, Estante, Casilla, Caja, Estado, Pagina, Filas));
        }
        //ReadMedicinasById
        [HttpGet]
        [Route("ReadMedicamentoById/{Id}")]
        public ActionResult GetMedicamentoByID(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("El id no puede ser cero, digite nuevamente");
            }
            return Ok(_farmacia.GetMedicamentoByID(Id));
        }
        //CreateMedicinas
        [HttpPost]
        [Route("CreateMedicamento")]
        public ActionResult CreateMedicamento(CreateMedicamentoDto request)
        {
            if (request == null)
            {
                return BadRequest("No se ha podido añadir un nuevo medicamento");
            }
            return Ok(_farmacia.CreateMedicamento(request));
        }
        //UpdateMedicinas
        [HttpPut]
        [Route("UpdateMedicamento/{Id}")]
        public ActionResult UpdateMedicamento(UpdateMedicamentoDto request, int Id)
        {
            if (request == null)
            {
                return BadRequest("No se ha podido actualizar el medicamento existente");
            }
            return Ok(_farmacia.UpdateMedicamento(request, Id));
        }
        //DeleteMedicinas
        [HttpDelete]
        [Route("DeleteMedicamento/{Id}")]
        public ActionResult DeleteMedicamento(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("No se ha podido eliminar el medicamento del sistema");
            }
            return Ok(_farmacia.DeleteMedicamento(Id));
        }
    }
}
