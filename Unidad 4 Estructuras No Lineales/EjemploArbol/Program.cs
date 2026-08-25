using System;
using System.Diagnostics;
using System.IO;

namespace EjemploArbol
{
    // enunciado (caso realista):
    // una tienda maneja el inventario de sus productos. cada producto tiene un
    // codigo unico. se necesita agregar productos, buscarlos y quitarlos rapido,
    // y tambien listarlos ordenados por codigo. un arbol binario de busqueda
    // resuelve esto: ordena por codigo, asi cada operacion baja por un solo
    // camino en lugar de revisar todo el inventario.
    class Program
    {
        // arbol que guardara los productos (se comparte en todo el menu)
        static ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

        // nombre del archivo dot que se generara para graphviz
        const string ArchivoDot = "arbol.dot";

        static void Main(string[] args)
        {
            bool salir = false;                 // controla el ciclo del menu
            while (!salir)                      // repite hasta elegir salir
            {
                MostrarMenu();                  // muestra las opciones
                string opcion = Console.ReadLine();  // lee la eleccion
                Console.WriteLine();            // linea en blanco

                switch (opcion)                 // ejecuta segun la opcion
                {
                    case "1": CargarEjemplo(); break;     // datos de ejemplo
                    case "2": InsertarProducto(); break;  // insercion
                    case "3": BuscarProducto(); break;    // busqueda
                    case "4": EliminarProducto(); break;  // eliminacion
                    case "5": MostrarRecorridos(); break; // recorridos
                    case "6": GraficarArbol(); break;     // graphviz
                    case "0": salir = true; Console.WriteLine("¡Hasta luego!"); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
                Console.WriteLine();            // separa cada iteracion
            }
        }

        // imprime el menu de opciones
        static void MostrarMenu()
        {
            Console.WriteLine("===== INVENTARIO (ARBOL BINARIO DE BUSQUEDA) =====");
            Console.WriteLine("1. Cargar productos de ejemplo");
            Console.WriteLine("2. Insertar un producto");
            Console.WriteLine("3. Buscar un producto por codigo");
            Console.WriteLine("4. Eliminar un producto por codigo");
            Console.WriteLine("5. Recorridos (inorden, preorden, posorden)");
            Console.WriteLine("6. Graficar el arbol (Graphviz)");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");
        }

        // inserta varios productos de ejemplo en el arbol
        static void CargarEjemplo()
        {
            // se insertan en este orden para formar un arbol balanceado
            arbol.Insertar(new Producto(50, "Teclado", 150.00));   // raiz
            arbol.Insertar(new Producto(30, "Mouse", 80.00));      // izquierda
            arbol.Insertar(new Producto(70, "Monitor", 900.00));   // derecha
            arbol.Insertar(new Producto(20, "Cable HDMI", 45.00)); // hoja
            arbol.Insertar(new Producto(40, "Audifonos", 120.00)); // hoja
            arbol.Insertar(new Producto(60, "Webcam", 210.00));    // hoja
            arbol.Insertar(new Producto(80, "Impresora", 650.00)); // hoja
            Console.WriteLine("Se cargaron 7 productos de ejemplo.");
        }

        // pide los datos de un producto y lo inserta
        static void InsertarProducto()
        {
            Console.Write("Codigo: ");           // pide el codigo
            int codigo = LeerEntero();           // lee un entero valido
            Console.Write("Nombre: ");           // pide el nombre
            string nombre = Console.ReadLine();  // lee el nombre
            Console.Write("Precio: ");           // pide el precio
            double precio = LeerDecimal();       // lee un decimal valido

            // crea el producto y lo inserta en el arbol
            arbol.Insertar(new Producto(codigo, nombre, precio));
            Console.WriteLine("Producto insertado.");
        }

        // busca un producto por su codigo y muestra el resultado
        static void BuscarProducto()
        {
            Console.Write("Codigo a buscar: ");  // pide el codigo
            int codigo = LeerEntero();           // lee un entero valido

            Producto p = arbol.Buscar(codigo);   // busca en el arbol
            if (p == null)                       // si no lo encontro
            {
                Console.WriteLine("No existe un producto con ese codigo.");
            }
            else                                 // si lo encontro
            {
                Console.WriteLine("Encontrado: " + p);
            }
        }

        // elimina un producto por su codigo
        static void EliminarProducto()
        {
            Console.Write("Codigo a eliminar: ");// pide el codigo
            int codigo = LeerEntero();           // lee un entero valido

            // verifica si existe antes de borrar (solo para el mensaje)
            if (arbol.Buscar(codigo) == null)
            {
                Console.WriteLine("No existe ese codigo; nada que eliminar.");
                return;                          // termina el metodo
            }

            arbol.Eliminar(codigo);              // elimina del arbol
            Console.WriteLine("Producto eliminado.");
        }

        // muestra los tres recorridos del arbol
        static void MostrarRecorridos()
        {
            // inorden: sale ordenado por codigo de menor a mayor
            Console.WriteLine("Inorden  (ordenado): " + arbol.RecorridoInorden());
            // preorden: la raiz primero
            Console.WriteLine("Preorden (raiz 1ro): " + arbol.RecorridoPreorden());
            // posorden: la raiz al final
            Console.WriteLine("Posorden (raiz fin): " + arbol.RecorridoPosorden());
        }

        // genera el archivo dot y lo convierte en imagen con graphviz
        static void GraficarArbol()
        {
            string dot = arbol.GenerarDot();     // arma el texto dot del arbol
            File.WriteAllText(ArchivoDot, dot);  // guarda el .dot en disco
            Console.WriteLine($"Archivo '{ArchivoDot}' generado.");

            // intenta ejecutar graphviz (motor dot) para crear el png
            try
            {
                Process proceso = new Process();                 // proceso externo
                proceso.StartInfo.FileName = "dot";              // comando dot
                proceso.StartInfo.Arguments = $"-Tpng {ArchivoDot} -o arbol.png";
                proceso.StartInfo.UseShellExecute = false;       // sin shell
                proceso.Start();                                 // lo ejecuta
                proceso.WaitForExit();                           // espera a que termine
                Console.WriteLine("Imagen 'arbol.png' generada con Graphviz.");
            }
            catch                                                // si falla graphviz
            {
                Console.WriteLine("No se pudo ejecutar Graphviz automaticamente.");
                Console.WriteLine($"Genera la imagen a mano con:  dot -Tpng {ArchivoDot} -o arbol.png");
            }
        }

        // lee un entero desde consola, repitiendo si el texto no es valido
        static int LeerEntero()
        {
            int valor;                                       // guardara el numero
            while (!int.TryParse(Console.ReadLine(), out valor))  // valida
            {
                Console.Write("Ingresa un numero valido: ");  // vuelve a pedir
            }
            return valor;                                    // devuelve el entero
        }

        // lee un decimal desde consola, repitiendo si el texto no es valido
        static double LeerDecimal()
        {
            double valor;                                    // guardara el numero
            while (!double.TryParse(Console.ReadLine(), out valor))  // valida
            {
                Console.Write("Ingresa un precio valido: ");  // vuelve a pedir
            }
            return valor;                                    // devuelve el decimal
        }
    }
}
