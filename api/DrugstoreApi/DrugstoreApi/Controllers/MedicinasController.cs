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
        [Route("ReadMedicinasPaginadas")]
        public ActionResult GetMedicamentosPaginados(string partial_name, int? category, int? shelf, int? slot, int? box, bool? status, int page, int rows)
        {
            if(rows == 0)
            {
                return BadRequest("Rows can't be zero.");
            }

            return Ok(_farmacia.GetMedicamentosPaginados(partial_name,category,shelf,slot,box,status,page,rows));
        }
        //ReadMedicinasById
        [HttpGet]
        [Route("ReadMedicinasById/{Id}")]
        public ActionResult GetMedicamentoByID(int Id)
        {
            return Ok(_farmacia.GetMedicamentoByID(Id));
        }
    }
}
