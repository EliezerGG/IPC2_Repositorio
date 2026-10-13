namespace BodegaApi.Modelos;

// resultado interno de aplicar un movimiento: o salio bien o trae un error con su codigo de estado
public class ResultadoMovimiento
{
    // verdadero si el movimiento se aplico
    public bool Exito { get; private set; }

    // codigo de estado que el endpoint debe responder
    public int Estado { get; private set; }

    // mensaje de error cuando no hubo exito
    public string? Error { get; private set; }

    // datos del movimiento cuando hubo exito
    public MovimientoResultado? Datos { get; private set; }

    // fabrica para el caso correcto
    public static ResultadoMovimiento Correcto(MovimientoResultado datos)
    {
        // un movimiento creado se responde con 201
        return new ResultadoMovimiento { Exito = true, Estado = 201, Datos = datos };
    }

    // fabrica para el caso con error
    public static ResultadoMovimiento Falla(int estado, string error)
    {
        // el estado lo decide quien detecta el problema: 400, 404 o 409
        return new ResultadoMovimiento { Exito = false, Estado = estado, Error = error };
    }
}
