using System;

namespace ConceptosPOO 
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Clase fuente");
            realizarTarea();
        }

        static void realizarTarea()
        {
            Punto origen = new Punto(100, 80);
            Punto destino = new Punto(-100, 180);
            Punto otroPunto = new Punto();
             
            double distancia = origen.DistanciaHasta(destino);
            Console.WriteLine($"La distancia entre los dos puntos es: {distancia}");
            Console.WriteLine($"Numero de objetos creados: {Punto.getcontadorObjetos()}");
        }
    }
}
