using System;
using System.ComponentModel.DataAnnotations;

namespace AppEstFin.DTO;

public class GastoCapturaDTO
{
    public decimal monto { get; set; }
    public string descripcion { get; set; }
    public DateTime fechaMovimiento { get; set; }
    public string categoriaGasto { get; set; }
    public int idTarjeta { get; set; }
    public int idUsuario { get; set; }
}
