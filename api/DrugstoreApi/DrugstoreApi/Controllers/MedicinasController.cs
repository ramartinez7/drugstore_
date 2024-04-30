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
        public ActionResult GetMedicamentosPaginados(string partial_name, int? category, int? shelf, int? slot, int? box, bool? status, int page, int rows)
        {
            if(rows == 0)
            {
                return BadRequest("Las filas no pueden ser cero");
            }

            return Ok(_farmacia.GetMedicamentosPaginados(partial_name,category,shelf,slot,box,status,page,rows));
        }
        //ReadMedicinasById
        [HttpGet]
        [Route("ReadMedicamentoById/{Id}")]
        public ActionResult GetMedicamentoByID(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("El id no puede ser cero");
            }
            return Ok(_farmacia.GetMedicamentoByID(Id));
        }
        //CreateMedicinas
        [HttpPost]
        [Route("CreateMedicamento")]
        public ActionResult CreateMedicamento(CreateMedicamentoDto request, int UbicacionId)
        {
            if (request == null)
            {
                return BadRequest("No se ha podido añadir un nuevo medicamento");
            }
            return Ok(_farmacia.CreateMedicamento(request, UbicacionId));
        }
        //UpdateMedicinas
        [HttpPut]
        [Route("UpdateMedicamento")]
        public ActionResult UpdateMedicamento(UpdateMedicamentoDto request)
        {
            if (request == null)
            {
                return BadRequest("No se ha podido actualizar el medicamento existente");
            }
            return Ok(_farmacia.UpdateMedicamento(request));
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
