using System;

namespace Entidades
{
    public class Hexagono
    {
        private double lado;        // Atributos privados
        private double apotema;
        
        public Hexagono(double valorDelLado )        // Constructor
        {
            lado = valorDelLado;
            apotema = SetApotema();
        }

        public void SetLado(double valorDelLado)        // Propiedades
        {
            lado = valorDelLado;            
        }
        /// <summary>
        /// Método privado para setear el valor del apotema, utilizando el valor del lado para el cálculo
        /// </summary>
        /// <returns>valor del apotema</returns>
        private double SetApotema()
        {
            return Math.Sqrt(Math.Pow(lado, 2)-Math.Pow(lado/2, 2));
        }

        public double GetLado()     
        {
            return lado;
        }        

        public double GetApotema()
        {
            return apotema;
        }

        public double GetPerimetro()        // Métodos
        {
            return lado * 6;            
        }

        public double GetArea()
        {
            return (GetPerimetro() * apotema)/2;
        }
    }    
}
