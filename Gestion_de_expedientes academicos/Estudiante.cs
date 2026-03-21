using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Gestion_de_expedientes_academicos
{
    internal class Estudiante
    {
        public string Nombre;
        public int Carnet;
        public string Carrera;
        public double Promedio;
        public int Creditos;

        // Ajuste de firma: el programa crea la instancia pasando primero los creditos (int)
        // y luego el promedio (double), por eso el constructor refleja ese orden.
        public Estudiante(string nombre, int carnet, string carrera, int creditos, double promedio)
        {
            Nombre = nombre;
            Carnet = carnet;
            Carrera = carrera;
            Creditos = creditos;
            Promedio = promedio;
        }
    }
}
