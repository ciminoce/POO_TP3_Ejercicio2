using Entidades;
using System;

namespace POO_TP3_Ejercicio2.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ahora vas a crear un hexágono.");

            Console.WriteLine("Ingresá el valor de lado:");     // Ingreso del valor del lado
            double valorDelLado = Double.Parse(Console.ReadLine());
            Console.WriteLine($"valorDelLado:{valorDelLado}");      // Control

            Console.WriteLine("Ingresá el valor del apotema:");     // Ingreso del valor del apotema
            double valorDelApotema = Double.Parse(Console.ReadLine());
            Console.WriteLine($"valorDelApotema:{valorDelApotema}");      // Control

            Hexagono hexagono = new Hexagono(valorDelLado);       // Creación del objeto hexagono

            Console.WriteLine($"El valor del lado es: {hexagono.GetLado()}");

            Console.WriteLine($"El valor del perimetro es: {hexagono.GetPerimetro()}");
            Console.WriteLine($"El valor del area es: {hexagono.GetArea()}");

            Console.ReadLine();
        }
    }
}
