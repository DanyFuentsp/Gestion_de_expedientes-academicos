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
                Console.WriteLine ($"Carnet: {nodo.Dato.Carnet} | Carrera : {nodo.Dato.Carrera} | Promedio: {nodo.Dato.Promedio} | Créditos: {nodo.Dato.Creditos}");
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


        private NodoArbol ObtenerMinimo(NodoArbol nodo)
        {
            while (nodo.Izquierdo != null)
            {
                nodo = nodo.Izquierdo;
            }
            return nodo;
        }
        // esto ayuda en caso de que el nodo tenga dos hijos, y siempre ira a la izquierda para bucar el mas pequeño

        private NodoArbol? Eliminar(NodoArbol? nodo, int carnet, ref bool eliminado)
        {
            if (nodo == null)
            {
                eliminado = false;
                return null;
            }

            if (carnet < nodo.Dato.Carnet)
            {
                nodo.Izquierdo = Eliminar(nodo.Izquierdo, carnet, ref eliminado);
            }
            else if (carnet > nodo.Dato.Carnet)
            {
                nodo.Derecho = Eliminar(nodo.Derecho, carnet, ref eliminado);
            }
            else
            {
                eliminado = true;

                if (nodo.Izquierdo == null && nodo.Derecho == null)
                {
                    return null;
                }

                if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }

                if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }

                //busca el menor subarbol derecho para hacerlo sucesor
                NodoArbol sucesor = ObtenerMinimo(nodo.Derecho);
                nodo.Dato = sucesor.Dato;
                nodo.Derecho = Eliminar(nodo.Derecho, sucesor.Dato.Carnet, ref eliminado);
            }

            return nodo;
        }

        
        public bool Eliminar(int carnet)
        {
            bool eliminado = false;
            Raiz = Eliminar(Raiz, carnet, ref eliminado);
            return eliminado;
        }//solo para confirmar que el estudiante ha sido eliminado


    }
}


