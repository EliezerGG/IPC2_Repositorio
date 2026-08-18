namespace EjemploLaberinto
{
    // TDA lista simplemente enlazada, específico para Celda.
    // Implementación propia con nodos: sin List<T>, sin arreglos,
    // y sin IEnumerable/IEnumerator (recorrido manual con cursor).
    public class ListaCeldas
    {
        private class NodoCelda
        {
            public Celda Dato;
            public NodoCelda Siguiente;
            public NodoCelda(Celda dato) { Dato = dato; }
        }

        private NodoCelda _inicio;
        private NodoCelda _fin;
        private NodoCelda _cursor; // usado por el recorrido manual

        private int _cantidad;

        public int Cantidad => _cantidad;
        public bool EstaVacia => _inicio == null;

        // Inserta al final.
        public void Insertar(Celda celda)
        {
            NodoCelda nuevo = new NodoCelda(celda);
            if (_inicio == null)
            {
                _inicio = nuevo;
                _fin = nuevo;
            }
            else
            {
                _fin.Siguiente = nuevo;
                _fin = nuevo;
            }
            _cantidad++;
        }

        // Busca la celda en (fila, columna). Devuelve null si no existe.
        public Celda Buscar(int fila, int columna)
        {
            NodoCelda actual = _inicio;
            while (actual != null)
            {
                if (actual.Dato.Fila == fila && actual.Dato.Columna == columna)
                {
                    return actual.Dato;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        // --- Recorrido manual, sin foreach ni IEnumerable ---
        // Uso típico:
        //
        //   lista.IniciarRecorrido();
        //   while (lista.HayMasCeldas())
        //   {
        //       Celda c = lista.SiguienteCelda();
        //       // ... procesar c ...
        //   }
        //
        public void IniciarRecorrido()
        {
            _cursor = _inicio;
        }

        public bool HayMasCeldas()
        {
            return _cursor != null;
        }

        public Celda SiguienteCelda()
        {
            if (_cursor == null)
            {
                return null;
            }
            Celda dato = _cursor.Dato;
            _cursor = _cursor.Siguiente;
            return dato;
        }
    }
}