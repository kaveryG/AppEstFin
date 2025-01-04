using AppEstFin.DTO;
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
        [Route("ConsultarConsumo/{id_usuario}")]
        public async Task<ActionResult<List<sp_CalcularTotalAPagarPorTarjeta>>> ConsultarConsumo(int id_usuario)
        {
            var result = await _estimacionService.ObtenerDatosConsumo(id_usuario);
            return Ok(result);
        }

        [HttpPost]
        [Route("InsertarGasto")]
        public async Task<ActionResult<EjecutaAccionDTO>> InsertarGasto(GastoCapturaDTO dtoC)
        {
            EjecutaAccionDTO accion = new EjecutaAccionDTO();
            
            var result = await _estimacionService.InsertarGasto(dtoC.monto, dtoC.descripcion, dtoC.fechaMovimiento, dtoC.categoriaGasto, dtoC.idTarjeta, dtoC.idUsuario);
            if(result == true)
            {
                accion.valida = true;
                accion.mensaje = "Gasto registrado correctamente";
            }
            else
            {
                accion.valida = false;
                accion.mensaje = "Error al registrar el gasto";
            }

            return Ok(accion);
        }

        [HttpGet]
        [Route("ConsultarConsumoXPeriodo")]
        public async Task<ActionResult<List<sp_CalcularTotalAPagarPorTarjeta>>> ConsultarConsumoXPeriodo(int id_usuario, int id_tarjeta, int? mes, int? año)
        {
            var result = await _estimacionService.ObtenerConsumoPorPeriodo(id_usuario, id_tarjeta, mes, año);
            return Ok(result);
        }
    }
}
