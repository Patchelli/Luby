using Luby.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Luby.Test.MatematicaTests
{
    public class BuscarPessoaTest
    {
        private readonly Matematica _matematica;
        public BuscarPessoaTest()
        {
            _matematica = new Matematica();
        }

        [Theory]
        [InlineData(new string[] {"John Doe","Jane Doe","Alice Jones","Bobby Louis","Lisa Romero"},"Doe")]
        public void ObterElementosPares_should_returns_nomes_Jane_Doe_John_Doe(string[] lst_nomes, string nome)
        {
            string[] resultado = _matematica.BuscarPessoa(lst_nomes, nome);
            Assert.Equal(new string[] { "John Doe", "Jane Doe" }, resultado);
        }

        [Theory]
        [InlineData(new string[] { "John Doe", "Jane Doe", "Alice Jones", "Bobby Louis", "Lisa Romero" }, "")]
        public void ObterElementosPares_should_returns_nomes_empty(string[] lst_nomes, string nome)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.BuscarPessoa(lst_nomes, nome));
            Assert.Equal("Nome vázio ou Nulo.", exception.Message);
        }

        [Theory]
        [InlineData(new string[] { "John Doe", "Jane Doe", "Alice Jones", "Bobby Louis", "Lisa Romero" }, null)]
        public void ObterElementosPares_should_returns_nomes_null(string[] lst_nomes, string nome)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.BuscarPessoa(lst_nomes, nome));
            Assert.Equal("Nome vázio ou Nulo.", exception.Message);
        }

        [Theory]
        [InlineData(new string[] { "John Doe", "Jane Doe", "Alice Jones", "Bobby Louis", "Lisa Romero" }, "Patchelli")]
        public void ObterElementosPares_should_returns_nomes_no_exist(string[] lst_nomes, string nome)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.BuscarPessoa(lst_nomes, nome));
            Assert.Equal("Nome não existe na lista!", exception.Message);
        }

    }
}
