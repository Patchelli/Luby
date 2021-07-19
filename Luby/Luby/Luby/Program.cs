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
            Console.WriteLine($"Resultado: {resultado}");
            Console.WriteLine("Digite uma tecla para sair.");
            Console.ReadKey();
        }
    }
}
