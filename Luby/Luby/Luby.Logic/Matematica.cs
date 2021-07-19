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
            List<int> pares_list = new List<int>();
            for (int i = 0; i < vetor.Length; i++)
            {
                if (vetor[i] % 2 == 0)
                {
                    pares_list.Add(vetor[i]);
                }
            }
            int [] arrayPares =  pares_list.ToArray();

            return arrayPares;
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
