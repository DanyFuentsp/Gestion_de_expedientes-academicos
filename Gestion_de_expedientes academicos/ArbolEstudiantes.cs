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
                Console.WriteLine($"Carnet: {nodo.Dato.Carnet} | Carrera : {nodo.Dato.Carrera} | Promedio: {nodo.Dato.Promedio} | Créditos: {nodo.Dato.Creditos}");
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





        //mostrar estadisticas del arbol, como altura, cantidad de nodos, etc



        public int Contarestudiantes(NodoArbol? nodo)
        {
            return ContarRecursivo(Raiz);
        }

        public int ContarRecursivo(NodoArbol? nodo)
        {
            if (nodo == null)
                return 0;
            return 1 + ContarRecursivo(nodo.Izquierdo) + ContarRecursivo(nodo.Derecho);
        }

        public int AlturaArbol(NodoArbol? nodo)
        {
            if (nodo == null)
                return 0;
            int alturaIzquierda = AlturaArbol(nodo.Izquierdo);
            int alturaDerecha = AlturaArbol(nodo.Derecho);
            return Math.Max(alturaIzquierda, alturaDerecha) + 1;

        }


        //si deseamos sacar estadisticas por carrera, como promedio de cada carrera, cantidad de estudiantes por carrera, etc, se puede hacer un recorrido del arbol y acumular esa informacion en un diccionario o algo similar para luego mostrarla al usuario.



        public Dictionary<string, int> EstadisticasPorCarrera()
        {
            var conteo = new Dictionary<string, int>();
            ContarCarreras(Raiz, conteo);
            return conteo;
        }

        private void ContarCarreras(NodoArbol? nodo, Dictionary<string, int> conteo)
        {
            if (nodo == null) return;

            string carrera = nodo.Dato.Carrera;

            conteo[carrera] = conteo.ContainsKey(carrera)
                ? conteo[carrera] + 1
                : 1;

            ContarCarreras(nodo.Izquierdo, conteo);
            ContarCarreras(nodo.Derecho, conteo);
        }

    }


}


