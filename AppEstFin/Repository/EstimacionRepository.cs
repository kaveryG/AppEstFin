using System;
using AppEstFin.Data;
using AppEstFin.Models;
using Microsoft.Data.SqlClient;

namespace AppEstFin.Repository;

public class EstimacionRepository : IEstimacionRepository
{
    private readonly ILogger<EstimacionRepository> _logger;
    private readonly DataBaseHelper _databaseHelper;

    public EstimacionRepository(ILogger<EstimacionRepository> logger, DataBaseHelper databasehelper)
    {
        _logger = logger;
        _databaseHelper = databasehelper;
    }

    public async Task<List<sp_CalcularTotalAPagarPorTarjeta>> CalcularTotalAPagarPorTarjeta(int id_usuario)
    {
        List<sp_CalcularTotalAPagarPorTarjeta> estimacionMes = new List<sp_CalcularTotalAPagarPorTarjeta>();
        try
        {
            using (SqlConnection connection = _databaseHelper.GetSqlConnection())
            {
                await connection.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_CalcularTotalAPagarPorTarjeta", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario", (object)id_usuario ?? DBNull.Value);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        estimacionMes.Add(new sp_CalcularTotalAPagarPorTarjeta
                        {
                            id_tarjeta = (int)reader["id_tarjeta"],
                            nombre_tarjeta = (string)reader["nombre_tarjeta"],
                            TotalGastos = reader["TotalGastos"] != DBNull.Value ? (decimal)reader["TotalGastos"] : 0,
                            TotalCargosFijos = reader["TotalCargosFijos"] != DBNull.Value ? (decimal)reader["TotalCargosFijos"] : 0,
                            TotalAPagar = reader["TotalAPagar"] != DBNull.Value ? (decimal)reader["TotalAPagar"] : 0,
                        });
                    }

                    reader.Close();
                }
            }
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error al obtener datos de sp_CalcularTotalAPagarPorTarjeta");
            throw;
        }

        return estimacionMes;
    }

    //Comentario para subir a GITHUB

    //Segundo comentario de prueba

    //Tercer comentario de prueba
}
