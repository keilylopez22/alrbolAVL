using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolAVLtarea
{
    public  class Menu
    {

        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();
            ArbolAVL arbolAvl = new ArbolAVL();
            ArbolAVL aletorios = new ArbolAVL();

            while (true)
            {
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Trabajar con Árbol BST");
                Console.WriteLine("2. Trabajar con Árbol AVL");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        menuPrincipal(arbol);
                        break;
                    case 2:
                        MenuAVL(arbolAvl);
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void menuPrincipal(ArbolBinario arbol)
        {
            int opcion = 0;
            string dato = "";
            do
            {
                Console.WriteLine("1.- Insertar");
                Console.WriteLine("2.- Ver recorrido Preorden");
                Console.WriteLine("3.- Ver recorrido Inorden");
                Console.WriteLine("4.- Ver recorrido Postorden");
                Console.WriteLine("5.- Buscar un Valor");
                Console.WriteLine("6.- Mostrar gráfica del árbol");
                Console.WriteLine("7.- Calcular propiedades del árbol");
                Console.WriteLine("8.- Insertar numeros aleatorios");
                Console.WriteLine("9.- Salir");
                Console.WriteLine("Elija una opción");
                opcion = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el dato");
                        dato = Console.ReadLine();
                        arbol.InsertarNodo(dato);
                        break;
                    case 2:
                        arbol.preorden(arbol.raiz);
                        Console.WriteLine();
                        break;
                    case 3:
                        arbol.inorden(arbol.raiz);
                        Console.WriteLine();
                        break;
                    case 4:
                        arbol.postorden(arbol.raiz);
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.Write("Ingrese el valor a buscar: ");
                        dato = Console.ReadLine();
                        arbol.Buscar(dato);
                        break;
                    case 6:
                        arbol.ImprimirArbol();
                        break;
                    case 7:
                        Console.WriteLine($"Altura del árbol: {arbol.CalcularAltura(arbol.raiz)}");
                        Console.WriteLine($"Grado del árbol: {arbol.CalcularGrado(arbol.raiz)}");
                        Console.WriteLine($"Orden del árbol: {arbol.CalcularOrden(arbol.raiz):F2}");
                        break;
                    case 8:

                        arbol.InsertarAleatorio();
                        break;
                    case 9:
                        Console.WriteLine("Adios");
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            } while (opcion != 9);
        }

        static void MenuAVL(ArbolAVL arbolAvl)
        {
            while (true)
            {
                Console.WriteLine("\nMenú Árbol AVL:");
                Console.WriteLine("1. Insertar elemento");
                Console.WriteLine("2. Buscar elemento");
                Console.WriteLine("3. Eliminar elemento");
                Console.WriteLine("4. Imprimir arbol y rrecorridos");
                Console.WriteLine("5. Realizar operacion insertando numeros aleatorios");
                Console.WriteLine("6. Regresar al Menú Principal");
                Console.Write("Seleccione una opción: ");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el elemento a insertar: ");
                        string elemento = Console.ReadLine();
                        arbolAvl.InsertarNodoAVL(elemento);
                        Console.WriteLine($"Elemento '{elemento}' insertado correctamente.");
                        arbolAvl.ImprimirArbol();
                        break;

                    case 2:
                        Console.Write("Ingrese el elemento a buscar: ");
                        elemento = Console.ReadLine();
                        Nodo encontrado = arbolAvl.Buscar(elemento);

                        // Asegúrate de que exista el método Buscar en tu clase ArbolAVL
                        if (encontrado != null)
                            Console.WriteLine($"Elemento '{elemento}' encontrado.");
                        else
                            Console.WriteLine($"Elemento '{elemento}' no encontrado.");
                        break;

                    case 3:
                        Console.Write("Ingrese el elemento a eliminar: ");
                        elemento = Console.ReadLine();
                        arbolAvl.EliminarNodoAVL(elemento);
                        Console.WriteLine($"Elemento '{elemento}' eliminado (si existía).");
                        arbolAvl.ImprimirArbol();
                        break;

                    case 4:
                        Console.WriteLine("Recorridos del Árbol AVL:");
                        Console.WriteLine("Inorden:");
                        arbolAvl.Inorden();

                        Console.WriteLine("Preorden:");
                        arbolAvl.Preorden();

                        Console.WriteLine("Postorden:");
                        arbolAvl.Postorden();

                        Console.WriteLine("arbol");
                        arbolAvl.ImprimirArbol();
                        break;
                    case 5:
                        Console.WriteLine("Generando numeros aleatoreos");
                        arbolAvl.InsertarAleatorios();
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
