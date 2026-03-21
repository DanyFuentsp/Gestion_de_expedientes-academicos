using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_de_expedientes_academicos
{
    internal class ArbolEstudiantes
    {
        public NodoArbol? Raiz;

        public NodoArbol Insertar(NodoArbol? nodo, Estudiante est, ref bool insertado)
        {
            if (nodo == null)
            {
                insertado = true;
                return new NodoArbol(est);
            }

            if (est.Carnet < nodo.Dato.Carnet)
                nodo.Izquierdo = Insertar(nodo.Izquierdo, est, ref insertado);
            else if (est.Carnet > nodo.Dato.Carnet)
                nodo.Derecho = Insertar(nodo.Derecho, est, ref insertado);
            else
            {
                insertado = false;
                Console.WriteLine("El numero de carnet ya ha sido ingresado");
                return nodo;
            }
            return nodo;
        }
        public bool Insertar(Estudiante est)
        {
            bool insertado = false;
            Raiz = Insertar(Raiz, est, ref insertado);
            return insertado;
        }

        public Estudiante? Buscar(NodoArbol? nodo, int carnet)
        {
            if (nodo == null)
                return null;

            if (carnet == nodo.Dato.Carnet)
                return nodo.Dato;

            if (carnet < nodo.Dato.Carnet)
                return Buscar(nodo.Izquierdo, carnet);

            else
                return Buscar(nodo.Derecho, carnet);


        }

        public Estudiante? Buscar(int carnet)
        {
            return Buscar(Raiz, carnet);

        }
        
        public void InOrder(NodoArbol? nodo)
        {
            if (nodo != null)
            {
                InOrder(nodo.Izquierdo);
                Console.WriteLine ($"Carmet: {nodo.Dato.Carnet} | Carrera : {nodo.Dato.Carrera} | Promedio: {nodo.Dato.Promedio} | Créditos: {nodo.Dato.Creditos}");
                InOrder(nodo.Derecho); 
            }
        }
        public void ListarInOrder()
        {
            if (Raiz == null)
            {
                Console.WriteLine("Aun no hay registros");
                return;
            }
            InOrder(Raiz);
        }
    }
}


