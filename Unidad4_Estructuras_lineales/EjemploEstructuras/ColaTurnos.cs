namespace EjemploEstructuras
{
    // COLA (Queue) — FIFO: el primero en entrar es el primero en salir.
    // Se encola por el final y se desencola por el frente.
    // Objeto que guarda: Turno.
    public class ColaTurnos
    {
        private class Nodo
        {
            public Turno Dato;
            public Nodo Siguiente;
            public Nodo(Turno dato) { Dato = dato; }
        }

        private Nodo _frente;
        private Nodo _final;
        private int _cantidad;

        public int Cantidad => _cantidad;
        public bool EstaVacia => _frente == null;

        // Encolar (enqueue): agrega al final.
        public void Encolar(Turno turno)
        {
            Nodo nuevo = new Nodo(turno);
            if (_frente == null)
            {
                _frente = nuevo;
                _final = nuevo;
            }
            else
            {
                _final.Siguiente = nuevo;
                _final = nuevo;
            }
            _cantidad++;
        }

        // Desencolar (dequeue): saca y devuelve el del frente.
        public Turno Desencolar()
        {
            if (_frente == null) return null;
            Turno dato = _frente.Dato;
            _frente = _frente.Siguiente;
            if (_frente == null) _final = null; // la cola quedó vacía
            _cantidad--;
            return dato;
        }

        // Ver quién está en el frente sin atenderlo.
        public Turno VerFrente() => _frente == null ? null : _frente.Dato;
    }
}
