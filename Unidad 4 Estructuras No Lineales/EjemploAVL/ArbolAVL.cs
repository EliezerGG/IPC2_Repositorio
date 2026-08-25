using System.Text;

namespace EjemploAVL
{
    // arbol avl: un arbol binario de busqueda que se mantiene balanceado solo.
    // tras cada insercion o eliminacion revisa el factor de balance y, si algun
    // nodo se desbalancea (factor +2 o -2), aplica rotaciones para corregirlo.
    // se ordena por el numero del ticket.
    public class ArbolAVL
    {
        // nodo interno del arbol: guarda un ticket, sus dos hijos y su altura
        private class Nodo
        {
            public Ticket Dato;     // el ticket que guarda este nodo
            public Nodo Izquierda;  // hijo izquierdo (numeros menores)
            public Nodo Derecha;    // hijo derecho (numeros mayores)
            public int Altura;      // altura del nodo (para medir el balance)

            // constructor del nodo: recibe el ticket a guardar
            public Nodo(Ticket dato)
            {
                Dato = dato;        // guarda el ticket
                Izquierda = null;   // al inicio no tiene hijo izquierdo
                Derecha = null;     // al inicio no tiene hijo derecho
                Altura = 1;         // un nodo recien creado tiene altura 1
            }
        }

        // raiz del arbol; si es null, el arbol esta vacio
        private Nodo _raiz;

        //  HELPERS DE BALANCE 

        // devuelve la altura de un nodo (0 si el nodo es null)
        private int Altura(Nodo nodo)
        {
            // si no hay nodo, su altura cuenta como 0
            return nodo == null ? 0 : nodo.Altura;
        }

        // recalcula y guarda la altura de un nodo a partir de sus hijos
        private void ActualizarAltura(Nodo nodo)
        {
            // altura del hijo izquierdo
            int izq = Altura(nodo.Izquierda);
            // altura del hijo derecho
            int der = Altura(nodo.Derecha);
            // la altura del nodo es 1 mas la del hijo mas alto
            nodo.Altura = 1 + (izq > der ? izq : der);
        }

        // factor de balance de un nodo = altura izquierda - altura derecha
        private int FactorBalance(Nodo nodo)
        {
            // si no hay nodo, el factor es 0
            if (nodo == null) return 0;
            // resta las alturas de los dos lados
            return Altura(nodo.Izquierda) - Altura(nodo.Derecha);
        }

        //  ROTACIONES 

        // rotacion simple a la derecha (para el caso izquierda-izquierda)
        private Nodo RotarDerecha(Nodo y)
        {
            Nodo x = y.Izquierda;      // x sera la nueva raiz del subarbol
            Nodo t2 = x.Derecha;       // subarbol que cambiara de lugar

            x.Derecha = y;             // y baja a la derecha de x
            y.Izquierda = t2;          // t2 pasa a ser hijo izquierdo de y

            ActualizarAltura(y);       // primero se recalcula la altura de y
            ActualizarAltura(x);       // luego la de x (nueva raiz)

            return x;                  // se devuelve la nueva raiz del subarbol
        }

        // rotacion simple a la izquierda (para el caso derecha-derecha)
        private Nodo RotarIzquierda(Nodo x)
        {
            Nodo y = x.Derecha;        // y sera la nueva raiz del subarbol
            Nodo t2 = y.Izquierda;     // subarbol que cambiara de lugar

            y.Izquierda = x;           // x baja a la izquierda de y
            x.Derecha = t2;            // t2 pasa a ser hijo derecho de x

            ActualizarAltura(x);       // primero se recalcula la altura de x
            ActualizarAltura(y);       // luego la de y (nueva raiz)

            return y;                  // se devuelve la nueva raiz del subarbol
        }

