using System;
using AppEstFin.Models;
using AppEstFin.Repository;

namespace AppEstFin.Services;

public class EstimacionService : IEstimacionService
{
    private readonly IEstimacionRepository _estimacionRepositorio;
        private readonly ILogger<EstimacionService> _logger;

        public EstimacionService(IEstimacionRepository repositorio, ILogger<EstimacionService> logger)
        {
            _estimacionRepositorio = repositorio;
            _logger = logger;
        }

        public async Task<List<sp_CalcularTotalAPagarPorTarjeta>> ObtenerDatosConsumo (int id_usuario)
        {
            List<sp_CalcularTotalAPagarPorTarjeta> estimacion = await _estimacionRepositorio.CalcularTotalAPagarPorTarjeta(id_usuario);
            return estimacion;
        }

        public async Task<bool> InsertarGasto(decimal monto, string descripcion, DateTime fechaMovimiento, string categoriaGasto, int idTarjeta, int idUsuario)
        {
            try
            {
                await _estimacionRepositorio.InsertarGasto(monto, descripcion, fechaMovimiento, categoriaGasto, idTarjeta, idUsuario);
                return true;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error al insertar gasto en el servicio de ejecución.");
                throw;
            }
            
        }

        public async Task<List<sp_ObtenerGastosPorPeriodo>> ObtenerConsumoPorPeriodo(int id_usuario, int id_tarjeta, int? mes, int? año)
        {   
            if(mes >= 1)
            {
                mes = mes + 1;
            }
            List<sp_ObtenerGastosPorPeriodo> datos = await _estimacionRepositorio.ObtenerGastoPorPeriodo(id_usuario, id_tarjeta, mes, año);
            return datos;
        }
}
