using System;

namespace POO
{

    class Program
    {

        public static void Main(string[] args) 
        {
        
            Circulo circulo = new Circulo();
            Console.WriteLine(circulo.CalculoArea(6));

            ConversorEuroDolar  obj = new ConversorEuroDolar();
            Console.WriteLine(obj.convierte(50));

            double nuevoValor = 1.05;
            obj.CambiarValorEuro(nuevoValor);
            Console.WriteLine(obj.convierte(50));

        }

    }

    class Circulo
    {

        private const double pi = Math.PI;

        public double CalculoArea(int radio)
        {
            return pi * radio * radio;
        }

    }

    class ConversorEuroDolar
    {

        private double euro = 1.253;

        public double convierte(double cantidad) 
        {
            return cantidad * euro;
        }

        public void CambiarValorEuro(double nuevoValor)
        {
            if (nuevoValor >= 0)
                this.euro = nuevoValor;
            else
                this.euro = 0;
        }

    }

}
