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
        //CreateEstantes
        [HttpPost]
        [Route("CreateEstantes")]
        public ActionResult CreateEstantes(int Casillas, int Cajas)
        {
            if (Casillas == 0 || Cajas == 0)
            {
                return BadRequest("Todos los campos deben contener un valor");
            }
            _farmacia.CreateEstantes(Casillas, Cajas);
            return Ok();
        }
        //LocateMedicamento
        [HttpPut]
        [Route("LocateMedicamento")]
        public ActionResult LocateMedicamento(int Id, int nuevaUbicacionId)
        {
            if (Id == 0 || nuevaUbicacionId == 0)
            {
                return BadRequest("Es obligatorio digitar ambos valores");
            }
            return Ok(_farmacia.LocateMedicamento(Id, nuevaUbicacionId));
        }
        
    }
}
