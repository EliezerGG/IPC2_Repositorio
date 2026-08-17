using System;

namespace EjemploEstructuras
{
    // Menú de consola que demuestra las cinco estructuras lineales,
    // cada una guardando un objeto distinto y en un caso de uso donde
    // esa estructura es la elección natural.
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("===== ESTRUCTURAS LINEALES =====");
                Console.WriteLine("1. Pila         → Historial de acciones (deshacer)");
                Console.WriteLine("2. Cola         → Turnos de atención");
                Console.WriteLine("3. Lista simple → Playlist de canciones");
                Console.WriteLine("4. Lista doble  → Historial del navegador");
                Console.WriteLine("5. Lista circular → Turnos rotativos de un juego");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1": DemoPila(); break;
                    case "2": DemoCola(); break;
                    case "3": DemoListaSimple(); break;
                    case "4": DemoListaDoble(); break;
                    case "5": DemoListaCircular(); break;
                    case "0": salir = true; Console.WriteLine("¡Hasta luego!"); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
                Console.WriteLine();
            }
        }

        // PILA (LIFO): lo último que hago es lo primero que deshago.
        static void DemoPila()
        {
            Console.WriteLine(">> PILA — Historial de acciones (guarda objetos Accion)");
            PilaAcciones pila = new PilaAcciones();
            pila.Apilar(new Accion("Escribir 'Hola'"));
            pila.Apilar(new Accion("Poner en negrita"));
            pila.Apilar(new Accion("Insertar imagen"));
            Console.WriteLine("Acciones realizadas (la última queda en la cima).");
            Console.WriteLine($"Cima actual: {pila.VerCima()}");

            Console.WriteLine("\nPresionando 'deshacer' dos veces:");
            Console.WriteLine($"  Se deshace: {pila.Desapilar()}");
            Console.WriteLine($"  Se deshace: {pila.Desapilar()}");
            Console.WriteLine($"Queda en la cima: {pila.VerCima()}");
        }

        // COLA (FIFO): se atiende en el orden de llegada.
        static void DemoCola()
        {
            Console.WriteLine(">> COLA — Turnos de atención (guarda objetos Turno)");
            ColaTurnos cola = new ColaTurnos();
            cola.Encolar(new Turno(1, "Ana"));
            cola.Encolar(new Turno(2, "Luis"));
            cola.Encolar(new Turno(3, "María"));
            Console.WriteLine($"En espera: {cola.Cantidad} turnos. En el frente: {cola.VerFrente()}");

            Console.WriteLine("\nAtendiendo en orden de llegada:");
            Console.WriteLine($"  Pasa: {cola.Desencolar()}");
            Console.WriteLine($"  Pasa: {cola.Desencolar()}");
            Console.WriteLine($"Sigue en el frente: {cola.VerFrente()}");
        }

        // LISTA SIMPLE: se recorre en un solo sentido.
        static void DemoListaSimple()
        {
            Console.WriteLine(">> LISTA SIMPLE — Playlist (guarda objetos Cancion)");
            ListaCanciones playlist = new ListaCanciones();
            playlist.Insertar(new Cancion("Amanecer", "Los Códigos", 210));
            playlist.Insertar(new Cancion("Bucle Infinito", "DJ Puntero", 185));
            playlist.Insertar(new Cancion("Nodo Perdido", "The Enlazados", 240));

            Console.WriteLine($"Playlist ({playlist.Cantidad} canciones), recorrida en orden:");
            int i = 1;
            foreach (Cancion c in playlist)
            {
                Console.WriteLine($"  {i}. {c}");
                i++;
            }
        }

        // LISTA DOBLE: se recorre adelante y atrás.
        static void DemoListaDoble()
        {
            Console.WriteLine(">> LISTA DOBLE — Historial del navegador (guarda objetos Pagina)");
            ListaPaginas historial = new ListaPaginas();
            historial.Insertar(new Pagina("usac.edu.gt"));
            historial.Insertar(new Pagina("classroom.google.com"));
            historial.Insertar(new Pagina("github.com"));

            Console.WriteLine("Adelante (como se visitaron):");
            foreach (Pagina pag in historial.EnOrden()) Console.WriteLine($"  → {pag}");

            Console.WriteLine("Atrás (botón 'anterior'):");
            foreach (Pagina pag in historial.EnReversa()) Console.WriteLine($"  ← {pag}");
        }

        // LISTA CIRCULAR: los turnos rotan sin fin.
        static void DemoListaCircular()
        {
            Console.WriteLine(">> LISTA CIRCULAR — Turnos rotativos (guarda objetos Jugador)");
            ListaCircularJugadores jugadores = new ListaCircularJugadores();
            jugadores.Insertar(new Jugador("Ana"));
            jugadores.Insertar(new Jugador("Luis"));
            jugadores.Insertar(new Jugador("María"));

            Console.WriteLine($"{jugadores.Cantidad} jugadores. Mostrando 7 turnos (rota en ciclo):");
            int turno = 1;
            foreach (Jugador j in jugadores.Rotar(7))
            {
                Console.WriteLine($"  Turno {turno}: juega {j}");
                turno++;
            }
        }
    }
}
