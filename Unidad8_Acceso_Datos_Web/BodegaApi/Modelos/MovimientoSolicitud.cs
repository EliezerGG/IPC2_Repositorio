namespace BodegaApi.Modelos;

// el json que llega al registrar una entrada o una salida
public class MovimientoSolicitud
{
    // codigo del producto afectado
    public string? Codigo { get; set; }

    // "entrada" suma unidades y "salida" las resta
    public string? Tipo { get; set; }

    // cuantas unidades se mueven, siempre mayor que cero
    public int Cantidad { get; set; }

    // texto libre opcional: compra, venta, ajuste, etc
    public string? Motivo { get; set; }
}
