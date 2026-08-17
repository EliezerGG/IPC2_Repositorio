using System.Collections;
using System.Collections.Generic;

namespace EjemploEstructuras
{
    // LISTA SIMPLEMENTE ENLAZADA — cada nodo apunta solo al siguiente.
    // Se recorre en un solo sentido. Objeto que guarda: Cancion.
    public class ListaCanciones : IEnumerable<Cancion>
    {
        private class Nodo
        {
            public Cancion Dato;
            public Nodo Siguiente;
            public Nodo(Cancion dato) { Dato = dato; }
        }

        private Nodo _inicio;
        private Nodo _fin;
        private int _cantidad;

        public int Cantidad => _cantidad;

        // Inserta al final de la playlist.
        public void Insertar(Cancion cancion)
        {
            Nodo nuevo = new Nodo(cancion);
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

        // Recorre de principio a fin (para foreach).
        public IEnumerator<Cancion> GetEnumerator()
        {
            Nodo actual = _inicio;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
