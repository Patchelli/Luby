using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Luby.Logic
{
    public class Matematica
    {
        public int CalcularFatorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Números negativos são inválidos.");

            if (n == 0)
                return 1;

            return n * CalcularFatorialRecursivo(n - 1);
        }

        private int CalcularFatorialRecursivo(int n)
        {
            return n > 1 ? n * CalcularFatorialRecursivo(n - 1) : 1;
        }

        public decimal CalcularPremio(decimal premio, string tipoFator, decimal? fatorProprio)
        {
            if (premio <= 0)
                throw new ArgumentException("Valor prêmio é inválido.");

            return premio * TipoPremio.GetFator(tipoFator, fatorProprio);
        }

        public int ContarNumerosPrimos(int n)
        {
            if (n < 0)
                throw new ArgumentException("Números negativos são inválidos.");

            int totalNumerosPrimos = 0;
            for (int i = 2; i <= n; i++)
            {
                if (NumeroEhPrimo(i))
                    totalNumerosPrimos++;
            }
            return totalNumerosPrimos;
        }

        private bool NumeroEhPrimo(int n)
        {
            if (n < 2)
                return false; // 1 e 0 não são primos

            for (int i = n - 1; i > 1; i--)
            {
                int resto = n % i;
                if (resto == 0)
                    return false;
            }
            return true;
        }

        public int CalcularVogais(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            string normalizado = RemoverAcentuacao(text);

            return ObterSomenteLetras(normalizado)
                .ToLower()
                .Count(v => Vogais.Contains(v));
        }

        public string ObterSomenteLetras(string text)
        {
            return new string(text.Where(char.IsLetter).ToArray());
        }

        public string RemoverAcentuacao(string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }

        public string CalcularValorComDescontoFormatado(string valor, string percentual)
        {
            if (string.IsNullOrEmpty(valor))
                throw new ArgumentException("Valor é inválido.");

            if (string.IsNullOrEmpty(percentual))
                throw new ArgumentException("Percentual é inválido.");

            decimal valorCalculado = ObterValor(valor);
            valorCalculado -= valorCalculado * ObterPercentual(percentual);
            return valorCalculado.ToString("C", CultureInfo.CurrentCulture);
        }

        public int CalcularDiferencaData(string dataInicial, string dataFinal)
        {

            string dataInicialFormatada = AdicionarString(dataInicial);
            string dataFinalFormatada = AdicionarString(dataFinal);
            TimeSpan date = Convert.ToDateTime(dataFinalFormatada) - Convert.ToDateTime(dataInicialFormatada);
            int dias = date.Days;
            if (dias < 0)
                throw new ArgumentException("Números negativos são inválidos.");
            return dias;
        }

        public int []  ObterElementosPares(int[] vetor)
        {
            IEnumerable<int> result =
                 from num in vetor
                 where num % 2 == 0
                 select num;

            return result.ToArray();
        }

        public string [] BuscarPessoa (string [] nomes, string nome)
        {
            verificarNomeIsEmptyOrNull(nome);
            List<string> lst_nomes = new List<string>();
            for (int i = 0; i < nomes.Length; i++) {
                if (nomes[i].Contains(nome))
                {
                    lst_nomes.Add(nomes[i]);
                } 
            }
            verificarListExist(lst_nomes);
            return lst_nomes.ToArray();
        }

        public int [,] TransformarEmMatriz(string numerosString)
        {
            if (numerosString.Length % 2 != 0)
            {
                numerosString = numerosString + ",-1";
            }
            string[] aux = numerosString.Split(',');
            int[,] res = new int[aux.Length / 2, 2];

            for (int i = 0, k = 0; i < aux.Length / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    res[i, j] = int.Parse(aux[k]);
                    k++;
                }
            }
            return res;
        }

        public int[] ObterElementosFaltantes(int[] vetor_1, int[] vetor_2)
        {
            var res = new List<int>();

            var aux1 = vetor_1.ToList();
            var aux2 = vetor_2.ToList();

            for (int i = 0; i < vetor_1.Length; i++)
            {
                if (aux2.Contains(vetor_1[i]))
                {
                    aux2.Remove(vetor_1[i]);
                }
            }

            for (int i = 0; i < vetor_2.Length; i++)
            {
                if (aux1.Contains(vetor_2[i]))
                {
                    aux1.Remove(vetor_2[i]);
                }
            }
            foreach (int i in aux1)
            {
                res.Add(i);
            }
            foreach (int i in aux2)
            {
                res.Add(i);
            }

            return res.ToArray();
        }

        private decimal ObterPercentual(string percentual)
        {
            return ObterValor(percentual) / 100;
        }

        private decimal ObterValor(string valor)
        {
            if (!decimal.TryParse(LimparString(valor), out decimal valorObtido))
                throw new ArgumentException("Valor é inválido.");

            return valorObtido;
        }

        private string LimparString(string valor)
        {
            return valor
                .Replace("R$", string.Empty)
                .Replace("%", string.Empty)
                .Trim();
        }

        private string AdicionarString(string data)
        {
            string dataFormatada = data.Insert(2, "/").Insert(5, "/");
            return dataFormatada;
        }

        private void verificarNomeIsEmptyOrNull(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome vázio ou Nulo.");
            }
        }

        private void verificarListExist(List<string> lst_nomes)
        {
          if (!lst_nomes.Any())
            {
                throw new ArgumentException("Nome não existe na lista!");
            }
        }

        private Vogais _Vogais { get; set; }
        public Vogais Vogais
        {
            get
            {
                if (_Vogais == null)
                    _Vogais = new Vogais { 'a', 'e', 'i', 'o', 'u' };
                return _Vogais;
            }
            set { _Vogais = value; }
        }

        private TipoPremio _TipoPremio { get; set; }
        public TipoPremio TipoPremio
        {
            get
            {
                if (_TipoPremio == null)
                    _TipoPremio = new TipoPremio();
                return _TipoPremio;
            }
            set { _TipoPremio = value; }
        }
    }
}
