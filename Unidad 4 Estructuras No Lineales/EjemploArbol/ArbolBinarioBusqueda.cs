using System.Text;

namespace EjemploArbol
{
    // arbol binario de busqueda (abb) de productos, ordenado por codigo.
    // regla de orden: codigos menores a la izquierda, mayores a la derecha.
    public class ArbolBinarioBusqueda
    {
        // nodo interno del arbol: guarda un producto y sus dos hijos
        private class Nodo
        {
            public Producto Dato;      // el producto que guarda este nodo
            public Nodo Izquierda;     // hijo izquierdo (codigos menores)
            public Nodo Derecha;       // hijo derecho (codigos mayores)

            // constructor del nodo: recibe el producto a guardar
            public Nodo(Producto dato)
            {
                Dato = dato;           // guarda el producto
                Izquierda = null;      // al inicio no tiene hijo izquierdo
                Derecha = null;        // al inicio no tiene hijo derecho
            }
        }

        // raiz del arbol; si es null, el arbol esta vacio
        private Nodo _raiz;

        //  INSERCION 

        // inserta un producto en el arbol
        public void Insertar(Producto producto)
        {
            // se reasigna la raiz con el resultado de la insercion recursiva
            _raiz = InsertarNodo(_raiz, producto);
        }

        // metodo recursivo que inserta y devuelve el subarbol actualizado
        private Nodo InsertarNodo(Nodo actual, Producto producto)
        {
            // si llegamos a un lugar vacio, aqui va el producto nuevo
            if (actual == null)
            {
                // se crea y se devuelve el nodo nuevo (sera una hoja)
                return new Nodo(producto);
            }

            // si el codigo nuevo es menor, se baja por la izquierda
            if (producto.Codigo < actual.Dato.Codigo)
            {
                // se inserta en el subarbol izquierdo y se reengancha
                actual.Izquierda = InsertarNodo(actual.Izquierda, producto);
            }
            // si el codigo nuevo es mayor, se baja por la derecha
            else if (producto.Codigo > actual.Dato.Codigo)
            {
                // se inserta en el subarbol derecho y se reengancha
                actual.Derecha = InsertarNodo(actual.Derecha, producto);
            }
            // si el codigo ya existe, no se inserta (los codigos son unicos)

            // se devuelve el nodo actual (con sus hijos ya actualizados)
            return actual;
        }

        //  BUSQUEDA 

        // busca un producto por su codigo; devuelve null si no existe
        public Producto Buscar(int codigo)
        {
            // empezamos el recorrido desde la raiz
            Nodo actual = _raiz;

            // mientras haya nodo por revisar
            while (actual != null)
            {
                // si el codigo coincide, encontramos el producto
                if (codigo == actual.Dato.Codigo)
                {
                    return actual.Dato;   // se devuelve el producto hallado
                }
                // si el codigo buscado es menor, seguimos por la izquierda
                else if (codigo < actual.Dato.Codigo)
                {
                    actual = actual.Izquierda;   // baja a la izquierda
                }
                // si es mayor, seguimos por la derecha
                else
                {
                    actual = actual.Derecha;     // baja a la derecha
                }
            }

            // si salimos del ciclo, el codigo no estaba en el arbol
            return null;
        }

        //  ELIMINACION 

        // elimina el producto que tenga el codigo indicado
        public void Eliminar(int codigo)
        {
            // se reasigna la raiz con el arbol ya sin ese codigo
            _raiz = EliminarNodo(_raiz, codigo);
        }

        // metodo recursivo que elimina y devuelve el subarbol actualizado
        private Nodo EliminarNodo(Nodo actual, int codigo)
        {
            // si el subarbol esta vacio, no hay nada que borrar
            if (actual == null)
            {
                return null;   // se devuelve vacio
            }

            // si el codigo es menor, el nodo a borrar esta a la izquierda
            if (codigo < actual.Dato.Codigo)
            {
                actual.Izquierda = EliminarNodo(actual.Izquierda, codigo);
            }
            // si el codigo es mayor, esta a la derecha
            else if (codigo > actual.Dato.Codigo)
            {
                actual.Derecha = EliminarNodo(actual.Derecha, codigo);
            }
            // si el codigo coincide, este es el nodo que hay que borrar
            else
            {
                // caso 1: no tiene hijo izquierdo (incluye ser hoja)
                if (actual.Izquierda == null)
                {
                    // el hijo derecho sube a ocupar su lugar
                    return actual.Derecha;
                }
                // caso 2: no tiene hijo derecho
                if (actual.Derecha == null)
                {
                    // el hijo izquierdo sube a ocupar su lugar
                    return actual.Izquierda;
                }

                // caso 3: tiene dos hijos
                // se busca el sucesor: el menor del subarbol derecho
                Nodo sucesor = MinimoNodo(actual.Derecha);
                // se copia el dato del sucesor en el nodo actual
                actual.Dato = sucesor.Dato;
                // se elimina el sucesor de su posicion original (caso facil)
                actual.Derecha = EliminarNodo(actual.Derecha, sucesor.Dato.Codigo);
            }

            // se devuelve el nodo actual ya arreglado
            return actual;
        }

