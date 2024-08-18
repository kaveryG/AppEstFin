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
}
