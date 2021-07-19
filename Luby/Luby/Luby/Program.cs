using Luby.Logic;
using System;

namespace Luby
{
    class Program
    {
        static void Main(string[] args)
        {
            Matematica m = new Matematica();

            //executar algum dos métodos implementados
            var resultado = m.ContarNumerosPrimos(50);
            var resuldata = m.CalcularDiferencaData("26041993", "26042021");
            int[] vetor = { 1,2,3,4,5 };
            var pares = m.ObterElementosPares(vetor);
            Console.WriteLine($"Resultado: {resultado}");
            Console.WriteLine($"Resultado: {pares}");
            //Console.WriteLine("Digite uma tecla para sair.");
            Console.ReadKey();
        }
    }
}
