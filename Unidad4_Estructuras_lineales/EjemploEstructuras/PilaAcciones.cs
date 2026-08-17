namespace EjemploEstructuras
{
    // PILA (Stack) — LIFO: el último en entrar es el primero en salir.
    // Implementación propia con nodos. Se trabaja solo por la cima.
    // Objeto que guarda: Accion.
    public class PilaAcciones
    {
        private class Nodo
        {
            public Accion Dato;
            public Nodo Siguiente;
            public Nodo(Accion dato) { Dato = dato; }
        }

        private Nodo _cima;
        private int _cantidad;

        public int Cantidad => _cantidad;
        public bool EstaVacia => _cima == null;

        // Apilar (push): el nodo nuevo se coloca en la cima.
        public void Apilar(Accion accion)
        {
            Nodo nuevo = new Nodo(accion);
            nuevo.Siguiente = _cima;
            _cima = nuevo;
            _cantidad++;
        }

        // Desapilar (pop): saca y devuelve el elemento de la cima.
        public Accion Desapilar()
        {
            if (_cima == null) return null;
            Accion dato = _cima.Dato;
            _cima = _cima.Siguiente;
            _cantidad--;
            return dato;
        }

        // Ver la cima sin sacarla (peek).
        public Accion VerCima() => _cima == null ? null : _cima.Dato;
    }
}
