using System.Collections;
using System.Collections.Generic;

namespace EjemploLaberinto
{
    // TDA lista simplemente enlazada, específico para Celda.
    // Implementación propia con nodos (sin List<T> ni arreglos).
    public class ListaCeldas : IEnumerable<Celda>
    {
        private class NodoCelda
        {
            public Celda Dato;
            public NodoCelda Siguiente;
            public NodoCelda(Celda dato) { Dato = dato; }
        }

        private NodoCelda _inicio;
        private NodoCelda _fin;
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

        // Recorrido para foreach.
        public IEnumerator<Celda> GetEnumerator()
        {
            NodoCelda actual = _inicio;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
