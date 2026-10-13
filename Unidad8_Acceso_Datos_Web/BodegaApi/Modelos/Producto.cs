namespace BodegaApi.Modelos;

// representa un repuesto guardado en la bodega
public class Producto
{
    // codigo unico del repuesto, por ejemplo rep-001
    public string? Codigo { get; set; }

    // nombre descriptivo del repuesto
    public string? Nombre { get; set; }

    // unidades disponibles ahora mismo
    public int Stock { get; set; }

    // cuando el stock baja a este valor conviene reponer
    public int StockMinimo { get; set; }
}
