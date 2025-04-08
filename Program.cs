using System.Drawing;

namespace ArbolAVLtarea
{
    internal class Program
    {
        
    }
    public class Nodo
    {
        public string valor;
        public Nodo izq;
        public Nodo der;
        public int altura;
        //constructor 
        public Nodo(string valor)
        {
            this.valor = valor;
            izq = null;
            der = null;
            altura = 1; // Altura inicial del nodo
        }
    }
    public class ArbolBinario
    {
        public Nodo raiz;
        //constructor
        public ArbolBinario()
        {
            raiz = null;
        }
        //metodo preorden
        
        //metodo insertar nodos al arbol
        public void InsertarNodo(string valor)
        {
            if (raiz == null)
            {
                raiz = new Nodo(valor);
                return;
            }

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();

                // Insertar en el primer espacio disponible
                if (actual.izq == null)
                {
                    actual.izq = new Nodo(valor);
                    return;
                }
                else
                {
                    cola.Enqueue(actual.izq);
                }

                if (actual.der == null)
                {
                    actual.der = new Nodo(valor);
                    return;
                }
                else
                {
                    cola.Enqueue(actual.der);
                }
            }
        }
        public void InsertarAleatorio(){
            for (int i = 0; i <= 10000; i++)
            {
                Random ramdom = new Random();
                int numeroaleatorio = ramdom.Next();
                InsertarNodo(numeroaleatorio.ToString());
            }
        }

