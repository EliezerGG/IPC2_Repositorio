namespace BodegaApi.Modelos;

// una fila del historial de movimientos
public class MovimientoRegistro
{
    // identificador del movimiento
    public long Id { get; set; }

    // producto afectado
    public string Codigo { get; set; } = "";

    // entrada o salida
    public string Tipo { get; set; } = "";

    // unidades movidas
    public int Cantidad { get; set; }

    // motivo opcional
    public string? Motivo { get; set; }

    // fecha y hora en formato iso 8601, en utc
    public string Fecha { get; set; } = "";
}