        // revisa el balance de un nodo y aplica la rotacion que corresponda
        private Nodo Balancear(Nodo nodo)
        {
            // primero se actualiza la altura del nodo
            ActualizarAltura(nodo);
            // se calcula su factor de balance
            int fb = FactorBalance(nodo);

            // caso pesado a la izquierda (fb mayor que 1)
            if (fb > 1)
            {
                // si el hijo izquierdo se inclina a la derecha: caso izq-der
                if (FactorBalance(nodo.Izquierda) < 0)
                {
                    // primero se endereza rotando el hijo a la izquierda
                    nodo.Izquierda = RotarIzquierda(nodo.Izquierda);
                }
                // luego (o si era izq-izq) se rota el nodo a la derecha
                return RotarDerecha(nodo);
            }

            // caso pesado a la derecha (fb menor que -1)
            if (fb < -1)
            {
                // si el hijo derecho se inclina a la izquierda: caso der-izq
                if (FactorBalance(nodo.Derecha) > 0)
                {
                    // primero se endereza rotando el hijo a la derecha
                    nodo.Derecha = RotarDerecha(nodo.Derecha);
                }
                // luego (o si era der-der) se rota el nodo a la izquierda
                return RotarIzquierda(nodo);
            }

            // si estaba balanceado, se devuelve tal cual
            return nodo;
        }

        //  INSERCION 

        // inserta un ticket en el arbol y lo mantiene balanceado
        public void Insertar(Ticket ticket)
        {
            // se reasigna la raiz con el resultado de la insercion recursiva
            _raiz = InsertarNodo(_raiz, ticket);
        }

        // metodo recursivo que inserta y balancea el subarbol
        private Nodo InsertarNodo(Nodo actual, Ticket ticket)
        {
            // si llegamos a un lugar vacio, aqui va el ticket nuevo
            if (actual == null)
            {
                return new Nodo(ticket);   // crea y devuelve el nodo nuevo
            }

            // si el numero es menor, se baja por la izquierda
            if (ticket.Numero < actual.Dato.Numero)
            {
                actual.Izquierda = InsertarNodo(actual.Izquierda, ticket);
            }
            // si el numero es mayor, se baja por la derecha
            else if (ticket.Numero > actual.Dato.Numero)
            {
                actual.Derecha = InsertarNodo(actual.Derecha, ticket);
            }
            // si el numero ya existe, no se inserta (son unicos)
            else
            {
                return actual;   // devuelve sin cambios
            }

            // al volver de la recursion, se balancea este nodo
            return Balancear(actual);
        }

        //  BUSQUEDA 

        // busca un ticket por su numero; devuelve null si no existe
        public Ticket Buscar(int numero)
        {
            Nodo actual = _raiz;          // empieza desde la raiz
            while (actual != null)        // mientras haya nodo por revisar
            {
                if (numero == actual.Dato.Numero)   // si coincide
                {
                    return actual.Dato;   // devuelve el ticket hallado
                }
                else if (numero < actual.Dato.Numero)  // si es menor
                {
                    actual = actual.Izquierda;   // baja a la izquierda
                }
                else                          // si es mayor
                {
                    actual = actual.Derecha;     // baja a la derecha
                }
            }
            return null;   // no se encontro el numero
        }

        //  ELIMINACION 

        // elimina el ticket con el numero indicado y rebalancea el arbol
        public void Eliminar(int numero)
        {
            // se reasigna la raiz con el arbol ya sin ese numero
            _raiz = EliminarNodo(_raiz, numero);
        }

        // metodo recursivo que elimina y balancea el subarbol
        private Nodo EliminarNodo(Nodo actual, int numero)
        {
            // si el subarbol esta vacio, no hay nada que borrar
            if (actual == null) return null;

            // si el numero es menor, el nodo a borrar esta a la izquierda
            if (numero < actual.Dato.Numero)
            {
                actual.Izquierda = EliminarNodo(actual.Izquierda, numero);
            }
            // si el numero es mayor, esta a la derecha
            else if (numero > actual.Dato.Numero)
            {
                actual.Derecha = EliminarNodo(actual.Derecha, numero);
            }
            // si coincide, este es el nodo que hay que borrar
            else
            {
                // caso 1: no tiene hijo izquierdo (incluye ser hoja)
                if (actual.Izquierda == null)
                {
                    actual = actual.Derecha;   // el hijo derecho sube
                }
                // caso 2: no tiene hijo derecho
                else if (actual.Derecha == null)
                {
                    actual = actual.Izquierda; // el hijo izquierdo sube
                }
                // caso 3: tiene dos hijos
                else
                {
                    // se busca el sucesor: el menor del subarbol derecho
                    Nodo sucesor = MinimoNodo(actual.Derecha);
                    // se copia el dato del sucesor en el nodo actual
                    actual.Dato = sucesor.Dato;
                    // se elimina el sucesor de su posicion original
                    actual.Derecha = EliminarNodo(actual.Derecha, sucesor.Dato.Numero);
                }
            }

            // si el nodo quedo vacio tras borrar, no hay que balancear
            if (actual == null) return null;

            // al volver de la recursion, se balancea este nodo
            return Balancear(actual);
        }