        public bool Buscar(string valor)
        {
            int comparaciones = 0;
            return BuscarPreorden(raiz, valor, ref comparaciones) ||
                   BuscarInorden(raiz, valor, ref comparaciones) ||
                   BuscarPostorden(raiz, valor, ref comparaciones);
        }
        public void preorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.valor + " ");
                preorden(nodo.izq);
                preorden(nodo.der);
            }
        }


        //metodo inorden
        public void inorden(Nodo nodo)
        {
            if (nodo != null)
            {
                inorden(nodo.izq);
                Console.Write(nodo.valor + " ");
                inorden(nodo.der);
            }
        }
        //metodo postorden
        public void postorden(Nodo nodo)
        {
            if (nodo != null)
            {
                postorden(nodo.izq);
                postorden(nodo.der);
                Console.Write(nodo.valor + " ");
            }
        }
        
        //propiedades del arbol
        public int CalcularAltura(Nodo nodo)
        {


            if (nodo == null)
                return 0;

            int alturaIzq = CalcularAltura(nodo.izq);
            int alturaDer = CalcularAltura(nodo.der);

            return Math.Max(alturaIzq, alturaDer) + 1;
            /*if (nodo == null)
            {
                return 0;
            }
            else
            {
                int alturaIzq = Altura(nodo.izq);
                int alturaDer = Altura(nodo.der);
                //return Math.Max(alturaIzq, alturaDer) + 1;
                if (alturaIzq > alturaDer)
                {
                    return alturaIzq + 1;
                }
                else
                {
                    return alturaDer + 1;
                }
            }*/
        }


        // Método para calcular el orden de un árbol
        public int CalcularOrden(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(nodo);
            int maxHijos = 0;

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();
                int hijos = 0;

                if (actual.izq != null)
                {
                    cola.Enqueue(actual.izq);
                    hijos++;
                }
                if (actual.der != null)
                {
                    cola.Enqueue(actual.der);
                    hijos++;
                }

                maxHijos = Math.Max(maxHijos, hijos);
            }

            return maxHijos;
        }


        //calcular el grado del arbol
        public int CalcularGrado(Nodo nodo)
        {

            if (raiz == null)
                return 0;

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);

            int totalNodos = 0;
            int niveles = 0;

            while (cola.Count > 0)
            {
                int nodosEnNivel = cola.Count;
                totalNodos += nodosEnNivel;
                niveles++;

                for (int i = 0; i < nodosEnNivel; i++)
                {
                    Nodo actual = cola.Dequeue();
                    if (actual.izq != null) cola.Enqueue(actual.izq);
                    if (actual.der != null) cola.Enqueue(actual.der);
                }
            }

            // metodo para calcular el orden de un nodo





            return (int)((double)totalNodos / niveles);

        }
        // Eliminar el modificador 'public' de los métodos dentro de la clase ArbolBinario
        public void ImprimirArbol()
        {
            ImprimirArbolBST(raiz, "", true);
           /* if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            // Obtener la lista de niveles del árbol
            List<List<string>> niveles = ConstruirNiveles(raiz);

            foreach (var nivel in niveles)
            {
                foreach (var item in nivel)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }*/
        }

        public void ImprimirArbolBST(Nodo raiz, string indent = "", bool esDerecha = true)
        {
            if (raiz != null)
            {
                // Imprimimos el árbol primero la derecha y luego la izquierda
                ImprimirArbolBST(raiz.der, indent + (esDerecha ? "     " : "│    "), false);

                // Imprimimos el valor del nodo, con el borde adecuado
                Console.WriteLine(indent + (esDerecha ? "└── " : "┌── ") + raiz.valor);

                ImprimirArbolBST(raiz.izq, indent + (esDerecha ? "│    " : "     "), true);
            }
        }

        // Construye una lista de listas para representar el árbol en niveles con los caracteres / \
        /*private List<List<string>> ConstruirNiveles(Nodo raiz)
        {
            List<List<string>> resultado = new List<List<string>>();
            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                int nivelSize = cola.Count;
                List<string> nivelActual = new List<string>();
                List<string> conexiones = new List<string>();

                for (int i = 0; i < nivelSize; i++)
                {
                    Nodo nodo = cola.Dequeue();
                    nivelActual.Add(nodo.valor.ToString());

                    if (nodo.izq != null || nodo.der != null)
                    {
                        conexiones.Add("/");
                        conexiones.Add("\\");
                    }
                    else
                    {
                        conexiones.Add(" ");
                        conexiones.Add(" ");
                    }

                    if (nodo.izq != null) cola.Enqueue(nodo.izq);
                    if (nodo.der != null) cola.Enqueue(nodo.der);
                }

                resultado.Add(nivelActual);
                resultado.Add(conexiones);
            }
            return resultado;
        }*/


        //recorridos del arbol
        bool BuscarPreorden(Nodo nodo, string valor, ref int comparaciones)
        {
            if (nodo == null)
                return false;

            comparaciones++;
            Console.Write(nodo.valor + " "); // Imprimir el camino recorrido

            if (nodo.valor == valor)
                return true;

            return BuscarPreorden(nodo.izq, valor, ref comparaciones) ||
                   BuscarPreorden(nodo.der, valor, ref comparaciones);
        }

        bool BuscarInorden(Nodo nodo, string valor, ref int comparaciones)
        {
            if (nodo == null)
                return false;

            if (BuscarInorden(nodo.izq, valor, ref comparaciones))
                return true;

            comparaciones++;
            Console.Write(nodo.valor + " "); // Imprimir el camino recorrido

            if (nodo.valor == valor)
                return true;

            return BuscarInorden(nodo.der, valor, ref comparaciones);
        }

        bool BuscarPostorden(Nodo nodo, string valor, ref int comparaciones)
        {
            if (nodo == null)
                return false;

            if (BuscarPostorden(nodo.izq, valor, ref comparaciones))
                return true;

            if (BuscarPostorden(nodo.der, valor, ref comparaciones))
                return true;

            comparaciones++;
            Console.Write(nodo.valor + " "); // Imprimir el camino recorrido

            if (nodo.valor == valor)
                return true;

            return false;
        }




    }
    public class ArbolAVL : ArbolBinario
    {
        // Método para calcular la altura de un nodo (utilizado para balancear el árbol)
        public int Altura(Nodo nodo)
        {
            if (nodo == null)
                return 0;
            // return Math.Max(Altura(nodo.izq), Altura(nodo.der)) + 1;
            //return nodo.altura;
            return nodo?.altura ?? 0;
        }


        // Método de recorrido Inorden
        public void Inorden()
        {
            Inorden(raiz);
            Console.WriteLine();
        }

        private void Inorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Inorden(nodo.izq);
                Console.Write(nodo.valor + " ");
                Inorden(nodo.der);
            }
        }

        // Método de recorrido Preorden
        public void Preorden()
        {
            Preorden(raiz);
            Console.WriteLine();
        }

        private void Preorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.valor + " ");
                Preorden(nodo.izq);
                Preorden(nodo.der);
            }
        }

        // Método de recorrido Postorden
        public void Postorden()
        {
            Postorden(raiz);
            Console.WriteLine();
        }

        private void Postorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Postorden(nodo.izq);
                Postorden(nodo.der);
                Console.Write(nodo.valor + " ");
            }
        }



        // Método para obtener el factor de equilibrio de un nodo
        private int BalanceFactor(Nodo nodo)
        {
            if (nodo == null)
                return 0;
            return Altura(nodo.izq) - Altura(nodo.der);
        }

        // Rotación simple a la derecha (Right Rotation)
        private Nodo RotarDerecha(Nodo y)
        {
            Nodo x = y.izq;
            Nodo T2 = x.der;

            // Realizar rotación
            x.der = y;
            y.izq = T2;

            // Actualizar alturas
            y.altura = Math.Max(Altura(y.izq), Altura(y.der)) + 1;
            x.altura = Math.Max(Altura(x.izq), Altura(x.der)) + 1;

            // Retornar el nuevo nodo raíz
            return x;
        }

        // Rotación simple a la izquierda (Left Rotation)
        private Nodo RotarIzquierda(Nodo x)
        {
            Nodo y = x.der;
            Nodo T2 = y.izq;

            // Realizar rotación
            y.izq = x;
            x.der = T2;

            // Actualizar alturas
            x.altura = Math.Max(Altura(x.izq), Altura(x.der)) + 1;
            y.altura = Math.Max(Altura(y.izq), Altura(y.der)) + 1;

            // Retornar el nuevo nodo raíz
            return y;
        }

        // Función para balancear un nodo
        private Nodo Balancear(Nodo nodo)
        {
            int balance = BalanceFactor(nodo);

            // Caso 1: Rotación simple a la derecha (Derecha desequilibrada)
            if (balance > 1 && BalanceFactor(nodo.izq) >= 0)
                return RotarDerecha(nodo);

            // Caso 2: Rotación simple a la izquierda (Izquierda desequilibrada)
            if (balance < -1 && BalanceFactor(nodo.der) <= 0)
                return RotarIzquierda(nodo);

            // Caso 3: Rotación doble a la derecha (Izquierda-Derecha desequilibrada)
            if (balance > 1 && BalanceFactor(nodo.izq) < 0)
            {
                nodo.izq = RotarIzquierda(nodo.izq);
                return RotarDerecha(nodo);
            }

            // Caso 4: Rotación doble a la izquierda (Derecha-Izquierda desequilibrada)
            if (balance < -1 && BalanceFactor(nodo.der) > 0)
            {
                nodo.der = RotarDerecha(nodo.der);
                return RotarIzquierda(nodo);
            }

            // Retornar el nodo sin cambios (ya está balanceado)
            return nodo;
        }

        // Método para insertar un valor en el árbol AVL
        public void InsertarNodoAVL(string valor)
        {
            raiz = InsertarNodoAVL(raiz, valor);
        }

        private Nodo InsertarNodoAVL(Nodo nodo, string valor)
        {
            // Paso 1: Inserción normal en el árbol binario de búsqueda (BTS)
            if (nodo == null)
                return new Nodo(valor) { altura=1};

            if (string.Compare(valor, nodo.valor) < 0)
                nodo.izq = InsertarNodoAVL(nodo.izq, valor);
            else if (string.Compare(valor, nodo.valor) > 0)
                nodo.der = InsertarNodoAVL(nodo.der, valor);
            else // No se permiten duplicados
                return nodo;

            // Paso 2: Actualizar la altura del nodo actual
            nodo.altura = Math.Max(Altura(nodo.izq), Altura(nodo.der)) + 1;

            // Paso 3: Balancear el nodo y retornar el nodo balanceado
            return Balancear(nodo);
        }
        // Método para insertar random
        public void InsertarAleatorios()
        {
            for (int i = 0; i <= 10000; i++)
            {
                Random ramdom = new Random();
                int numeroaleatorio = ramdom.Next();
                InsertarNodoAVL(numeroaleatorio.ToString());
            }
        }

        // Método para eliminar un nodo en un árbol AVL
        public void EliminarNodoAVL(string valor)
        {
            raiz = EliminarNodoAVL(raiz, valor);
        }

        private Nodo EliminarNodoAVL(Nodo nodo, string valor)
        {
            if (nodo == null)
                return nodo;

            // Paso 1: Realizar la eliminación como en un árbol binario de búsqueda
            if (string.Compare(valor, nodo.valor) < 0)
                nodo.izq = EliminarNodoAVL(nodo.izq, valor);
            else if (string.Compare(valor, nodo.valor) > 0)
                nodo.der = EliminarNodoAVL(nodo.der, valor);
            else
            {
                // Nodo a eliminar encontrado
                if (nodo.izq == null || nodo.der == null)
                {
                    Nodo temp = nodo.izq != null ? nodo.izq : nodo.der;

                    // Caso cuando no tiene hijos o tiene solo un hijo
                    if (temp == null)
                    {
                        temp = nodo;
                        nodo = null;
                    }
                    else
                        nodo = temp;
                }
                else
                {
                    // Caso cuando tiene dos hijos
                    Nodo temp = ObtenerNodoMinimo(nodo.der);
                    nodo.valor = temp.valor;
                    nodo.der = EliminarNodoAVL(nodo.der, temp.valor);
                }
            }

            // Si el árbol tenía un solo nodo, entonces se retorna null
            if (nodo == null)
                return nodo;

            // Paso 2: Actualizar la altura del nodo actual
            nodo.altura = Math.Max(Altura(nodo.izq), Altura(nodo.der)) + 1;

            // Paso 3: Balancear el nodo
            return Balancear(nodo);
        }

        // Método para obtener el nodo con el valor mínimo
        private Nodo ObtenerNodoMinimo(Nodo nodo)
        {
            Nodo actual = nodo;
            while (actual.izq != null)
                actual = actual.izq;
            return actual;
        }

        // Método público para buscar un elemento en el árbol AVL
        public Nodo Buscar(string valor)
        {
            return Buscar(raiz, valor);
        }

        // Método privado recursivo para buscar un nodo con un valor específico
        private Nodo Buscar(Nodo nodo, string valor)
        {
            if (nodo == null || nodo.valor == valor)
                return nodo;  // Retorna el nodo encontrado o null si no existe

            if (string.Compare(valor, nodo.valor) < 0)
                return Buscar(nodo.izq, valor);  // Buscar en el subárbol izquierdo
            else
                return Buscar(nodo.der, valor);  // Buscar en el subárbol derecho
        }

        // Método para imprimir gráficamente el árbol AVL
        public void ImprimirArbol()
        {
            ImprimirArbolAVL(raiz, "", true);
        }

        /*private void ImprimirArbolAVL(Nodo nodo, string indentacion, bool esUltimo)
        {
            if (nodo != null)
            {
                Console.Write(indentacion);

                if (esUltimo)
                {
                    Console.Write("└── ");
                    indentacion += "    ";
                }
                else
                {
                    Console.Write("├── ");
                    indentacion += "│   ";
                }

                Console.WriteLine(nodo.valor);

                ImprimirArbolAVL(nodo.izq, indentacion, false);
                ImprimirArbolAVL(nodo.der, indentacion, true);
            }



        }*/

        public void ImprimirArbolAVL(Nodo raiz, string indent = "", bool esDerecha = true)
        {
            if (raiz != null)
            {
                // Imprimimos el árbol primero la derecha y luego la izquierda
                ImprimirArbolAVL(raiz.der, indent + (esDerecha ? "     " : "│    "), false);

                // Imprimimos el valor del nodo, con el borde adecuado
                Console.WriteLine(indent + (esDerecha ? "└── " : "┌── ") + raiz.valor);

                ImprimirArbolAVL(raiz.izq, indent + (esDerecha ? "│    " : "     "), true);
            }
        }

        







    }


}
