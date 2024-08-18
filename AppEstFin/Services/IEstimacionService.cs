using System;
using AppEstFin.Models;

namespace AppEstFin.Services;

public interface IEstimacionService
{
    Task<List<sp_CalcularTotalAPagarPorTarjeta>> ObtenerDatosConsumo (int id_usuario);
}
