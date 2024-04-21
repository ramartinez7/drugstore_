using Microsoft.AspNetCore.Mvc;

namespace DrugstoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicinesController : Controller
    {
        private readonly IFarmacia _farmacia;

        public MedicinesController(IFarmacia farmacia)
        {
            _farmacia = farmacia;
        }

        [HttpGet]
        public ActionResult GetMedicamentosPaginados(string partial_name, int? category, int? shelf, int? slot, int? box, bool? status, int page, int rows)
        {
            if(rows == 0)
            {
                return BadRequest("Rows can't be zero.");
            }

            return Ok(_farmacia.GetMedicamentosPaginados(partial_name,category,shelf,slot,box,status,page,rows));
        }
        [HttpGet]
        [Route("/{Id}")]
        public ActionResult GetMedicamentoByID(int Id)
        {
            return Ok(_farmacia.GetMedicamentoByID(Id));
        }
    }
}
