using Luby.Logic;
using System;
using Xunit;

namespace Luby.Test.MatematicaTests
{
    public class DescontoTests
    {
        private readonly Matematica _matematica;
        public DescontoTests()
        {
            _matematica = new Matematica();
        }

        [Theory]
        [InlineData("", "30%")]
        public void CalcularValorComDescontoFormatado_should_throw_argument_exception_when_valor_is_empty(string valor, string percentual)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.CalcularValorComDescontoFormatado(valor, percentual));
            Assert.Equal("Valor é inválido.", exception.Message);
        }

        [Theory]
        [InlineData("R$ 6.800,00", "")]
        public void CalcularValorComDescontoFormatado_should_throw_argument_exception_when_percentual_is_empty(string valor, string percentual)
        {
            var exception = Assert.Throws<ArgumentException>(() => _matematica.CalcularValorComDescontoFormatado(valor, percentual));
            Assert.Equal("Percentual é inválido.", exception.Message);
        }

        [Theory]
        [InlineData("R$ 6.800,00", "30%")]
        public void CalcularVogais_should_returns_5(string valor, string percentual)
        {
            string resultado = _matematica.CalcularValorComDescontoFormatado(valor, percentual);
            Assert.Equal("R$ 4.760,00", resultado);
        }

        [Theory]
        [InlineData("")]
        public void CalcularVogais_should_returns_0(string text)
        {
            decimal resultado = _matematica.CalcularVogais(text);
            Assert.Equal(0, resultado);
        }
    }
}
