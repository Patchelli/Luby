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
            int[] vetor = { 1, 2, 3, 4, 5 };
            var pares = m.ObterElementosPares(vetor);
            Console.WriteLine($"Resultado: {resultado}");
            Console.WriteLine($"Resultado: {pares}");
            string[] nomes = new string[] {
                "John Doe",
                "Jane Doe",
                "Alice Jones",
                "Bobby Louis",
                "Lisa Romero"
            };

            var lst_nomes = m.BuscarPessoa(nomes, "Doe");

            foreach (string  i in lst_nomes)
            {
                Console.WriteLine("{0}",i);
            }

            int[,] matriz = m.TransformarEmMatriz("1,2,3,4,5,6");
            Console.WriteLine("Resultado da transformaçao em matriz :");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] != -1)
                    {
                        Console.Write("{0} ", matriz[i, j]);
                    }
                    else
                    {
                        Console.Write("null ");
                    }
                }
                Console.WriteLine("");
            }



            //Console.WriteLine("Digite uma tecla para sair.");
            Console.ReadKey();
        }
    }
}
