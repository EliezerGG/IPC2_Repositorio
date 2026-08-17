using System.Collections.Generic;

namespace EjemploEstructuras
{
    // LISTA CIRCULAR — el último nodo apunta de vuelta al primero.
    // Nunca se llega a null: al recorrer, se rota en ciclo.
    // Ideal para turnos rotativos. Objeto que guarda: Jugador.
    public class ListaCircularJugadores
    {
        private class Nodo
        {
            public Jugador Dato;
            public Nodo Siguiente;
            public Nodo(Jugador dato) { Dato = dato; }
        }

        private Nodo _inicio;
        private Nodo _ultimo;
        private int _cantidad;

        public int Cantidad => _cantidad;

        // Inserta al final y mantiene el ciclo: el último siempre apunta al inicio.
        public void Insertar(Jugador jugador)
        {
            Nodo nuevo = new Nodo(jugador);
            if (_inicio == null)
            {
                _inicio = nuevo;
                _ultimo = nuevo;
            }
            else
            {
                _ultimo.Siguiente = nuevo;
                _ultimo = nuevo;
            }
            _ultimo.Siguiente = _inicio; // cierra el círculo
            _cantidad++;
        }

        // Devuelve los jugadores rotando 'pasos' veces, empezando por el inicio.
        // Como es circular, 'pasos' puede ser mayor que la cantidad de jugadores.
        public IEnumerable<Jugador> Rotar(int pasos)
        {
            if (_inicio == null) yield break;
            Nodo actual = _inicio;
            for (int i = 0; i < pasos; i++)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }
    }
}
