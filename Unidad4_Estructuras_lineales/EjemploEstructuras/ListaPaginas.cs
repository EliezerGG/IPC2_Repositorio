using System.Collections.Generic;

namespace EjemploEstructuras
{
    // LISTA DOBLEMENTE ENLAZADA — cada nodo apunta al siguiente y al anterior.
    // Se recorre en ambos sentidos (ideal para "adelante/atrás" del navegador).
    // Objeto que guarda: Pagina.
    public class ListaPaginas
    {
        private class Nodo
        {
            public Pagina Dato;
            public Nodo Siguiente;
            public Nodo Anterior;
            public Nodo(Pagina dato) { Dato = dato; }
        }

        private Nodo _inicio;
        private Nodo _fin;
        private int _cantidad;

        public int Cantidad => _cantidad;

        // Inserta al final, enlazando en ambos sentidos.
        public void Insertar(Pagina pagina)
        {
            Nodo nuevo = new Nodo(pagina);
            if (_inicio == null)
            {
                _inicio = nuevo;
                _fin = nuevo;
            }
            else
            {
                nuevo.Anterior = _fin;
                _fin.Siguiente = nuevo;
                _fin = nuevo;
            }
            _cantidad++;
        }

        // Recorrido hacia adelante: del inicio al fin.
        public IEnumerable<Pagina> EnOrden()
        {
            Nodo actual = _inicio;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }

        // Recorrido hacia atrás: del fin al inicio (usa el puntero Anterior).
        public IEnumerable<Pagina> EnReversa()
        {
            Nodo actual = _fin;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Anterior;
            }
        }
    }
}
