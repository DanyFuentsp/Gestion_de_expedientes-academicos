using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_de_expedientes_academicos
{
    internal class NodoArbol
    {
        public Estudiante Dato;
        public NodoArbol? Izquierdo;
        public NodoArbol? Derecho;
        public int Altura;

        public NodoArbol (Estudiante dato)
        {
            Dato = dato;
            Izquierdo = null;
            Derecho = null;
            Altura = 1;   
        }

    }
}
