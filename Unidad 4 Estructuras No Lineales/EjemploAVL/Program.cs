using System;
using System.Diagnostics;
using System.IO;

namespace EjemploAVL
{
    // enunciado (caso realista):
    // un sistema de soporte crea tickets con numeros consecutivos (1, 2, 3, ...).
    // se necesita buscar, agregar y cerrar (eliminar) tickets rapido, y listarlos
    // en orden. si se guardaran en un arbol binario de busqueda normal, como los
    // numeros llegan en orden creciente, el arbol se convertiria en una linea y
    // buscar seria lento. un arbol avl evita eso: se reequilibra solo con
    // rotaciones despues de cada insercion o eliminacion, y se mantiene rapido.
    class Program
    {
        // arbol avl que guardara los tickets (se comparte en todo el menu)
        static ArbolAVL arbol = new ArbolAVL();

        // nombre del archivo dot que se generara para graphviz
        const string ArchivoDot = "avl.dot";

        static void Main(string[] args)
        {
            bool salir = false;               // controla el ciclo del menu
            while (!salir)                    // repite hasta elegir salir
            {
                MostrarMenu();                // muestra las opciones
                string opcion = Console.ReadLine();  // lee la eleccion
                Console.WriteLine();          // linea en blanco

                switch (opcion)               // ejecuta segun la opcion
                {
                    case "1": CargarEjemplo(); break;    // datos en orden
                    case "2": InsertarTicket(); break;   // insercion
                    case "3": BuscarTicket(); break;     // busqueda
                    case "4": EliminarTicket(); break;   // eliminacion
                    case "5": MostrarRecorridos(); break;// recorridos
                    case "6": GraficarArbol(); break;    // graphviz
                    case "0": salir = true; Console.WriteLine("¡Hasta luego!"); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
                Console.WriteLine();          // separa cada iteracion
            }
        }

        // imprime el menu de opciones
        static void MostrarMenu()
        {
            Console.WriteLine("===== TICKETS DE SOPORTE (ARBOL AVL) =====");
            Console.WriteLine("1. Cargar tickets de ejemplo (en orden 10..70)");
            Console.WriteLine("2. Insertar un ticket");
            Console.WriteLine("3. Buscar un ticket por numero");
            Console.WriteLine("4. Cerrar (eliminar) un ticket por numero");
            Console.WriteLine("5. Recorridos (inorden, preorden, posorden)");
            Console.WriteLine("6. Graficar el arbol (Graphviz)");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");
        }

        // inserta tickets con numeros en orden creciente para mostrar el balanceo
        static void CargarEjemplo()
        {
            // se insertan en orden ascendente a proposito:
            // un abb normal quedaria como una linea; el avl se balancea solo.
            arbol.Insertar(new Ticket(10, "No enciende la PC", "alta"));
            arbol.Insertar(new Ticket(20, "Correo bloqueado", "media"));
            arbol.Insertar(new Ticket(30, "Impresora sin tinta", "baja"));
            arbol.Insertar(new Ticket(40, "Sistema lento", "media"));
            arbol.Insertar(new Ticket(50, "Sin internet", "alta"));
            arbol.Insertar(new Ticket(60, "Instalar programa", "baja"));
            arbol.Insertar(new Ticket(70, "Cambio de contraseña", "media"));
            Console.WriteLine("Se cargaron 7 tickets (insertados en orden creciente).");
            Console.WriteLine("Aun asi, el AVL quedo balanceado. Usa la opcion 6 para verlo.");
        }

        // pide los datos de un ticket y lo inserta
        static void InsertarTicket()
        {
            Console.Write("Numero: ");            // pide el numero
            int numero = LeerEntero();            // lee un entero valido
            Console.Write("Asunto: ");            // pide el asunto
            string asunto = Console.ReadLine();   // lee el asunto
            Console.Write("Prioridad (alta/media/baja): ");  // pide prioridad
            string prioridad = Console.ReadLine();// lee la prioridad

            // crea el ticket y lo inserta (el arbol se balancea solo)
            arbol.Insertar(new Ticket(numero, asunto, prioridad));
            Console.WriteLine("Ticket insertado.");
        }

        // busca un ticket por su numero y muestra el resultado
        static void BuscarTicket()
        {
            Console.Write("Numero a buscar: ");   // pide el numero
            int numero = LeerEntero();            // lee un entero valido

            Ticket t = arbol.Buscar(numero);      // busca en el arbol
            if (t == null)                        // si no lo encontro
            {
                Console.WriteLine("No existe un ticket con ese numero.");
            }
            else                                  // si lo encontro
            {
                Console.WriteLine("Encontrado: " + t);
            }
        }

        // elimina (cierra) un ticket por su numero
        static void EliminarTicket()
        {
            Console.Write("Numero a cerrar: ");   // pide el numero
            int numero = LeerEntero();            // lee un entero valido

            // verifica si existe antes de borrar (solo para el mensaje)
            if (arbol.Buscar(numero) == null)
            {
                Console.WriteLine("No existe ese numero; nada que cerrar.");
                return;                           // termina el metodo
            }

            arbol.Eliminar(numero);               // elimina y rebalancea
            Console.WriteLine("Ticket cerrado (eliminado).");
        }

        // muestra los tres recorridos del arbol
        static void MostrarRecorridos()
        {
            // inorden: sale ordenado por numero de menor a mayor
            Console.WriteLine("Inorden  (ordenado): " + arbol.RecorridoInorden());
            // preorden: la raiz primero
            Console.WriteLine("Preorden (raiz 1ro): " + arbol.RecorridoPreorden());
            // posorden: la raiz al final
            Console.WriteLine("Posorden (raiz fin): " + arbol.RecorridoPosorden());
        }

        // genera el archivo dot y lo convierte en imagen con graphviz
        static void GraficarArbol()
        {
            string dot = arbol.GenerarDot();      // arma el texto dot del arbol
            File.WriteAllText(ArchivoDot, dot);   // guarda el .dot en disco
            Console.WriteLine($"Archivo '{ArchivoDot}' generado.");

            // intenta ejecutar graphviz (motor dot) para crear el png
            try
            {
                Process proceso = new Process();               // proceso externo
                proceso.StartInfo.FileName = "dot";            // comando dot
                proceso.StartInfo.Arguments = $"-Tpng {ArchivoDot} -o avl.png";
                proceso.StartInfo.UseShellExecute = false;     // sin shell
                proceso.Start();                               // lo ejecuta
                proceso.WaitForExit();                         // espera a que termine
                Console.WriteLine("Imagen 'avl.png' generada con Graphviz.");
            }
            catch                                              // si falla graphviz
            {
                Console.WriteLine("No se pudo ejecutar Graphviz automaticamente.");
                Console.WriteLine($"Genera la imagen a mano con:  dot -Tpng {ArchivoDot} -o avl.png");
            }
        }

        // lee un entero desde consola, repitiendo si el texto no es valido
        static int LeerEntero()
        {
            int valor;                                            // guardara el numero
            while (!int.TryParse(Console.ReadLine(), out valor))  // valida
            {
                Console.Write("Ingresa un numero valido: ");      // vuelve a pedir
            }
            return valor;                                         // devuelve el entero
        }
    }
}
