using Gestion_de_expedientes_academicos;
using System;
using System.Collections;

public class Program
{


    public static void Main(string[] args)
    {

        Console.WriteLine("     //==============================================//");
        Console.WriteLine("    //        EXAMEN DE ESTRUCTURAS DE DATOS        //");
        Console.WriteLine("//===========================================================//\n");
        Console.WriteLine("Estudiantes:\tAguirre Martinez Grecia Margarita \n\t\tFuentes Pineda Daniel Isai\n\t\tTranquino Linares Fernando Antonio\n\t\tAragón Raymundo Juan Daniel");
        Console.WriteLine("Fecha de entrega: 24 de marzo del 2026\n");
        Console.WriteLine("Tipo de Arbol Usado: AVL");

        ArbolEstudiantes arbol = new ArbolEstudiantes();
        

        while (true)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("SISTEMA DE EXPEDIENTES ACADÉMICOS");
            Console.WriteLine("1. Insertar estudiante");
            Console.WriteLine("2. Buscar estudiante");
            Console.WriteLine("3. Eliminar estudiante");
            Console.WriteLine("4. Listar estudiantes");
            Console.WriteLine("5. Estadísticas");
            Console.WriteLine("8. Salir");
            Console.WriteLine("=====================================\n");

            Console.WriteLine("Seleccione una opción:");
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida (1-8):");
            }
            switch (opcion)
            {
                case 1:
                    InsertarEstudiante(arbol);
                    break;
                case 2:
                    BuscarEstudiante(arbol);
                    break;

                case 3:
                    EliminarEstudiante(arbol);
                    break;

                case 4:
                    arbol.ListarInOrder();
                    break;
                case 5:
                    Estadisticas(arbol);
                    break;

                case 8:
                    return;
            }
        }
    } //MAIN

            static void InsertarEstudiante(ArbolEstudiantes arbol)
            {
                Console.WriteLine("Ingrese el nombre del estudiante:");
                string nombre = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Ingrese el número de carnet:");
                int carnet;
                while (!int.TryParse(Console.ReadLine(), out carnet))
                {
                    Console.WriteLine("Número de carnet inválido. Por favor, ingrese un número válido:");
                }
                Console.WriteLine("Ingrese la carrera del estudiante:");
                string carrera = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Ingrese la cantidad de créditos cursados:");
                int creditos;
                while (!int.TryParse(Console.ReadLine(), out creditos))
                {
                    Console.WriteLine("Cantidad de créditos inválida. Por favor, ingrese un número válido:");
                }

                Console.WriteLine("Ingrese promedio del estudiante: ");
                double promedio;
                while (!double.TryParse(Console.ReadLine(), out promedio))
                {
                    Console.WriteLine("Promedio inválido. Por favor, ingrese un número válido:");
                }

                Estudiante est = new Estudiante(nombre, carnet, carrera,creditos, promedio);
                if (arbol.Insertar(est))
                {
                    Console.WriteLine("Estudiante insertado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo insertar el estudiante. El número de expediente ya existe.");
                }

            }//Insertar estudiantes

        static void BuscarEstudiante(ArbolEstudiantes arbol)
        {
            Console.Write("Ingrese carnet a buscar: ");

            int carnet;
            while (!int.TryParse(Console.ReadLine(), out carnet))
            {
                Console.WriteLine("Número inválido");
            }

            Estudiante? est = arbol.Buscar(carnet);

            if (est != null)
            {
               
                Console.WriteLine("Estudiante encontrado:");
                Console.WriteLine ($"Nombre: {est.Nombre}");
                Console.WriteLine($"Carnet: {est.Carnet}");
                Console.WriteLine($"Carrera: {est.Carrera}");
                Console.WriteLine($"Promedio: {est.Promedio}");
                Console.WriteLine($"Créditos: {est.Creditos}");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }// buscar estudiantes





        static void EliminarEstudiante(ArbolEstudiantes arbol)
        {
        
        Console.Write("Ingrese carnet del estudiante a eliminar: ");

        int carnet;
        while (!int.TryParse(Console.ReadLine(), out carnet))
        {
            Console.WriteLine("Número inválido. Ingrese un carnet válido:");
        }

        bool eliminado = arbol.Eliminar(carnet);

        if (eliminado)
        {
            Console.WriteLine("Estudiante eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró un estudiante con ese carnet.");
        }


        }



    static void Estadisticas(ArbolEstudiantes arbol)
    {
        Console.WriteLine("\n--- ESTADÍSTICAS ---");
        Console.WriteLine("Total estudiantes: " + arbol.Contarestudiantes(arbol.Raiz));
        Console.WriteLine("Altura del árbol: " + arbol.AlturaArbol(arbol.Raiz));
        var carreras = new Dictionary<string, int>();
        Console.WriteLine("\nEstudiantes por carrera:");

        var stats = arbol.EstadisticasPorCarrera();

        foreach (var item in stats)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }
}