        // devuelve el nodo con el codigo mas pequeno de un subarbol
        private Nodo MinimoNodo(Nodo nodo)
        {
            // el minimo esta bajando siempre hacia la izquierda
            while (nodo.Izquierda != null)
            {
                nodo = nodo.Izquierda;   // baja un nivel a la izquierda
            }
            return nodo;   // este ya no tiene hijo izquierdo: es el minimo
        }

        //  RECORRIDOS 

        // recorrido inorden: izquierda, raiz, derecha (sale ordenado por codigo)
        public string RecorridoInorden()
        {
            StringBuilder sb = new StringBuilder();   // acumula el texto
            Inorden(_raiz, sb);                        // recorre desde la raiz
            return sb.ToString().Trim();               // devuelve el texto final
        }

        // metodo recursivo del inorden
        private void Inorden(Nodo actual, StringBuilder sb)
        {
            if (actual == null) return;                // caso base: nodo vacio
            Inorden(actual.Izquierda, sb);             // 1) visita la izquierda
            sb.Append(actual.Dato.Codigo).Append("  ");// 2) visita la raiz
            Inorden(actual.Derecha, sb);               // 3) visita la derecha
        }

        // recorrido preorden: raiz, izquierda, derecha
        public string RecorridoPreorden()
        {
            StringBuilder sb = new StringBuilder();   // acumula el texto
            Preorden(_raiz, sb);                       // recorre desde la raiz
            return sb.ToString().Trim();               // devuelve el texto final
        }

        // metodo recursivo del preorden
        private void Preorden(Nodo actual, StringBuilder sb)
        {
            if (actual == null) return;                // caso base: nodo vacio
            sb.Append(actual.Dato.Codigo).Append("  ");// 1) visita la raiz
            Preorden(actual.Izquierda, sb);            // 2) visita la izquierda
            Preorden(actual.Derecha, sb);              // 3) visita la derecha
        }

        // recorrido posorden: izquierda, derecha, raiz
        public string RecorridoPosorden()
        {
            StringBuilder sb = new StringBuilder();   // acumula el texto
            Posorden(_raiz, sb);                       // recorre desde la raiz
            return sb.ToString().Trim();               // devuelve el texto final
        }

        // metodo recursivo del posorden
        private void Posorden(Nodo actual, StringBuilder sb)
        {
            if (actual == null) return;                // caso base: nodo vacio
            Posorden(actual.Izquierda, sb);            // 1) visita la izquierda
            Posorden(actual.Derecha, sb);              // 2) visita la derecha
            sb.Append(actual.Dato.Codigo).Append("  ");// 3) visita la raiz
        }

        // ================= GRAPHVIZ =================

        // genera el texto en formato dot para dibujar el arbol con graphviz
        public string GenerarDot()
        {
            StringBuilder sb = new StringBuilder();    // acumula el texto dot
            sb.AppendLine("digraph Arbol {");          // abre el grafo dirigido
            sb.AppendLine("  node [shape=circle, style=filled, fillcolor=\"#EAF3FB\", color=\"#1B4F72\", fontname=\"Helvetica\"];");
            sb.AppendLine("  edge [color=\"#1B4F72\"];");// estilo de las aristas

            // si el arbol esta vacio, se cierra un grafo sin nodos
            if (_raiz == null)
            {
                sb.AppendLine("}");                    // cierra el grafo
                return sb.ToString();                  // devuelve dot vacio
            }

            // se recorren los nodos para declararlos y unirlos
            EscribirDot(_raiz, sb);
            sb.AppendLine("}");                         // cierra el grafo
            return sb.ToString();                      // devuelve el dot
        }

        // recorre el arbol y escribe nodos y aristas en formato dot
        private void EscribirDot(Nodo actual, StringBuilder sb)
        {
            if (actual == null) return;                // caso base: nodo vacio

            // declara el nodo con su etiqueta (codigo y nombre)
            sb.AppendLine($"  {actual.Dato.Codigo} [label=\"{actual.Dato.Codigo}\\n{actual.Dato.Nombre}\"];");

            // si tiene hijo izquierdo, dibuja la arista y sigue por el
            if (actual.Izquierda != null)
            {
                sb.AppendLine($"  {actual.Dato.Codigo} -> {actual.Izquierda.Dato.Codigo};");
                EscribirDot(actual.Izquierda, sb);     // recorre la izquierda
            }
            // si tiene hijo derecho, dibuja la arista y sigue por el
            if (actual.Derecha != null)
            {
                sb.AppendLine($"  {actual.Dato.Codigo} -> {actual.Derecha.Dato.Codigo};");
                EscribirDot(actual.Derecha, sb);       // recorre la derecha
            }
        }
    }
}
