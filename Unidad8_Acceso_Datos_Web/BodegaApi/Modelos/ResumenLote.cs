namespace BodegaApi.Modelos;

// resumen que se responde al terminar un lote completo
public class ResumenLote
{
    // cuantos movimientos se aplicaron
    public int Procesados { get; set; }

    // suma de unidades que entraron a la bodega
    public int UnidadesEntrada { get; set; }

    // suma de unidades que salieron de la bodega
    public int UnidadesSalida { get; set; }

    // codigos que quedaron en el minimo o por debajo al terminar el lote
    public List<string> ProductosEnAlerta { get; set; } = new();

    // detalle de cada movimiento aplicado
    public List<MovimientoResultado> Movimientos { get; set; } = new();
}
