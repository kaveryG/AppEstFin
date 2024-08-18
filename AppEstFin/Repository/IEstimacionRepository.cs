using System;
using AppEstFin.Models;

namespace AppEstFin.Repository;

public interface IEstimacionRepository
{
    Task<List<sp_CalcularTotalAPagarPorTarjeta>> CalcularTotalAPagarPorTarjeta(int id_usuario);
}
