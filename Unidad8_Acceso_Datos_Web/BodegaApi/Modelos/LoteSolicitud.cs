namespace BodegaApi.Modelos;

// el json que llega al procesar varios movimientos de una sola vez
public class LoteSolicitud
{
    // lista de movimientos; el signo de pregunta permite recibir elementos nulos y validarlos nosotros
    public List<MovimientoSolicitud?>? Movimientos { get; set; }
}
