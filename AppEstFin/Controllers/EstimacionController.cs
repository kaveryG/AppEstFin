using AppEstFin.Models;
using AppEstFin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppEstFin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimacionController : ControllerBase
    {
        private readonly IEstimacionService _estimacionService;

        public EstimacionController(IEstimacionService service)
        {
            _estimacionService = service;
        }

        [HttpGet]
        [Route("ConsultarConsumo")]
        public async Task<ActionResult<List<sp_CalcularTotalAPagarPorTarjeta>>> ConsultarConsumo(int id_usuario)
        {
            var result = await _estimacionService.ObtenerDatosConsumo(id_usuario);
            return Ok(result);
        }
    }
}
