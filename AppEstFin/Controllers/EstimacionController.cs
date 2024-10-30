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
        [Route("ConsultarConsumo")]
        public async Task<ActionResult<List<sp_CalcularTotalAPagarPorTarjeta>>> ConsultarConsumo(int id_usuario)
        {
            var result = await _estimacionService.ObtenerDatosConsumo(id_usuario);
            return Ok(result);
        }

        [HttpGet]
        [Route("InsertarGasto")]
        public async Task<ActionResult<EjecutaAccionDTO>> InsertarGasto(decimal monto, string descripcion, DateTime fechaMovimiento, string categoriaGasto, int idTarjeta, int idUsuario)
        {
            EjecutaAccionDTO accion = new EjecutaAccionDTO();
            
            var result = await _estimacionService.InsertarGasto(monto, descripcion, fechaMovimiento, categoriaGasto, idTarjeta, idUsuario);
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
