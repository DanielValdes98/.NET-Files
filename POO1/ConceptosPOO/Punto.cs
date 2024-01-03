using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConceptosPOO
{
    internal class Punto
    {

        private int x, y;
        private static int contadorObjetos = 0;

        public Punto(int x, int y) 
        {
            this.x = x;
            this.y = y;
            contadorObjetos++;
        }

        public Punto() 
        {
            this.x = 0;
            this.y = 0;
            contadorObjetos++;
        }

        public static int getcontadorObjetos() => contadorObjetos;
    

        public double DistanciaHasta(Punto otroPunto)
        {
            int xDif = this.x - otroPunto.x;
            int yDif = this.y - otroPunto.y;

            double distanciaPuntos = Math.Sqrt(Math.Pow(xDif, 2) + Math.Pow(yDif, 2));
            
            return distanciaPuntos;
        }
    }
}
