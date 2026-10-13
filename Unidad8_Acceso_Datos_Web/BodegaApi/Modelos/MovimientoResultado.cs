namespace BodegaApi.Modelos;

// lo que se responde despues de aplicar un movimiento
public class MovimientoResultado
{
    // numero que asigno sqlite al guardar el movimiento
    public long Id { get; set; }

    // producto afectado, ya normalizado a mayusculas
    public string Codigo { get; set; } = "";

    // entrada o salida, ya normalizado a minusculas
    public string Tipo { get; set; } = "";

    // unidades movidas
    public int Cantidad { get; set; }

    // stock antes de aplicar el movimiento
    public int StockAnterior { get; set; }

    // stock despues de aplicar el movimiento
    public int StockNuevo { get; set; }

    // verdadero cuando el stock nuevo es igual o menor al minimo
    public bool AlertaReposicion { get; set; }
}