        // devuelve el nodo con el numero mas pequeno de un subarbol
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

        // recorrido inorden: izquierda, raiz, derecha (sale ordenado)
        public string RecorridoInorden()
        {
            StringBuilder sb = new StringBuilder();   // acumula el texto
            Inorden(_raiz, sb);                        // recorre desde la raiz
            return sb.ToString().Trim();               // devuelve el texto final
        }

        // metodo recursivo del inorden
        private void Inorden(Nodo actual, StringBuilder sb)
        {
            if (actual == null) return;                 // caso base: nodo vacio
            Inorden(actual.Izquierda, sb);              // 1) izquierda
            sb.Append(actual.Dato.Numero).Append("  "); // 2) raiz
            Inorden(actual.Derecha, sb);                // 3) derecha
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
            if (actual == null) return;                 // caso base: nodo vacio
            sb.Append(actual.Dato.Numero).Append("  "); // 1) raiz
            Preorden(actual.Izquierda, sb);             // 2) izquierda
            Preorden(actual.Derecha, sb);               // 3) derecha
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
            if (actual == null) return;                 // caso base: nodo vacio
            Posorden(actual.Izquierda, sb);             // 1) izquierda
            Posorden(actual.Derecha, sb);               // 2) derecha
            sb.Append(actual.Dato.Numero).Append("  "); // 3) raiz
        }

        //  GRAPHVIZ 

        // genera el texto dot para dibujar el arbol; muestra el factor de balance
        public string GenerarDot()
        {
            StringBuilder sb = new StringBuilder();    // acumula el texto dot
            sb.AppendLine("digraph AVL {");            // abre el grafo dirigido
            sb.AppendLine("  node [shape=circle, style=filled, fillcolor=\"#EAF3FB\", color=\"#1B4F72\", fontname=\"Helvetica\"];");
            sb.AppendLine("  edge [color=\"#1B4F72\"];");// estilo de las aristas

            // si el arbol esta vacio, se cierra sin nodos
            if (_raiz == null)
            {
                sb.AppendLine("}");        // cierra el grafo
                return sb.ToString();      // devuelve dot vacio
            }

            // recorre el arbol declarando nodos y aristas
            EscribirDot(_raiz, sb);
            sb.AppendLine("}");            // cierra el grafo
            return sb.ToString();         // devuelve el dot
        }

        // recorre el arbol y escribe nodos y aristas en formato dot
        private void EscribirDot(Nodo actual, StringBuilder sb)
        {
            if (actual == null) return;    // caso base: nodo vacio

            // factor de balance de este nodo (para mostrarlo en la etiqueta)
            int fb = FactorBalance(actual);
            // declara el nodo con numero, asunto y su factor de balance
            sb.AppendLine($"  {actual.Dato.Numero} [label=\"{actual.Dato.Numero}\\n{actual.Dato.Asunto}\\nfb={fb}\"];");

            // si tiene hijo izquierdo, dibuja la arista y sigue por el
            if (actual.Izquierda != null)
            {
                sb.AppendLine($"  {actual.Dato.Numero} -> {actual.Izquierda.Dato.Numero};");
                EscribirDot(actual.Izquierda, sb);   // recorre la izquierda
            }
            // si tiene hijo derecho, dibuja la arista y sigue por el
            if (actual.Derecha != null)
            {
                sb.AppendLine($"  {actual.Dato.Numero} -> {actual.Derecha.Dato.Numero};");
                EscribirDot(actual.Derecha, sb);     // recorre la derecha
            }
        }
    }
}
