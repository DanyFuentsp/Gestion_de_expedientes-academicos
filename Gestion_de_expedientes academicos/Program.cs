using System;

public class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("     //==============================================//");
        Console.WriteLine("    //        EXAMEN DE ESTRUCTURAS DE DATOS        //");
        Console.WriteLine("//===========================================================//");
        Console.WriteLine("     Bienvenido al sistema de gestión de expedientes académicos.");
        Console.WriteLine("         Por favor, registre el expediente académico:");
        Console.WriteLine("//===========================================================//");

        Console.Write("Ingrese el nombre completo: ");
        string nombreCompleto = Console.ReadLine();

        Console.Write("Ingrese la carrera a estudiar: ");
        string carrera = Console.ReadLine();

        Console.WriteLine("Ingrese el carnet del estudiante: ");
        int carnet = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la fecha de nacimiento (dd/mm/yyyy): ");
        bool fechaValida = DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento);


    }
}
