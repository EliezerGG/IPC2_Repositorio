namespace BodegaApi.Modelos;

// resultado interno de procesar un lote: o todo se aplico o nada se aplico
public class ResultadoLote
{
    // verdadero si el lote completo se aplico
    public bool Exito { get; private set; }

    // codigo de estado que el endpoint debe responder
    public int Estado { get; private set; }

    // mensaje de error cuando no hubo exito
    public string? Error { get; private set; }

    // resumen cuando hubo exito
    public ResumenLote? Resumen { get; private set; }

    // fabrica para el caso correcto
    public static ResultadoLote Correcto(ResumenLote resumen)
    {
        // un lote procesado se responde con 201
        return new ResultadoLote { Exito = true, Estado = 201, Resumen = resumen };
    }

    // fabrica para el caso con error
    public static ResultadoLote Falla(int estado, string error)
    {
        // se conserva el estado del primer movimiento que fallo
        return new ResultadoLote { Exito = false, Estado = estado, Error = error };
    }
}
