Holi, trabaje la parte del menu con switch los case 3 y del 5 hacia abajo aun no estan trabajados pero los que son Buscar, Insertar y Listar si.
Hay algo que no he hecho y es que las cosas se vayan guardando porque 1, no es un requisito segun la guia y 2 no me acuerdo como se hace JAJAJA cualquier cosa me escriben 



aqui dejo otra forma de resolver el expediente 
es otra forma mas complicada de hacerlo pero mas largo y complicado 

public Dictionary<string, (int cantidad, double promedio)> EstadisticasPorCarrera()
{
    var estadisticas = new Dictionary<string, (int cantidad, double sumaPromedios)>();

    CalcularEstadisticas(Raiz, estadisticas);
    var resultado = new Dictionary<string, (int cantidad, double promedio)>();

    foreach (var item in estadisticas)
    {
        int cantidad = item.Value.cantidad;
        double suma = item.Value.sumaPromedios;

        double promedioFinal = cantidad > 0 ? suma / cantidad : 0;

        resultado[item.Key] = (cantidad, promedioFinal);
    }

    return resultado;
}


private void CalcularEstadisticas(NodoArbol? nodo, Dictionary<string, (int cantidad, double sumaPromedios)> estadisticas)
{
    if (nodo == null)
        return;

    string carrera = nodo.Dato.Carrera;

    if (!estadisticas.ContainsKey(carrera))
    {
        estadisticas[carrera] = (0, 0.0);
    }

    var (cantidad, suma) = estadisticas[carrera];

    cantidad++;
    suma += nodo.Dato.Promedio;

    estadisticas[carrera] = (cantidad, suma);

    CalcularEstadisticas(nodo.Izquierdo, estadisticas);
    CalcularEstadisticas(nodo.Derecho, estadisticas);
}


y en el Program.cs

var stats = arbol.EstadisticasPorCarrera();

Console.WriteLine("\nEstudiantes por carrera:");

foreach (var item in stats)
{
    Console.WriteLine($"{item.Key}: {item.Value.cantidad} estudiantes | Promedio: {item.Value.promedio:F2}");
}
